CREATE TABLE [dbo].[TransactionType] (
    [TransactionTypeID] UNIQUEIDENTIFIER NOT NULL,
    [Name]              NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([TransactionTypeID] ASC)
);

