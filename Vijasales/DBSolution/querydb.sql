
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
