Feature: RallyResultsEvents
	In order to insert, update, delete and select from the rally results events database
	As an end user
	I want to verify the API response


	@events
	Scenario Outline: Insert Rally Results Event
		Given I have a rally results event object "<object_string>"
		And I send a request to the API
		Then the result code should be "<result_code>"


		Examples:
			| object_string																																																					| result_code	 | 
			| {"name": "Westlodge Fastnet Rally 2015","startdate": "2015-10-24","finishdate": "2015-10-25","surface": "Tarmac","image": "image.jpg","service": [3, 6],"endofday": [10],"category": [{"type": "Main Field","class": "1"}]}	| 201			 |
			| {"name": "Westlodge Fastnet Rally 2015","startdate": "2015-10-24","finishdate": "2015-10-25","surface": "Tarmac","image": "image.jpg","service": [3, 6],"endofday": [10],"category": [{"type": "Main Field","class": "1"}]}	| 201			 |