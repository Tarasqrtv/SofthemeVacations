﻿Create database Vacations

use Vacations

Create Table Team
(
	TeamID uniqueidentifier Primary key,
	Name nvarchar
);

Create table [User]
(
	UserID uniqueidentifier Primary key,
	Name nvarchar,
	Surname nvarchar,
	Birthday date,
	PersonalEmail nvarchar, 
	WorkEmail nvarchar, 
	TelephoneNumber nvarchar,
	Skype nvarchar,
	StartDate date,
	Status bit,
	EndDate date,
	TeamID uniqueidentifier references Team(TeamID)
);

Alter table Team
ADD TeamLeadID uniqueidentifier,
FOREIGN KEY (TeamLeadID) REFERENCES [User](UserID)

Create table Vacation
(
	VacationID uniqueidentifier Primary key,
	StartVocationDate date,
	EndVocationDate date,
	Status nvarchar,
	Сomment nvarchar,
	UserID uniqueidentifier references [User](UserID)
);