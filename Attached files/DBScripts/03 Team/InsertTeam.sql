INSERT INTO Team (TeamID, TeamLeadID, Name)
SELECT 
	NEWID(),
	(SELECT e.EmployeeID 
		FROM Employee e 
			inner join JobTitle jt on jt.JobTitleID = e.JobTitleID  
		WHERE e.Name = 'Taras' and jt.Name = 'Team Lead'),
	'Frontend'

INSERT INTO Team (TeamID, TeamLeadID, Name)
SELECT 
	NEWID(),
	(SELECT e.EmployeeID 
		FROM Employee e 
			inner join JobTitle jt on jt.JobTitleID = e.JobTitleID  
		WHERE e.Name = 'Halstein' and jt.Name = 'Team Lead'),
	'Backend'

INSERT INTO Team (TeamID, TeamLeadID, Name)
SELECT 
	NEWID(),
	(SELECT e.EmployeeID 
		FROM Employee e 
			inner join JobTitle jt on jt.JobTitleID = e.JobTitleID  
		WHERE e.Name = 'Zaharina' and jt.Name = 'Team Lead'),
	'QA'

INSERT INTO Team (TeamID, TeamLeadID, Name)
SELECT 
	NEWID(),
	(SELECT e.EmployeeID 
		FROM Employee e 
			inner join JobTitle jt on jt.JobTitleID = e.JobTitleID  
		WHERE e.Name = 'Luda' and jt.Name = 'Project Manager'),
	'TeamLeads'

--SELECT * FROM Team