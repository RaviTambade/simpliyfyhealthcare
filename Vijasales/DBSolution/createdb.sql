CREATE TABLE VsProducts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description VARCHAR(MAX),
    Brand VARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    Category VARCHAR(50) NOT NULL,
    LastModified DATETIME DEFAULT GETDATE(), 
    ImageUrl VARCHAR(MAX) NOT NULL
);
 
CREATE TABLE VsUsers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Address VARCHAR(255) NOT NULL,
    Role VARCHAR(50) NOT NULL,
    ContactNumber VARCHAR(10) NOT NULL UNIQUE,
	ImageUrl VARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
 
CREATE TABLE VsOrders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10, 2),
    Status VARCHAR(50),
    FOREIGN KEY (CustomerId) REFERENCES VsUsers(Id)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);
 
CREATE TABLE VsOrderItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES VsOrders(Id)
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    FOREIGN KEY (ProductId) REFERENCES VsProducts(Id)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);
 
CREATE TABLE VsShipments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ShipmentDate DATETIME NOT NULL,
    OrderId INT NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES VsOrders(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);

CREATE TABLE VsAccounts (     
    AccountId INT IDENTITY(1,1) PRIMARY KEY, 
    Pass VARCHAR(20) NOT NULL,
    UserId INT NOT NULL,     
    AccountNumber VARCHAR(20) NOT NULL, 
    BankName VARCHAR(255),    
    IFSCCode VARCHAR(20),    
    Balance DECIMAL(18,2),     
    CONSTRAINT FK_UserId FOREIGN KEY (UserId) 
    REFERENCES VsUsers(Id) ON DELETE CASCADE ON UPDATE CASCADE );

CREATE TABLE VsTransactions (     
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ToAccountId INT NOT NULL,
    FromAccountId INT NOT NULL,
    Amount DECIMAL(18,2),    
    TransactionDate DATETIME,
    TransactionId VARCHAR(50) UNIQUE,
    
    -- Foreign key constraint for ToAccountId with CASCADE actions
    CONSTRAINT FK_VsTransactions_ToAccountId FOREIGN KEY (ToAccountId)
    REFERENCES VsAccounts(AccountId)
    ON DELETE CASCADE 
    ON UPDATE CASCADE,
    
    -- Foreign key constraint for FromAccountId with no CASCADE actions
    CONSTRAINT FK_VsTransactions_FromAccountId FOREIGN KEY (FromAccountId)
    REFERENCES VsAccounts(AccountId)
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
);

CREATE TABLE VsCards (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Pass VARCHAR(20) NOT NULL,
    CVV VARCHAR(50) NOT NULL UNIQUE,
    AccountId VARCHAR(255) NOT NULL,
    CardType VARCHAR(100) CHECK(CardType IN ('Credit Card', 'Debit Card')) NOT NULL,
    CreditLimit DECIMAL(18, 2),  -- Changed precision to 18,2 for typical credit limit values
    CardNumber VARCHAR(MAX) NOT NULL,
    ExpiryDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE VsPayments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentAmount DECIMAL(10, 2) NOT NULL,
    PaymentMode VARCHAR(50) NOT NULL,
    PaymentStatus VARCHAR(50) NOT NULL DEFAULT 'Pending',
	TransactionId VARCHAR(20) UNIQUE,
    FOREIGN KEY (OrderId) REFERENCES VsOrders(Id)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);
CREATE TABLE VsReviews (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    UserId INT NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    ReviewText VARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProductId) REFERENCES VsProducts(Id)
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    FOREIGN KEY (UserId) REFERENCES VsUsers(Id)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);

CREATE TABLE VsPriceChanges (
    Id INT Identity(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    OldPrice DECIMAL(10, 2) NOT NULL,
    NewPrice DECIMAL(10, 2) NOT NULL,
    ChangeDate DATETIME NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES VsProducts(Id)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);

