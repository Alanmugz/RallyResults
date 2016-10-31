using log4net;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace RallyResults.Data
{
	public class Repository : RallyResults.Data.IRepository
	{
		private readonly ILog c_logger;
		private NpgsqlConnection c_connection;


		public Repository(
			ILog logger,
			string databaseConnectionString)
		{
			this.c_logger = logger;
			this.c_connection = new NpgsqlConnection(databaseConnectionString);
		}


		public RallyResults.Data.Enumeration.Status InsertEvent(
			RallyResults.Data.Models.Event subject)
		{
			try
			{
				this.c_connection.Open();

				NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO \"Event\" VALUES(:Id, :Category_Class, :CreationTimestamp)", this.c_connection);

				cmd.Parameters.Add(new NpgsqlParameter("Id", this.FetchLastestId()));
				var parameter = cmd.CreateParameter();
				parameter.ParameterName = "Category_Class";
				parameter.Value = JsonConvert.SerializeObject(subject);
				parameter.NpgsqlDbType = NpgsqlDbType.Json;
				cmd.Parameters.Add(parameter);
				cmd.Parameters.Add(new NpgsqlParameter("CreationTimestamp", DateTime.Now));

				cmd.ExecuteNonQuery();

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
			try
			{
				this.c_connection.Open();

				NpgsqlCommand cmd = new NpgsqlCommand("UPDATE \"Event\" SET \"Category_Class\" = :Category_Class, \"CreationTimestamp\" = :CreationTimestamp WHERE \"Id\" = :id;", this.c_connection);

				cmd.Parameters.Add(new NpgsqlParameter("Id", id));
				var parameter = cmd.CreateParameter();
				parameter.ParameterName = "Category_Class";
				parameter.Value = JsonConvert.SerializeObject(subject);
				parameter.NpgsqlDbType = NpgsqlDbType.Json;
				cmd.Parameters.Add(parameter);
				cmd.Parameters.Add(new NpgsqlParameter("CreationTimestamp", DateTime.Now));

				cmd.ExecuteNonQuery();

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

				NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM \"Event\" WHERE \"Id\" = :id;", this.c_connection);

				cmd.Parameters.Add(new NpgsqlParameter("Id", id));

				cmd.ExecuteNonQuery();

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

				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM \"Event\" WHERE \"Id\" = :id;", this.c_connection);

				cmd.Parameters.Add(new NpgsqlParameter("Id", id));

				var row = cmd.ExecuteReader();

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
			NpgsqlCommand cmd = new NpgsqlCommand("SELECT MAX(\"Id\") FROM \"Event\"", this.c_connection);

			if (cmd.ExecuteScalar() ==  DBNull.Value)
			{
				return 1;
			}

			return Convert.ToInt32(cmd.ExecuteScalar()) + 1;
		}
	}
}