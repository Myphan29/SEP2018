Feature: SeeInformationProject
	In order to see information of project
	As a user
	I want to see information of project
@mytag
Scenario: See information succesfull
	Given I was loggin successfull
	And I press button "i"
	And I see the date of course
	And I press month
	And I press week
	And I press day
	And I press list
	Then I finally see the list
