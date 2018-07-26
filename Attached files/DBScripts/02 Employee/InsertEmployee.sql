--Employee

DECLARE @StatusID_Active uniqueidentifier = (SELECT EmployeeStatusID FROM EmployeeStatus WHERE EmployeeStatus.Name = 'Active');

DECLARE @TitleID_Employee uniqueidentifier = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Employee');
DECLARE @TitleID_TeamLead uniqueidentifier = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Team Lead');
DECLARE @TitleID_ProjectManager uniqueidentifier = (SELECT JobTitleID FROM JobTitle WHERE JobTitle.Name = 'Project Manager');

INSERT INTO Employee (EmployeeID, EmployeeStatusID, JobTitleID, StartDate, Name)
VALUES 
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Alex'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Charles'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Beryl'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Vesna'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Turid'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Chaggai'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Alfhild'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Ram'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Ezequiel'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Sherrie'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Perle'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Basmat'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Jonathan'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Zivit'),
(NEWID(), @StatusID_Active, @TitleID_Employee, GetDate(), 'Hemming'),
(NEWID(), @StatusID_Active, @TitleID_TeamLead, GetDate(), 'Taras'),
(NEWID(), @StatusID_Active, @TitleID_TeamLead, GetDate(), 'Halstein'),
(NEWID(), @StatusID_Active, @TitleID_TeamLead, GetDate(), 'Zaharina'),
(NEWID(), @StatusID_Active, @TitleID_ProjectManager, GetDate(), 'Luda')