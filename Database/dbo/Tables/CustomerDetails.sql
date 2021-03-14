CREATE TABLE [dbo].[CustomerDetails] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL,
    [Mobile]       NVARCHAR (50)  NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NOT NULL,
    [Status]       INT            CONSTRAINT [DF_CustomerDetails_StatusId] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [Customer] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [EmailAlreadyExist_Customer] UNIQUE NONCLUSTERED ([Email] ASC) WITH (FILLFACTOR = 90)
);

