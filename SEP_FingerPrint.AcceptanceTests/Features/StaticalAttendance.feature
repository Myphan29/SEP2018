Feature: StaticalAttendance
	In order to attendance
	As a user
	I want to Log into the website

@mytag
Scenario: See statistical
	Given I was in user view	
	And I go to user page
	When I press attendance button	
	Then the list of attendance show off as user want
