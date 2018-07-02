Feature: EditColorAttendance
	In order to edit color
	As a user
	I want to edit colors
@mytag
Scenario: Edit the color of attendance
	Given I was loggedin
	And I go to the course page
	When I press the button "cai dat"
	And I go to the color page
	And I choose the color
	And I click "save"
	Then the color is changed
