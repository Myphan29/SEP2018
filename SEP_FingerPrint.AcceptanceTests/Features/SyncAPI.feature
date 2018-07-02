Feature: SyncAPI
	In order to sync API
	As a user
	I want to sync API from the system

@mytag
Scenario: Sync API
	Given I was log in successfull
	And I was moved to Course page
	When I press button "Khoa hoc"
	Then the result should be 120 on the screen
