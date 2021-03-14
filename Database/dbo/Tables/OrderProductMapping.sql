CREATE TABLE [dbo].[OrderProductMapping] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [OrderId]      INT      NOT NULL,
    [ProductId]    INT      NOT NULL,
    [Quantity]     INT      NOT NULL,
    [CreatedDate]  DATETIME NOT NULL,
    [ModifiedDate] DATETIME NOT NULL,
    [Status]       INT      CONSTRAINT [DF_OrderProductMapping_Status] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_OrderProductMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderProductMapping_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderProductMapping_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

