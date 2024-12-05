create storedprocedure

CREATE PROCEDURE BankPayment
    @CustomerAccountID INT,
	@OrderID INT,
    @AdminAccountID INT,
    @Amount DECIMAL(10, 2),
    @PaymentMode VARCHAR(50) -- Payment mode, e.g., 'Bank Transfer', 'Cash', etc.
	@PaymentStatus
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Check if customer account has sufficient balance
        DECLARE @CustomerBalance DECIMAL(18, 2);
        SELECT @CustomerBalance = Balance
        FROM Accounts
        WHERE accountid = @CustomerAccountID;
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
 
        -- Debit amount from customer account
		
        UPDATE VsAccounts
        SET Balance = Balance - @Amount
        WHERE AccountId = @CustomerAccountID;
 
        -- Insert the transaction for debit (customer)
        INSERT INTO transactions (AccountId, Amount, TransactionDate)
        VALUES (@CustomerAccountID, -@Amount, GETDATE());
 
        --  Credit amount to admin account
		
        UPDATE VsAccounts
        SET Balance = Balance + @Amount
        WHERE AccountId = @AdminAccountID;

        -- Insert the transaction for credit (admin)
        INSERT INTO VsTransactions (AccountId, Amount, TransactionDate)
        VALUES (@AdminAccountID, @Amount, GETDATE());
		
        --  Insert a payment record (optional)
        INSERT INTO VsPayments (PaymentDate, OrderId, PaymentMode, PaymentStatus)
        VALUES (GETDATE(), @OrderID, @PaymentMode, 'Completed');

        -- Commit the transaction
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
