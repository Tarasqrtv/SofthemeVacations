CREATE TABLE [dbo].[JobTitle] (
    [JobTitleID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]       NVARCHAR (50)    NULL,
    CONSTRAINT [PK_JobTitle] PRIMARY KEY CLUSTERED ([JobTitleID] ASC)
);

