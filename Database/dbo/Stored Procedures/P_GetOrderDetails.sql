-- =============================================
-- Author:		Sachin D
-- Create date: 14 March 2021
-- Description: Ger Order Details
-- Unit Level Testing : 

--exec [P_GetOrderDetails] @Page=1,@Size=2,@sort=desc
-- =============================================

CREATE PROCEDURE [P_GetOrderDetails]
 @Page INT,
 @Size INT,
 @sort nvarchar(50) 
-- @totalrow INT  OUTPUT
AS
BEGIN
    DECLARE @Offset INT
    DECLARE @Newsize INT
    DECLARE @SqlQuery NVARCHAR(MAX)

    IF(@Page=0)
      BEGIN
        SET @Offset = @Page
        SET @Newsize = @Size
       END
    ELSE 
      BEGIN
        SET @Offset = @Page*@Size
        SET @Newsize = @Size-1
      END
    SET NOCOUNT ON
    SET @SqlQuery = '
     WITH OrderedSet AS
    (
      select o.Id,O.Amount as AmountPaid,cd.Name as CustomerName,cd.Email,os.Status as OrderStatus,pt.Type as PaymentType,ROW_NUMBER() OVER (ORDER BY o.Id ' + @sort + ') AS ''Index'' from [OrderManagement].[dbo].[Order] o join CustomerDetails cd on o.CustomerId=cd.Id 
join  OrderStatus os on os.Id=o.OrderStatusId join PaymentType pt on pt.Id =o.PaymentTypeId 
    )
	
   SELECT * FROM OrderedSet WHERE [Index] BETWEEN ' + CONVERT(NVARCHAR(12), @Offset) + ' AND ' + CONVERT(NVARCHAR(12), (@Offset + @Newsize)) 
   
   EXECUTE (@SqlQuery)
END
