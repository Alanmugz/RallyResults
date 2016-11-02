
Curl:
	
	$json = "{\""name\"": \""Westlodge Fastnet Rally 2015\"",\""startdate\"": \""2015-10-24\"",\""finishdate\"": \""2015-10-25\"",\""surface\"": \""Tarmac\"",\""image\"": \""image.jpg\"",\""service\"": [3, 6],\""endofday\"": [10],\""category\"": [{\""type\"": \""Main Field\"",\""class\"": \""1\""}]}"
	
	curl -v -H "Accept: application/json" -H "Content-Type: application/json" -X POST -d $json http://localhost:2235/v1/rallyresults/insert/event
	
	curl -v -H "Accept: application/json" -H "Content-Type: application/json" -X PUT -d $json http://localhost:2235/v1/rallyresults/update/event/id/3
	
	curl -v -H "Accept: application/json" -H "Content-Type: application/json" -X DELETE http://localhost:2235/v1/rallyresults/delete/event/id/3
	
	curl http://localhost:2235/v1/rallyresults/select/event/id/10
	
