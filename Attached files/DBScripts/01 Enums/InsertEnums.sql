USE VacationsDB

INSERT INTO [Role] VALUES (NEWID(),'Admin');
INSERT INTO [Role] VALUES (NEWID(),'TeamLead');
INSERT INTO [Role] VALUES (NEWID(),'User');

INSERT INTO JobTitle VALUES (NEWID(),'Project Manager');
INSERT INTO JobTitle VALUES (NEWID(),'Team Lead');
INSERT INTO JobTitle VALUES (NEWID(),'Employee');

INSERT INTO VacationStatus VALUES (NEWID(),'Approved');
INSERT INTO VacationStatus VALUES (NEWID(),'Denied');
INSERT INTO VacationStatus VALUES (NEWID(),'InProcess');

INSERT INTO TransactionType VALUES (NEWID(),'Add');
INSERT INTO TransactionType VALUES (NEWID(),'Remove');

INSERT INTO EmployeeStatus VALUES (NEWID(),'Active');
INSERT INTO EmployeeStatus VALUES (NEWID(),'Fired');


