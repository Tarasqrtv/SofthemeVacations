CREATE TABLE [dbo].[User] (
    [UserID]        UNIQUEIDENTIFIER NOT NULL,
    [EmployeeID]    UNIQUEIDENTIFIER NULL,
    [Password]      NVARCHAR (300)   NULL,
    [PersonalEmail] NVARCHAR (256)   NOT NULL,
    [RoleID]        UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [User_EmployeeID_FK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [User_RoleID_FK] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID]),
    UNIQUE NONCLUSTERED ([EmployeeID] ASC)
);

