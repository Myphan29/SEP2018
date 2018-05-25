Feature: ResetPassword
	In order to reset password
	As a admin
	I want to reset password user

Scenario: Reset password user succesfull
	Given I was in the Login view
	And I filled the username and password field 
	And I press Login
	And I should be Logged in and arrive at admin profile view
	When I press reset password of user	
	And I fill new password
	And I fill password confirmation
	And I click change password button
	Then I see password is changed successfully message

Scenario: Reset password user unsuccesfull
	Given I was in the Login view
	And I filled the username and password field 
	And I press Login
	And I should be Logged in and arrive at admin profile view
	When I press reset password of user	
	And I fill new password doesn't match condition
	And I fill password confirmation
	And I click reset password button
	Then I see password is changed unsuccessfully message

Scenario: Reset password user unsuccesfull
	Given I was in the Login view
	And I filled the username and password field 
	And I press Login
	And I should be Logged in and arrive at admin profile view
	When I press reset password of user	
	And I fill new password 
	And I fill password confirmation doesn't match new password
	And I click reset password button
	Then I see password is changed unsuccessfully message

Scenario: Reset password user unsuccesfull
	Given I was in the Login view
	And I filled the username and password field 
	And I press Login
	And I should be Logged in and arrive at admin profile view
	When I press reset password of user	
	And I fill new password 
	And I fill password confirmation doesn't match new password
	And I click reset password button
	Then I see password is changed unsuccessfully message

Scenario: Reset password user unsuccesfull
	Given I was in the Login view
	And I filled the username and password field 
	And I press Login
	And I should be Logged in and arrive at admin profile view
	When I press reset password of user	
	And I fill new password nothing
	And I fill password confirmation 
	And I click reset password button
	Then I see password is changed unsuccessfully message

Scenario: Reset password user unsuccesfull
	Given I was in the Login view
	And I filled the username and password field 
	And I press Login
	And I should be Logged in and arrive at admin profile view
	When I press reset password of user	
	And I fill new password nothing
	And I fill password confirmation nothing
	And I click reset password button
	Then I see password is changed unsuccessfully message