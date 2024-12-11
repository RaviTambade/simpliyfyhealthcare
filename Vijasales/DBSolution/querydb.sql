
------ Products Queries ------

-- 1. Retrieve All Products
SELECT * FROM VsProducts;

-- 2. Retrieve Product of specific id
SELECT * FROM VsProducts WHERE Id = 22;

-- 3. Insert a new product
INSERT INTO VsProducts (Title, Description, Brand, Price, Stock, Category, ImageUrl) 
VALUES ('Samsung Galaxy 20', 'Latest model with high-resolution camera', 'Samsung', 10900, 1000, 'SmartPhone', '/images/products/smartphones/galaxy_M05.jpg');

-- 4. Update product details for specific Id
UPDATE VsProducts
SET 
    Title = 'Samsung Galaxy 20',
    Stock = 1000,
    Price = 10900,
    Description = 'Latest model with high-resolution camera',
    Category = 'SmartPhone',
    ImageUrl = '/images/products/smartphones/galaxy_M05.jpg',
    Brand = 'Samsung'
WHERE Id = 1;

-- 5. Delete product by Id
DELETE FROM VsProducts WHERE Id = 45;

-- 6. Retrieve products by Category
SELECT * FROM VsProducts WHERE Category = 'Smartphone';

-- 7. Retrieve products by Brand
SELECT * FROM VsProducts WHERE Brand = 'Samsung';

-- 8. Retrieve products by Category and Brand
SELECT * FROM VsProducts WHERE Category = 'TV' AND Brand = 'Vu';


---9. Trigger for price changes
CREATE TRIGGER after_product_priceupdate
ON VsProducts
AFTER UPDATE
AS
BEGIN
    -- Insert a record into the VsPriceChanges table
    INSERT INTO VsPriceChanges (ProductId, OldPrice, NewPrice, ChangeDate)
    SELECT d.id, d.price, i.price, GETDATE()
    FROM deleted d
    JOIN inserted i ON d.id = i.id
    WHERE d.price <> i.price;
END;
GO  -- This is required to separate the trigger creation from other SQL statements



----------------- ORDERS AND OREDRSITEMS QUERIES ---------------
-- 1. Retrieve Users with More Than One Order
SELECT u.id, u.FirstName, COUNT(o.id) AS order_count
FROM VsUsers u
JOIN VsOrders o ON u.id = o.customerid
GROUP BY u.id, u.FirstName
HAVING COUNT(o.id) > 0;

-- 2. Calculate Total Sales for a Given Month
SELECT SUM(oi.quantity * p.price) AS total_sales
FROM VsOrders o
JOIN VsOrderItems oi ON o.id = oi.OrderId
JOIN VsProducts p ON oi.ProductId = p.Id
WHERE YEAR(o.OrderDate) = 2024 AND MONTH(o.OrderDate) = 11;

-- 3. Retrieve a User's Order History
SELECT o.id AS order_id, o.TotalAmount, o.TotalAmount, oi.Id, p.Title AS product_name, oi.quantity
FROM VsOrders o
JOIN VsOrderItems oi ON o.id = oi.OrderId
JOIN VsProducts p ON oi.ProductId = p.Id
WHERE o.CustomerId = 3; 

-- 4. Retrieve Orders Placed Within a Specific Date Range
SELECT id, OrderDate, TotalAmount
FROM VsOrders
WHERE OrderDate BETWEEN '2024-11-01' AND '2024-12-01' 
order by OrderDate desc;

-- 5. Retrieve Monthly Sales Report
SELECT p.Title AS product_name, SUM(oi.quantity) AS total_quantity_sold, SUM(oi.quantity * p.price) AS total_sales
FROM VsOrders o
JOIN VsOrderItems oi ON o.id = oi.OrderId
JOIN VsProducts p ON oi.ProductId = p.Id
WHERE YEAR(o.OrderDate) = 2024 AND MONTH(o.OrderDate) = 12 
GROUP BY p.id, p.Title;

-- 6. Get Total Revenue Per Product
SELECT p.id AS product_id, p.Title AS product_name,sum(oi.quantity), SUM(oi.quantity * p.price) AS total_revenue
FROM VsOrderItems oi
JOIN VsProducts p ON oi.ProductId = p.id
GROUP BY p.id, p.Title
Order By total_revenue desc;



-- 7. Retrieve Latest Orders
SELECT TOP 5 o.Id, OrderDate, TotalAmount , o.CustomerId , u.FirstName
FROM VsOrders o
JOIN VsUsers u ON o.CustomerId=u.Id
ORDER BY OrderDate DESC;

-- 8. Get All Orders with Their Items and Prices
SELECT o.id AS order_id, o.OrderDate, p.Title AS product_name, oi.quantity, p.price, (oi.quantity * p.price) AS total_price
FROM VsOrders o
JOIN VsOrderItems oi ON o.id = oi.OrderId
JOIN VsProducts p ON oi.ProductId = p.id
ORDER BY o.OrderDate DESC;
