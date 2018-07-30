CREATE TABLE [dbo].[TransactionType] (
    [TransactionTypeID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]              NVARCHAR (50)    NULL,
    CONSTRAINT [PK_TransactionType] PRIMARY KEY CLUSTERED ([TransactionTypeID] ASC)
);

