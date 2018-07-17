--Admin
INSERT INTO [User](UserID, EmployeeID, Password, PersonalEmail, RoleID)
SELECT 
	NEWID(),
	(SELECT EmployeeID FROM Employee WHERE Name = 'Alex'),
	'pass',
	'alex@gmail.com',
	(SELECT RoleID FROM Role WHERE Name = 'Admin')


INSERT INTO [User](UserID, EmployeeID, Password, PersonalEmail, RoleID)
SELECT 
	NEWID(),
	(SELECT EmployeeID FROM Employee WHERE Name = 'Charles'),
	'pass',
	'charles@gmail.com',
	(SELECT RoleID FROM Role WHERE Name = 'Employee')

--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Beryl'

--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Vesna'

--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Turid'

--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Chaggai'

--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Alfhild'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Ram'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Ezequiel'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Sherrie'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Perle'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Basmat'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Jonathan'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Zivit'
	
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee'),
--	GetDate(),
--	'Hemming'

----SELECT * FROM Employee

----Team Lead 
----Frontend
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Team Lead'),
--	GetDate(),
--	'Taras'

----Frontend
----Backend
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Team Lead'),
--	GetDate(),
--	'Halstein'

--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Team Lead'),
--	GetDate(),
--	'Zaharina'

---- Project Manager
--INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
--SELECT 
--	NEWID(),
--	(SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active'),
--	(SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Project Manager'),
--	GetDate(),
--	'Luda'