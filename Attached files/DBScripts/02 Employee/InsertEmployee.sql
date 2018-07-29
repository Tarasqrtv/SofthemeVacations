--Employee

DECLARE @StatusID_Active uniqueidentifier = (SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active');

DECLARE @TitleID_Employee uniqueidentifier = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee');
DECLARE @TitleID_TeamLead uniqueidentifier = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Team Lead');
DECLARE @TitleID_ProjectManager uniqueidentifier = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Project Manager');

INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID,StartDate, WorkEmail, Name, Surname)
VALUES 
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Alex', 'TEST'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Charles', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Beryl', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Vesna', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Turid', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Chaggai', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Alfhild', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Ram', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Ezequiel', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Sherrie', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Perle', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Basmat', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Jonathan', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Zivit', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'work@gmail.com', 'Hemming', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_TeamLead, GetDate(), 'work@gmail.com', 'Taras', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_TeamLead, GetDate(), 'work@gmail.com', 'Halstein', 'TEST') ,
(NEWID(), @StatusID_Active, @TitleID_TeamLead, GetDate(), 'work@gmail.com', 'Zaharina', 'TEST'),
(NEWID(), @StatusID_Active, @TitleID_ProjectManager, GetDate(),'work@gmail.com', 'Luda', 'TEST')