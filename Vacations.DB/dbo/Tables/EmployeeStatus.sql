CREATE TABLE [dbo].[EmployeeStatus] (
    [EmployeeStatusID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]             NVARCHAR (50)    NULL,
    CONSTRAINT [PK_EmployeeStatus] PRIMARY KEY CLUSTERED ([EmployeeStatusID] ASC)
);

