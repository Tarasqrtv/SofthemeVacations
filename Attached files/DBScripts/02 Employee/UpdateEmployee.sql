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


Update Employee
	Set TeamID = (SELECT TeamID FROM Team WHERE Team.Name = 'TeamLeads')
	WHERE JobTitleID = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Team Lead');

Update Employee
	Set TeamID = (SELECT TeamID FROM Team WHERE Team.Name = 'QA')
	WHERE JobTitleID = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee')
		  and EmployeeID != (SELECT TeamLeadID FROM Team WHERE Team.Name = 'QA')
			and TeamID is null
			and Employee.Name in ('Beryl', 'Alfhild', 'Charles', 'Ezequiel', 'Ram');

Update Employee
	Set TeamID = (SELECT TeamID FROM Team WHERE Team.Name = 'Frontend')
	WHERE JobTitleID = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee')
		  and EmployeeID != (SELECT TeamLeadID FROM Team WHERE Team.Name = 'QA')
			and TeamID is null
			and Employee.Name in ('Basmat', 'Hemming','Alex', 'Turid', 'Vesna');

Update Employee
	Set TeamID = (SELECT TeamID FROM Team WHERE Team.Name = 'Frontend')
	WHERE JobTitleID = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee')
		  and EmployeeID != (SELECT TeamLeadID FROM Team WHERE Team.Name = 'QA')
			and TeamID is null;