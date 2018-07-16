--Backend
delete EmployeeTeam
--Team Lead
INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Halstein'),
	(SELECT TeamID FROM Team WHERE Name = 'Backend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Alex'),
	(SELECT TeamID FROM Team WHERE Name = 'Backend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Charles'),
	(SELECT TeamID FROM Team WHERE Name = 'Backend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Beryl'),
	(SELECT TeamID FROM Team WHERE Name = 'Backend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Vesna'),
	(SELECT TeamID FROM Team WHERE Name = 'Backend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Turid'),
	(SELECT TeamID FROM Team WHERE Name = 'Backend')

--Frontend

--Team Lead
INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Taras'),
	(SELECT TeamID FROM Team WHERE Name = 'Frontend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Chaggai'),
	(SELECT TeamID FROM Team WHERE Name = 'Frontend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Alfhild'),
	(SELECT TeamID FROM Team WHERE Name = 'Frontend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Ram'),
	(SELECT TeamID FROM Team WHERE Name = 'Frontend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Ezequiel'),
	(SELECT TeamID FROM Team WHERE Name = 'Frontend')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Sherrie'),
	(SELECT TeamID FROM Team WHERE Name = 'Frontend')

--QA
--Team Lead
INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Zaharina'),
	(SELECT TeamID FROM Team WHERE Name = 'QA')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Hemming'),
	(SELECT TeamID FROM Team WHERE Name = 'QA')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Zivit'),
	(SELECT TeamID FROM Team WHERE Name = 'QA')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Jonathan'),
	(SELECT TeamID FROM Team WHERE Name = 'QA')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Basmat'),
	(SELECT TeamID FROM Team WHERE Name = 'QA')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Perle'),
	(SELECT TeamID FROM Team WHERE Name = 'QA')



--SELECT * FROM Employee

--TeamLeads
--Project Manager
INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Luda'),
	(SELECT TeamID FROM Team WHERE Name = 'TeamLeads')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Zaharina'),
	(SELECT TeamID FROM Team WHERE Name = 'TeamLeads')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Halstein'),
	(SELECT TeamID FROM Team WHERE Name = 'TeamLeads')

INSERT INTO EmployeeTeam (EmployeeID, TeamID)
SELECT 
	(SELECT EmployeeID FROM Employee WHERE Name = 'Taras'),
	(SELECT TeamID FROM Team WHERE Name = 'TeamLeads')

--Select * From EmployeeTeam
--Order by TeamID