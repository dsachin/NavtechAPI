

-- =============================================
-- Author:		Sachin D
-- Create date: 14 March 2021
-- Description: Insert order data and update stock quantity.
-- Unit Level Testing : 

--declare @p1 dbo.OrderProducts
--insert into @p1 values(1,1,50,GETDATE(),GETDATE())
--insert into @p1 values(2,2,20,GETDATE(),GETDATE())

--exec P_InsertOrderDetails @OrderProductsMapping=@p1,@CustomerId=2,@OrderStatusId=1,@Amount=570,@PaymentTypeId=1
-- =============================================

CREATE PROCEDURE [dbo].[P_InsertOrderDetails]
( 
	@OrderProductsMapping OrderProducts readonly,
	@CustomerId		int,
	@OrderStatusId	int,
	@Amount			int,
	@PaymentTypeId	int
)


AS
BEGIN --1
    DECLARE 
    @IsRun			bit =0,
    @CurrentDate	DateTime=getdate() , 
    @ErrorMessage	nvarchar(2000),
	@ErrorCode INT=0 ,

	@OrderId int,
	@InActiveStatusId		INT =4,
    @IsCustomerExists bit,
	@IsOrderStatusExists bit,
    @IsPaymentTypeExists bit,
	@IsValidationsPassed bit=1


	If Not Exists(select 1 from CustomerDetails where Id=@CustomerId and Status<>@InActiveStatusId)
	Begin 
		SET @ErrorMessage ='Customer does not Exist.'
		Set @ErrorCode=201
		SET @IsValidationsPassed=0
		SELECT @IsRun Result ,@ErrorMessage ErrorMessage,@ErrorCode ErrorCode
		RETURN
	End

	If Not Exists(select 1 from OrderStatus where Id=@OrderStatusId)
	Begin 
		SET @ErrorMessage ='Order Status is invalid.'
		Set @ErrorCode=202
		SET @IsValidationsPassed=0
		SELECT @IsRun Result ,@ErrorMessage ErrorMessage,@ErrorCode ErrorCode
		RETURN
	End


	If Not Exists(select 1 from PaymentType where Id=@PaymentTypeId )
	Begin 
		SET @ErrorMessage ='Payment Type is invalid.'
		Set @ErrorCode=203
		SET @IsValidationsPassed=0
		SELECT @IsRun Result ,@ErrorMessage ErrorMessage,@ErrorCode ErrorCode
		RETURN
	End


			-- Cursor Begin For Product Detail Iteration.
	DECLARE 
	@ProductCursor CURSOR,
	@ProductId	int,
	@Quantity	int,
	@RemainingStock int=0,
	@CurrentStock int

BEGIN
    SET @ProductCursor = CURSOR FOR
    select ProductId,Quantity  from @OrderProductsMapping    
    OPEN @ProductCursor 
    FETCH NEXT FROM @ProductCursor 
    INTO  @ProductId,@Quantity

    WHILE @@FETCH_STATUS = 0
    BEGIN
		
	If Not Exists(select 1 from Product where Id=@ProductId and Status<>@InActiveStatusId)
		Begin 
			SET @ErrorMessage ='Product does not Exist.'
			Set @ErrorCode=204
			SET @IsValidationsPassed=0
			SELECT @IsRun Result ,@ErrorMessage ErrorMessage,@ErrorCode ErrorCode
			RETURN
		End
	Else If Exists(Select 1 from Product where Id=@ProductId and StockQuantity>=@Quantity and Status!=@InActiveStatusId)
		Begin
				Select @CurrentStock= StockQuantity from Product where Id=@ProductId and StockQuantity>@Quantity and Status!=@InActiveStatusId
				Set @RemainingStock=@CurrentStock - @Quantity;

				Update Product Set StockQuantity=@RemainingStock where Id=@ProductId

	End
	Else		
		Begin
				SET @ErrorMessage ='Product is either out of stock or the order quantity cannnot be fulfilled.'
				SET @IsValidationsPassed=0
				Set @ErrorCode=205
				RETURN
		End

      FETCH NEXT FROM @ProductCursor 
      INTO  @ProductId,@Quantity
    END; 

    CLOSE @ProductCursor ;
    DEALLOCATE @ProductCursor;
END;

	IF @IsValidationsPassed=1
	Begin

		BEGIN TRANSACTION 
		BEGIN TRY
    
			Insert into  [OrderManagement].[dbo].[Order] (CustomerId,Amount,OrderStatusId,PaymentTypeId,CreatedDate,ModifiedDate,Status)
			Values (@CustomerId,@Amount,@OrderStatusId,@PaymentTypeId,@CurrentDate,@CurrentDate,1)

	
	       Select top  1 @OrderId =Id from  [OrderManagement].[dbo].[Order] where CustomerId=@CustomerId and Status!= @InActiveStatusId order by id desc
	       
		   Insert into OrderProductMapping select @OrderId,[ProductId],[Quantity],@CurrentDate,@CurrentDate,1 from @OrderProductsMapping  

		   SET @IsRun='True'; 
			COMMIT TRANSACTION  
 
		END TRY

		BEGIN CATCH
		    
			SET @ErrorMessage ='The following error has occurred:  ' + ERROR_MESSAGE()
			Set @ErrorCode=210 -- ExceptionErrorCode
			ROLLBACK TRANSACTION 	
				
		END CATCH 
	
	End 
END

 SELECT @IsRun Result ,@ErrorMessage ErrorMessage,@ErrorCode ErrorCode