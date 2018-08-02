CREATE TABLE [dbo].[Vacation] (
    [VacationID]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [StartVocationDate] DATE             NOT NULL,
    [EndVocationDate]   DATE             NOT NULL,
    [VacationStatusID]  UNIQUEIDENTIFIER NOT NULL,
    [Comment]           NVARCHAR (200)   NULL,
    [EmployeeID]        UNIQUEIDENTIFIER NOT NULL,
    [VacationTypesID] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Vacation] PRIMARY KEY CLUSTERED ([VacationID] ASC),
    CONSTRAINT [Vacation_EmployeeID_FK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [Vacation_VacationStatusID_FK] FOREIGN KEY ([VacationStatusID]) REFERENCES [dbo].[VacationStatus] ([VacationStatusID]), 
    CONSTRAINT [Vacations_VacationTypesID_FK] FOREIGN KEY ([VacationTypesID]) REFERENCES [dbo].[VacationTypes]([VacationTypesID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Vacation_EmployeeID]
    ON [dbo].[Vacation]([EmployeeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vacation_VacationStatusID]
    ON [dbo].[Vacation]([VacationStatusID] ASC);

