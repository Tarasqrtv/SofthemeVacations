CREATE TABLE [dbo].[VacationStatus] (
    [VacationStatusID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]             NVARCHAR (50)    NULL,
    CONSTRAINT [PK_VacationStatus] PRIMARY KEY CLUSTERED ([VacationStatusID] ASC)
);

