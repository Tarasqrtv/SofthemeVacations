INSERT INTO Vacation(VacationID, StartVocationDate, EndVocationDate, VacationStatusID, Ñomment, EmployeeID)
SELECT 
	NEWID(),
	GETDATE(),
	GETDATE() + 10,
	(SELECT VacationStatusID FROM VacationStatus WHERE Name = 'Approved'),
	'Vacation',
	(SELECT EmployeeID FROM Employee WHERE Name = 'Chaggai')

INSERT INTO Vacation(VacationID, StartVocationDate, EndVocationDate, VacationStatusID, Ñomment, EmployeeID)
SELECT 
	NEWID(),
	GETDATE() + 30,
	GETDATE() + 40,
	(SELECT VacationStatusID FROM VacationStatus WHERE Name = 'Denied'),
	'Vacation',
	(SELECT EmployeeID FROM Employee WHERE Name = 'Chaggai')

INSERT INTO Vacation(VacationID, StartVocationDate, EndVocationDate, VacationStatusID, Ñomment, EmployeeID)
SELECT 
	NEWID(),
	GETDATE() - 60,
	GETDATE() - 50,
	(SELECT VacationStatusID FROM VacationStatus WHERE Name = 'Approved'),
	'Vacation',
	(SELECT EmployeeID FROM Employee WHERE Name = 'Chaggai')

INSERT INTO Vacation(VacationID, StartVocationDate, EndVocationDate, VacationStatusID, Ñomment, EmployeeID)
SELECT 
	NEWID(),
	GETDATE() - 160,
	GETDATE() - 150,
	(SELECT VacationStatusID FROM VacationStatus WHERE Name = 'Denied'),
	'Vacation',
	(SELECT EmployeeID FROM Employee WHERE Name = 'Chaggai')

INSERT INTO Vacation(VacationID, StartVocationDate, EndVocationDate, VacationStatusID, Ñomment, EmployeeID)
SELECT 
	NEWID(),
	GETDATE() - 260,
	GETDATE() - 250,
	(SELECT VacationStatusID FROM VacationStatus WHERE Name = 'Approved'),
	'Vacation',
	(SELECT EmployeeID FROM Employee WHERE Name = 'Chaggai')

INSERT INTO Vacation(VacationID, StartVocationDate, EndVocationDate, VacationStatusID, Ñomment, EmployeeID)
SELECT 
	NEWID(),
	GETDATE() + 100,
	GETDATE() + 110,
	(SELECT VacationStatusID FROM VacationStatus WHERE Name = 'Approved'),
	'Vacation',
	(SELECT EmployeeID FROM Employee WHERE Name = 'Chaggai')