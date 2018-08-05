CREATE TABLE [dbo].[Transaction] (
    [TransactionID]     UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [TransactionTypeID] UNIQUEIDENTIFIER NOT NULL,
    [EmployeeID]        UNIQUEIDENTIFIER NOT NULL,
    [Days]              INT              NOT NULL,
    [Comment]           NVARCHAR (200)   NULL,
    [AuthorID] UNIQUEIDENTIFIER NULL, 
    [VacationID] UNIQUEIDENTIFIER NULL, 
    [TransactionDate] DATETIME NOT NULL, 
    CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [Transaction_EmployeeID_FK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [Transaction_TransactionTypeID_FK] FOREIGN KEY ([TransactionTypeID]) REFERENCES [dbo].[TransactionType] ([TransactionTypeID]),
	CONSTRAINT [Transaction_AuthorID_FK] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
	CONSTRAINT [Transaction_VacationID_FK] FOREIGN KEY ([VacationID]) REFERENCES [dbo].[Vacation] ([VacationID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Transaction_EmployeeID]
    ON [dbo].[Transaction]([EmployeeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Transaction_TransactionTypeID]
    ON [dbo].[Transaction]([TransactionTypeID] ASC);

