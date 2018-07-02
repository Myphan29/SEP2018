Feature: ManageTeacher
	In order to see list of teacher of faculty
	As a admin
	I want to be see the list

@mytag
Scenario: Manage Teacher
	Given I log in admin account
	And I go to the page admin 
	When I press button "Quan li giang vien"
	Then the list of teacher show off
