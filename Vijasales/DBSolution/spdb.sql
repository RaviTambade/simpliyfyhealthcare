create storedprocedure
<<<<<<< HEAD
-- Transaction Procedure to Debit Amount using Debit Card and Netbanking
CREATE PROCEDURE BankPayment
	@CustomerAccountID INT,
	@OrderID INT,
	@AdminAccountID INT,
	@Amount DECIMAL(10, 2),
	@PaymentMode VARCHAR(50) -- Payment mode, e.g., 'Bank Transfer', 'Cash', etc.
=======
CREATE PROCEDURE FundTransfer
    @CustomerAccountID INT,
    @AdminAccountID INT,
    @Amount DECIMAL(10, 2),
    @PaymentMode VARCHAR(50) -- Payment mode, e.g., 'Bank Transfer', 'Cash', etc.
>>>>>>> b0c17e237b863f7216a7b86c16fa089738de0f31
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
