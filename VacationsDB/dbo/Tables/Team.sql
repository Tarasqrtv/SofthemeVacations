CREATE TABLE [dbo].[Team] (
    [TeamID]     UNIQUEIDENTIFIER NOT NULL,
    [TeamLeadID] UNIQUEIDENTIFIER NULL,
    [Name]       NVARCHAR (100)   NULL,
    PRIMARY KEY CLUSTERED ([TeamID] ASC),
    CONSTRAINT [Team_TeamLeadID_FK] FOREIGN KEY ([TeamLeadID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);

