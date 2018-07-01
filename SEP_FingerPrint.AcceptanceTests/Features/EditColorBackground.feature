Feature: EditColorBackground
	In order to edit color background of attendance
	As a user
	I want to be login

@mytag
Scenario: edit color attendance
	Given I was login
	And I go to course page
	When I press button "cai dat"
	And I go to set color page
	And I choose color
	And I click save
	Then the color of layout attendance is changed
