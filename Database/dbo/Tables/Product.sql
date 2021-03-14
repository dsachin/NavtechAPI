CREATE TABLE [dbo].[Product] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50)  NOT NULL,
    [Details]       VARCHAR (500) NOT NULL,
    [Price]         FLOAT (53)    NOT NULL,
    [StockQuantity] FLOAT (53)    NOT NULL,
    [Status]        INT           CONSTRAINT [DF_Product_Status] DEFAULT ((1)) NOT NULL,
    [CreatedDate]   DATETIME      NOT NULL,
    [ModifiedDate]  DATETIME      NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

