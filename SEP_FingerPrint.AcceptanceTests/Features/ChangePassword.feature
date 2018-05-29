Feature: ChangePassword
	In order to change password
	As a user
	I want to change password
Background: 
	Given User is at Change Password page

Scenario: Change password successfully
	When I enter Old Password = 123456 and New Password = 123456789 and Confirm New Password =123456789
	Then the result should be display successful message Đổi mật khẩu thành công

Scenario: Change password unsuccess with wrong Old password
	When i enter Old Password = 1234567 and New Password = 123456789 and Confirm New Password =123456789
	Then the result should be display error message Mật khẩu cũ sai

Scenario: Change password unsuccess with wrong password condition
	When i enter Old Password = 123456 and New Password = 1 and Confirm New Password =1
	Then the result should be display error message Đổi mật khẩu không thành công with reason At least 6 characters long

Scenario: Change password unsuccess with wrong password confirm
	When i enter Old Password = 123456 and New Password = 123456789 and Confirm New Password =1
	Then the result should be display error message Đổi mật khẩu không thành công with reason The new password and confirmation password do not match

Scenario: Change password unsuccess with same password on Old password and New password
	When i enter Old Password = 123456 and New Password = 123456 and Confirm New Password =123456
	Then the result should be display error message Mật khẩu mới không được giống mật khẩu cũ