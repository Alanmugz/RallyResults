
Curl:
	Schedules
		local
			curl.exe -v -H 'Accept: application/json' -H 'Content-type: application/json' -X POST -d "{ provider_id : 9 }" http://localhost:20001/schedules

		dev
			curl.exe -v -H 'Accept: application/json' -H 'Content-type: application/json' -X POST -d "{ provider_id : 9 }" https://dev.internal.appfarm.local/reutersclient/schedules --insecure

		extdev
			curl.exe -v -H 'Accept: application/json' -H 'Content-type: application/json' -X POST -d "{ provider_id : 9 }" https://extdev.internal.appfarm.local/reutersclient/schedules --insecure

		qa
			curl.exe -v -H 'Accept: application/json' -H 'Content-type: application/json' -X POST -d "{ provider_id : 9 }" https://qa.internal.appfarm.local/reutersclient/schedules --insecure

		uat
			curl.exe -v -H 'Accept: application/json' -H 'Content-type: application/json' -X POST -d "{ provider_id : 9 }" https://uat.internal.appfarm.local/reutersclient/schedules --insecure

		prod
			curl.exe -v -H 'Accept: application/json' -H 'Content-type: application/json' -X POST -d "{ provider_id : 9 }" https://s1.prod.internal.appfarm.local/reutersclient/schedules --insecure
			
	Rates
		local
			curl.exe -v "http://localhost:20001/rates?file_name=ReutersRates.xml" --insecure
			
		dev
			curl.exe -v "https://dev.internal.appfarm.local/reutersclient/rates?file_name=ReutersRates.xml" --insecure
			
		extdev
			curl.exe -v "https://extdev.internal.appfarm.local/reutersclient/rates?file_name=ReutersRates.xml" --insecure
			
		qa
			curl.exe -v "https://qa.internal.appfarm.local/reutersclient/rates?file_name=ReutersRates.xml" --insecure
			
		uat
			curl.exe -v "https://uat.internal.appfarm.local/reutersclient/rates?file_name=ReutersRates.xml" --insecure
