create storedprocedure
 
CREATE PROCEDURE [dbo].[VsFundTransfer]
    @ToAccountNumber VARCHAR(20),
    @FromAccountNumber VARCHAR(20),
    @Amount DECIMAL(10, 2),
    @PaymentMode VARCHAR(50), -- Payment mode, e.g., 'Bank Transfer', 'Cash', etc.
    @TransactionId VARCHAR(20) OUTPUT,  -- Add an output parameter for the Transaction ID
    @Status VARCHAR(50) OUTPUT         -- Add an output parameter for the Status (Success/Failed)
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Generate unique transaction ID in the format "YYYYMMDDHHMM"
        DECLARE @Transaction VARCHAR(20) = CONVERT(VARCHAR, GETDATE(), 112) + RIGHT('00' + CAST(DATEPART(HOUR, GETDATE()) AS VARCHAR(2)), 2) + RIGHT('00' + CAST(DATEPART(MINUTE, GETDATE()) AS VARCHAR(2)), 2);
        -- Set the output parameters
        SET @TransactionId = @Transaction;  -- Set the TransactionId output parameter
        -- Step 1: Check if customer account has sufficient balance
        DECLARE @CustomerBalance DECIMAL(18, 2);
        PRINT 'Payment Mode: ' + @PaymentMode;
        IF (@PaymentMode = 'Debit Card' OR @PaymentMode = 'Netbanking')
        BEGIN
            SELECT @CustomerBalance = Balance
            FROM VsAccounts
            WHERE AccountNumber = @FromAccountNumber;
            PRINT 'Balance in account: ' + CAST(@CustomerBalance AS VARCHAR);
        END
        ELSE IF (@PaymentMode = 'Credit Card')
        BEGIN
            SELECT @CustomerBalance = CreditLimit
            FROM VsCards
            WHERE AccountNumber = @FromAccountNumber;
            PRINT 'Credit Limit in account: ' + CAST(@CustomerBalance AS VARCHAR);
        END
        ELSE
        BEGIN
            SET @Status = 'Failed'; -- Invalid payment mode
            ROLLBACK TRANSACTION;
            PRINT 'Invalid payment mode.';
            RETURN;
        END
        -- Check if customer balance is NULL
        IF (@CustomerBalance IS NULL)
        BEGIN
            SET @Status = 'Failed'; -- No balance found
            ROLLBACK TRANSACTION;
            PRINT 'No balance found for account.';
            RETURN;
        END
        -- Check if customer balance is less than the required amount
        IF (@CustomerBalance < @Amount)
        BEGIN
            SET @Status = 'Failed'; -- Insufficient funds
            ROLLBACK TRANSACTION;
            PRINT 'Insufficient funds.';
            RETURN;
        END
        -- Step 2: Debit amount from customer account
        IF (@PaymentMode = 'Debit Card' OR @PaymentMode = 'Netbanking')
        BEGIN
            UPDATE VsAccounts
            SET Balance = Balance - @Amount
            WHERE AccountNumber = @FromAccountNumber;
            PRINT 'Debit amount: ' + CAST(@Amount AS VARCHAR);
        END
        ELSE IF (@PaymentMode = 'Credit Card')
        BEGIN
            UPDATE VsCards
            SET CreditLimit = CreditLimit - @Amount
            WHERE AccountNumber = @FromAccountNumber AND CardType = @PaymentMode;
            PRINT 'Debit amount from credit card: ' + CAST(@Amount AS VARCHAR);
        END
        -- Step 3: Credit amount to the recipient account
        UPDATE VsAccounts
        SET Balance = Balance + @Amount
        WHERE AccountNumber = @ToAccountNumber;
        PRINT 'Credit amount to recipient: ' + CAST(@Amount AS VARCHAR);
        -- Insert the transaction record
        INSERT INTO VsTransactions (ToAccountId, FromAccountId, Amount, TransactionDate, TransactionId)
        VALUES (@ToAccountNumber, @FromAccountNumber, @Amount, GETDATE(), @TransactionId);
        PRINT 'Transaction inserted: ' + @TransactionId;
        -- Step 4: Commit the transaction
        COMMIT TRANSACTION;
        -- Set the status to Success
        SET @Status = 'Success';
        PRINT 'Transaction successful.';
    END TRY
    BEGIN CATCH
        -- If an error occurs, rollback the transaction
        ROLLBACK TRANSACTION;
        -- Set the status to Failed
        SET @Status = 'Failed';
        PRINT 'Error occurred: ' + ERROR_MESSAGE();
    END CATCH
END;

-- Getting customer order details 
CREATE PROCEDURE VsGetCurrentOrderDetails
    @order_id INT
AS
BEGIN
    SELECT 
        o.Id AS OrderId,
        (u.FirstName + ' ' + u.LastName) AS Name,
        p.Brand AS Brand,
        p.Title AS Title,
        t.Quantity AS Quantity,
        p.Price AS Price,
        (t.Quantity * p.Price) AS TotalPrice,
        o.OrderDate AS OrderDate,
        o.Status AS OrderStatus
    FROM 
        VsProducts p
        INNER JOIN VsOrderItems t ON p.Id = t.ProductId
        INNER JOIN VsOrders o ON o.Id = t.OrderId
        INNER JOIN VsUsers u ON u.Id = o.CustomerId
    WHERE 
        o.Id = @order_id;
END;

-- Getting ShipmentDetails

CREATE PROCEDURE [dbo].[GetShipmentDetails]
    @ShipmentId INT = NULL,
    @CustomerId INT = NULL,
    @OrderId INT = NULL
AS
BEGIN
    SELECT 
		s.Id AS ShipmentId,
        u.FirstName + ' ' + u.LastName AS CustomerName,
        u.Address AS CustomerAddress,
		o.Id AS OrderId,
        o.TotalAmount,
        s.ShipmentDate AS DeliveryDate,
        s.Status AS DeliveryStatus
    FROM 
        VsShipments s
    JOIN 
        VsOrders o ON s.OrderId = o.Id
    JOIN 
        VsUsers u ON o.CustomerId = u.Id
    WHERE
        (@ShipmentId IS NULL OR s.Id = @ShipmentId) AND
        (@CustomerId IS NULL OR o.CustomerId = @CustomerId) AND
        (@OrderId IS NULL OR o.Id = @OrderId);
END
