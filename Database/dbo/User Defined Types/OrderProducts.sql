CREATE TYPE [dbo].[OrderProducts] AS TABLE (
    [OrderId]      INT      NULL,
    [ProductId]    INT      NULL,
    [Quantity]     INT      NULL,
    [ModifiedDate] DATETIME NULL,
    [CreatedDate]  DATETIME NULL);

