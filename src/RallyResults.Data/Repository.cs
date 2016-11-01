using log4net;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Configuration;
using System.Linq;
using RallyResults.Data.Models;

namespace RallyResults.Data
{
	public class Repository : RallyResults.Data.IRepository
	{
		private readonly ILog c_logger;
		private NpgsqlConnection c_connection;


		public Repository(
			ILog logger)
		{
			this.c_logger = logger;
			this.c_connection = new NpgsqlConnection(ConfigurationManager.AppSettings["databaseConnectionString"]);
		}


		public RallyResults.Data.Enumeration.Status InsertEvent(
			RallyResults.Data.Models.Event subject)
		{
			try
			{
				this.c_connection.Open();

				var _entry = this.MapEvent(subject, this.FetchLastestId());

				NpgsqlCommand _cmd = new NpgsqlCommand("INSERT INTO \"Event\" VALUES(:Id, :Category_Class, :CreationTimestamp)", this.c_connection);

				_cmd.Parameters.Add(new NpgsqlParameter("Id", _entry.id));
				var parameter = _cmd.CreateParameter();
				parameter.ParameterName = "Category_Class";
				parameter.Value = JsonConvert.SerializeObject(_entry.eventDetails);
				parameter.NpgsqlDbType = NpgsqlDbType.Json;
				_cmd.Parameters.Add(parameter);
				_cmd.Parameters.Add(new NpgsqlParameter("CreationTimestamp", _entry.creationTimestamp));

				_cmd.ExecuteNonQuery();

				return RallyResults.Data.Enumeration.Status.Success;
			}
			catch (NpgsqlException ex)
			{
				c_logger.ErrorFormat($"{ex}");
			}
			finally
			{
				this.c_connection.Close();
			}

			return RallyResults.Data.Enumeration.Status.Failure;
		}


		public RallyResults.Data.Enumeration.Status UpdateEvent(
			int id,
			RallyResults.Data.Models.Event subject)
		{
			var _entry = this.MapEvent(subject, id);

			try
			{
				this.c_connection.Open();

				NpgsqlCommand _cmd = new NpgsqlCommand("UPDATE \"Event\" SET \"Category_Class\" = :Category_Class, \"CreationTimestamp\" = :CreationTimestamp WHERE \"Id\" = :id;", this.c_connection);

				_cmd.Parameters.Add(new NpgsqlParameter("Id", _entry.id));
				var parameter = _cmd.CreateParameter();
				parameter.ParameterName = "Category_Class";
				parameter.Value = JsonConvert.SerializeObject(_entry.eventDetails);
				parameter.NpgsqlDbType = NpgsqlDbType.Json;
				_cmd.Parameters.Add(parameter);
				_cmd.Parameters.Add(new NpgsqlParameter("CreationTimestamp", _entry.creationTimestamp));

				_cmd.ExecuteNonQuery();

				return RallyResults.Data.Enumeration.Status.Success;
			}
			catch (NpgsqlException ex)
			{
				c_logger.ErrorFormat($"{ex}");
			}
			finally
			{
				this.c_connection.Close();
			}

			return RallyResults.Data.Enumeration.Status.Failure;
		}


		public RallyResults.Data.Enumeration.Status DeleteEvent(
			int id)
		{
			try
			{
				this.c_connection.Open();

				NpgsqlCommand _cmd = new NpgsqlCommand("DELETE FROM \"Event\" WHERE \"Id\" = :id;", this.c_connection);

				_cmd.Parameters.Add(new NpgsqlParameter("Id", id));

				_cmd.ExecuteNonQuery();

				return RallyResults.Data.Enumeration.Status.Success;
			}
			catch (NpgsqlException ex)
			{
				c_logger.ErrorFormat($"{ex}");
			}
			finally
			{
				this.c_connection.Close();
			}

			return RallyResults.Data.Enumeration.Status.Failure;
		}


		public RallyResults.Data.AggregateRoot.Event SelectEvent(
			int id)
		{
			try
			{
				this.c_connection.Open();

				NpgsqlCommand _cmd = new NpgsqlCommand("SELECT * FROM \"Event\" WHERE \"Id\" = :id;", this.c_connection);

				_cmd.Parameters.Add(new NpgsqlParameter("Id", id));

				var row = _cmd.ExecuteReader();

				while (row.Read())
				{
					var _entry = new RallyResults.Data.AggregateRoot.Event(
						(int)row["Id"],
						JsonConvert.DeserializeObject<RallyResults.Data.AggregateRoot.EventDetails>((string)row["Category_Class"]),
						(DateTime)row["CreationTimestamp"]);

					return _entry;
				}
			}
			catch (NpgsqlException ex)
			{
				c_logger.ErrorFormat($"{ex}");
			}
			finally
			{
				this.c_connection.Close();
			}

			return null;
		}


		private int FetchLastestId()
		{
			NpgsqlCommand _cmd = new NpgsqlCommand("SELECT MAX(\"Id\") FROM \"Event\"", this.c_connection);

			if (_cmd.ExecuteScalar() ==  DBNull.Value)
			{
				return 1;
			}

			return Convert.ToInt32(_cmd.ExecuteScalar()) + 1;
		}


		private RallyResults.Data.AggregateRoot.Event MapEvent(
			RallyResults.Data.Models.Event subject,
			int id)
		{
			var categories  = subject.category.Select(category => new RallyResults.Data.AggregateRoot.Category(category.type, category.@class)).ToList();

			return new RallyResults.Data.AggregateRoot.Event(
				id,
				new RallyResults.Data.AggregateRoot.EventDetails(
					subject.name,
					subject.startdate,
					subject.finishdate,
					subject.surface,
					subject.image,
					subject.service,
					subject.endofday,
					categories),
				DateTime.Now);
		}
	}
}