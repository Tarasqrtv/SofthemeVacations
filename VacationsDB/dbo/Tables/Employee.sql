CREATE TABLE [dbo].[Employee] (
    [EmployeeID]       UNIQUEIDENTIFIER NOT NULL,
    [Name]             NVARCHAR (50)    NULL,
    [Surname]          NVARCHAR (50)    NULL,
    [WorkEmail]        NVARCHAR (256)   NULL,
    [TelephoneNumber]  NVARCHAR (20)    NULL,
    [Birthday]         DATE             NULL,
    [Skype]            NVARCHAR (50)    NULL,
    [StartDate]        DATE             NULL,
    [EmployeeStatusID] UNIQUEIDENTIFIER NULL,
    [EndDate]          DATE             NULL,
    [JobTitleID]       UNIQUEIDENTIFIER NULL,
    [Balance]          INT              NULL,
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [Employee_EmployeeStatusID_FK] FOREIGN KEY ([EmployeeStatusID]) REFERENCES [dbo].[EmployeeStatus] ([EmployeeStatusID]),
    CONSTRAINT [Employee_JobTitleID_FK] FOREIGN KEY ([JobTitleID]) REFERENCES [dbo].[JobTitle] ([JobTitleID])
);

