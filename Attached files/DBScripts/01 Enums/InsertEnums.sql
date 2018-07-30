USE VacationsDB

INSERT INTO AspNetRoles VALUES ('Admin');
INSERT INTO AspNetRoles VALUES ('TeamLead');
INSERT INTO AspNetRoles VALUES ('User');

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


