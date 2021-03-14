CREATE TABLE [dbo].[Order] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [CustomerId]    INT        NOT NULL,
    [Amount]        FLOAT (53) NOT NULL,
    [OrderStatusId] INT        NOT NULL,
    [PaymentTypeId] INT        NOT NULL,
    [CreatedDate]   DATETIME   NOT NULL,
    [ModifiedDate]  DATETIME   NOT NULL,
    [Status]        INT        CONSTRAINT [DF_Order_Status] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_CustomerDetails] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[CustomerDetails] ([Id]),
    CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus] ([Id]),
    CONSTRAINT [FK_Order_PaymentType] FOREIGN KEY ([PaymentTypeId]) REFERENCES [dbo].[PaymentType] ([Id])
);

