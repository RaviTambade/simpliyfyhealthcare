create storedprocedure
 
-- Transaction Procedure to Debit Amount using Debit Card and Netbanking
CREATE PROCEDURE BankPayment
	@CustomerAccountID INT,
	@OrderID INT,
	@AdminAccountID INT,
	@Amount DECIMAL(10, 2),
	@PaymentMode VARCHAR(50) -- Payment mode, e.g., 'Bank Transfer', 'Cash', etc.
 
CREATE PROCEDURE FundTransfer
    @CustomerAccountID INT,
    @AdminAccountID INT,
    @Amount DECIMAL(10, 2),
    @PaymentMode VARCHAR(50) -- Payment mode, e.g., 'Bank Transfer', 'Cash', etc.
 
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION;
 
    BEGIN TRY
        -- Step 1: Check if customer account has sufficient balance
        DECLARE @CustomerBalance DECIMAL(18, 2);
        
		IF (@PaymentMode='Debit' || @PaymentMode='Netbanking')
			BEGIN
				SELECT @CustomerBalance = Balance
				FROM VsAccounts
				WHERE AccountId = @CustomerAccountID;
			END
			
		ELSE
			BEGIN
				SELECT @CustomerBalance = CreditLimit
				FROM VsCards
				WHERE AccountId = @CustomerAccountID;
			END
		
        IF (@CustomerBalance IS NULL)
			BEGIN
				-- If customer account does not exist, rollback
				THROW 50000, 'Customer account not found.', 1;
			END
 
        IF (@CustomerBalance < @Amount)
			BEGIN
				-- If customer account balance is insufficient, rollback
				THROW 50000, 'Insufficient balance in customer account.', 1;
			END
 
        -- Step 2: Debit amount from customer account
		IF (@PaymentMode = 'Debit' || @PaymentMode = 'Netbanking')
			BEGIN
				UPDATE VsAccounts
				SET Balance = Balance - @Amount
				WHERE AccountId = @CustomerAccountID;
			END
		
		ELSE
			BEGIN
				UPDATE VsCards
				SET CreditLimit = CreditLimit - @Amount
				WHERE AccountId = @CustomerAccountID;
			END
		
        -- Insert the transaction for debit (customer)
        INSERT INTO transactions (AccountId, Amount, TransactionDate)
        VALUES (@CustomerAccountID, -@Amount, GETDATE());
 
        -- Step 3: Credit amount to admin account
		
        UPDATE VsAccounts
        SET Balance = Balance + @Amount
        WHERE AccountId = @AdminAccountID;
 
 
        -- Insert the transaction for credit (admin)
        INSERT INTO VsTransactions (AccountId, Amount, TransactionDate)
        VALUES (@AdminAccountID, @Amount, GETDATE());
		
		
        -- Step 4: Commit the transaction
        COMMIT TRANSACTION;
 
        -- Return success message
        SELECT 'Payment processed successfully.' AS Message;
    END TRY
	
    BEGIN CATCH
        -- If an error occurs, rollback the transaction
        ROLLBACK TRANSACTION;
 
        -- Return the error message
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;

-- Transaction Procedure to Debit Amount from Credit Card
CREATE PROCEDURE CreditPayment
    @CustomerAccountID INT,
	@OrderID INT,
    @AdminAccountID INT,
    @Amount DECIMAL(10, 2),
    @PaymentMode VARCHAR(50) -- Payment mode, e.g., 'Bank Transfer', 'Cash', etc.
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION;
 
    BEGIN TRY
        -- Step 1: Check if customer account has sufficient balance
        DECLARE @CustomerBalance DECIMAL(18, 2);
        SELECT @CustomerBalance = CreditLimit
        FROM VsCards
        WHERE AccountId = @CustomerAccountID;
        IF (@CustomerBalance IS NULL)
        BEGIN
            -- If customer account does not exist, rollback
            THROW 50000, 'Customer account not found.', 1;
        END
 
        IF (@CustomerBalance < @Amount)
        BEGIN
            -- If customer account balance is insufficient, rollback
            THROW 50000, 'Insufficient balance in customer account.', 1;
        END
 
        -- Step 2: Debit amount from customer account
		
        UPDATE VsCards
        SET CreditLimit = CreditLimit - @Amount
        WHERE AccountId = @CustomerAccountID;
 
        -- Insert the transaction for debit (customer)
        INSERT INTO transactions (AccountId, Amount, TransactionDate)
        VALUES (@CustomerAccountID, -@Amount, GETDATE());
 
        -- Step 3: Credit amount to admin account
		
        UPDATE VsAccounts
        SET Balance = Balance + @Amount
        WHERE AccountId = @AdminAccountID;
 
 
        -- Insert the transaction for credit (admin)
        INSERT INTO VsTransactions (AccountId, Amount, TransactionDate)
        VALUES (@AdminAccountID, @Amount, GETDATE());
		
		
        -- Step 4: Insert a payment record (optional)
        INSERT INTO VsPayments (PaymentDate, OrderId, PaymentMode, PaymentStatus)
        VALUES (GETDATE(), @OrderID, @PaymentMode, 'Completed');

        -- Step 5: Commit the transaction
        COMMIT TRANSACTION;
 
        -- Return success message
        SELECT 'Payment processed successfully.' AS Message;
    END TRY
	
    BEGIN CATCH
        -- If an error occurs, rollback the transaction
        ROLLBACK TRANSACTION;
 
        -- Return the error message
        SELECT ERROR_MESSAGE() AS ErrorMessage;
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
