Feature: ResetPassword
	In order to reset password of user
	As a admin
	I want to change password of user

Scenario: Reset Password successfull
	Given I was in admin view
	And I click teacher list		
	When I press reset password of the user
	And I fill new password,confirmation and see the message succesfull
	And I logout admin account
	Then I login by that user account successfull

Scenario: Reset Password unsuccessfull with wrong condition password
	Given I was in admin view
	And I click teacher list		
	When I press reset password of the user
	Then I fill wrong condition new password,confirmation and see the message unsuccesfull
	
Scenario: Reset Password unsuccessfull confirmation doesn't match the password
	Given I was in admin view
	And I click teacher list		
	When I press reset password of the user
	Then I fill new password,confirmation doesn't match the password and see the message unsuccesfull

Scenario: Reset Password unsuccessfull with fill nothing
	Given I was in admin view
	And I click teacher list		
	When I press reset password of the user
	Then I fill no new password,confirmation and see the message unsuccesfull	
