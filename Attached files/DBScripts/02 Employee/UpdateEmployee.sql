Update Employee
Set Balance = 28

Update Employee
Set Surname = 'Whitehead',
	WorkEmail = 'whiteheadwork@gmail.com',
	TelephoneNumber = '380651638621',
	Birthday = GETDATE() - (365 * 23),
    Skype = 'whitehd',
    StartDate = GETDATE() - (365*2),
    EmployeeStatusId = (Select EmployeeStatusId From EmployeeStatus Where EmployeeStatus.Name = 'Active')