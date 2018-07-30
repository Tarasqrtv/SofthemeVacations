CREATE TABLE [dbo].[Team] (
    [TeamID]     UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [TeamLeadID] UNIQUEIDENTIFIER NULL,
    [Name]       NVARCHAR (100)   NULL,
    CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED ([TeamID] ASC),
    CONSTRAINT [Team_TeamLeadID_FK] FOREIGN KEY ([TeamLeadID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Team_TeamLeadID]
    ON [dbo].[Team]([TeamLeadID] ASC);

