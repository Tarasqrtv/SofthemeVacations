CREATE TABLE [dbo].[EmployeeTeam] (
    [EmployeeID] UNIQUEIDENTIFIER NULL,
    [TeamID]     UNIQUEIDENTIFIER NULL,
    CONSTRAINT [EmployeeTeam_EmployeeID_FK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [EmployeeTeam_TeamID_FK] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Team] ([TeamID]),
    CONSTRAINT [EmployeeTeam_EmployeeID_TeamID_Unique] UNIQUE NONCLUSTERED ([EmployeeID] ASC, [TeamID] ASC)
);

