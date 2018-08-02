CREATE TABLE [dbo].[Employee] (
    [EmployeeID]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]             NVARCHAR (50)    NOT NULL,
    [Surname]          NVARCHAR (50)    NOT NULL,
    [Birthday]         DATE             NULL,
    [WorkEmail]        NVARCHAR (256)   NOT NULL,
    [PersonalEmail]    NVARCHAR (256)   NULL,
    [TelephoneNumber]  NVARCHAR (20)    NULL,
    [Skype]            NVARCHAR (50)    NULL,
    [StartDate]        DATE             NOT NULL,
    [EndDate]          DATE             NULL,
    [EmployeeStatusID] UNIQUEIDENTIFIER NULL,
    [JobTitleID]       UNIQUEIDENTIFIER NULL,
    [TeamID]           UNIQUEIDENTIFIER NULL,
    [Balance]          INT              NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [Employee_EmployeeStatusID_FK] FOREIGN KEY ([EmployeeStatusID]) REFERENCES [dbo].[EmployeeStatus] ([EmployeeStatusID]),
    CONSTRAINT [Employee_JobTitleID_FK] FOREIGN KEY ([JobTitleID]) REFERENCES [dbo].[JobTitle] ([JobTitleID]),
    CONSTRAINT [Employee_TeamID_FK] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Team] ([TeamID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_EmployeeStatusID]
    ON [dbo].[Employee]([EmployeeStatusID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_JobTitleID]
    ON [dbo].[Employee]([JobTitleID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_TeamID]
    ON [dbo].[Employee]([TeamID] ASC);

