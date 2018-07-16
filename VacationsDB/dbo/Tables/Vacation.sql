CREATE TABLE [dbo].[Vacation] (
    [VacationID]        UNIQUEIDENTIFIER NOT NULL,
    [StartVocationDate] DATE             NULL,
    [EndVocationDate]   DATE             NULL,
    [VacationStatusID]  UNIQUEIDENTIFIER NULL,
    [Сomment]           NVARCHAR (200)   NULL,
    [EmployeeID]        UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([VacationID] ASC),
    CONSTRAINT [Vacation_EmployeeID_FK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [Vacation_VacationStatusID_FK] FOREIGN KEY ([VacationStatusID]) REFERENCES [dbo].[VacationStatus] ([VacationStatusID])
);

