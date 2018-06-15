Feature: ChangeStatus
	In order to change status of user
	As a admin
	I want to change status of user

Scenario: Change status user succesfull
	Given I was in the Login view
	And I filled the username and password field 
	And I press Login
	And I should be Logged in and arrive at admin profile view
	When I press acticve account of user	
	And I click button below status column	
	And I click logout
	And I log in with that user account
	Then I should be in that user profile view