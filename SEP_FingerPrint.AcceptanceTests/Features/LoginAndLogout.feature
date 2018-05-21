Feature: LoginAndLogout
	In order to attendance
	As a user
	I want to Log into the website
Background: 
	Given User is at the Login Page

Scenario: Login with account teacher successful
	When User enter UserName = 't150001' and Password = '123456'
	Then I can see the button đăng xuất and name of me
	