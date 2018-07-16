CREATE TABLE [dbo].[Transaction] (
    [TransactionID]     UNIQUEIDENTIFIER NOT NULL,
    [TransactionTypeID] UNIQUEIDENTIFIER NULL,
    [EmployeeID]        UNIQUEIDENTIFIER NULL,
    [Days]              INT              NULL,
    [Сomment]           NVARCHAR (200)   NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [Transaction_EmployeeID_FK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [Transaction_TransactionTypeID_FK] FOREIGN KEY ([TransactionTypeID]) REFERENCES [dbo].[TransactionType] ([TransactionTypeID])
);

