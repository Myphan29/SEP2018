Feature: ChangePassword
	In order to change password
	As a user
	I want to Login to the website

@mytag
Scenario: Change password successfull
	Given I was logged in	
	When I press change password button
	And I fill old and new password
	Then The password should be changed

Scenario: Change password unsuccessfull with wrong old password
	Given I was logged in	
	When I press change password button
	And I fill wrong old pass and new pass
	Then The password shouldn't be changed

Scenario: Change password unsuccessfull with wrong condition new password
	Given I was logged in	
	When I press change password button
	And I fill old and new wrong condition new password
	Then The password shouldn't be changed

Scenario: Change password unsuccessfull with new and confirm pass aren't the same
	Given I was logged in	
	When I press change password button
	And I fill all but new pass and confirm aren't the same 
	Then The password shouldn't be changed

Scenario: Change password unsuccessfull with old pass and new pass are the same
	Given I was logged in	
	When I press change password button
	And I fill old and new aren't the same
	Then The password shouldn't be changed
