Feature: LoginAndLogout
	In order to attendance
	As a user
	I want to Log into the website
Background: 
	Given User is at the Login Page

Scenario: Login with account teacher successful
	When User enter UserName = t150001 and Password = 123456 of teacher
	Then I can see the button đăng xuất and name of me

Scenario: Login with account admin successful
	When User enter UserName = admin and Password = 123456 of admin
	Then I can see the button đăng xuất and name of admin

Scenario: Login with account unsuccessful with wrong username
	When User enter UserName = asdasda and Password = 123456
	Then Appear message "Tài khoản không tồn tại." because wrong username

Scenario: Login with account unsuccessful with wrong password
	When User enter UserName = t150001 and Password = 454546546546
	Then Appear message "Tài khoản hoặc mật khẩu không đúng." because wrong password

Scenario: Login with account unsuccessful because disable
	When User enter UserName = t150004 and Password = 123456 (trạng thái: "disable")
	Then Appear message "Tài khoản đang bị khoá." because account was disable

Scenario: Login with account unsuccessful because account don't exist
	When User enter UserName = asdasd and Password =adsadadas 
	Then Appear message "Tài khoản không tồn tại." because account don't exist

Scenario: Login with account unsuccessful because don't type username
	When User enter UserName = and Password = adsadadas 
	Then Appear message "Hãy điền tên tài khoản" becasause user don't type username

Scenario: Login with account unsuccessful because don't type password
	When User enter UserName =asdasdasd and Password =
	Then Appear message "Hãy điền mật khẩu" user don't type password


	