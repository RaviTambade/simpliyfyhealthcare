--Insert values into VsUsers
INSERT INTO VsUsers (FirstName, LastName, Password, Email, Address, Role, ContactNumber, ImageUrl)
VALUES
('Amit', 'Sharma', 'Password123!', 'amit.sharma@example.com', 'Street 1, City Delhi', 'sales', '9876543210', '/images/baseImage.png'),
('Priya', 'Patel', 'Password123!', 'priya.patel@example.com', 'Street 2, City Mumbai', 'customer', '9876543211', '/images/baseImage.png'),
('Rahul', 'Gupta', 'Password123!', 'rahul.gupta@example.com', 'Street 3, City Bengaluru', 'vendor', '9876543212', '/images/baseImage.png'),
('Neha', 'Verma', 'Password123!', 'neha.verma@example.com', 'Street 4, City Chennai', 'director', '9876543213', '/images/baseImage.png'),
('Ravi', 'Singh', 'Password123!', 'ravi.singh@example.com', 'Street 5, City Delhi', 'sales', '9876543214', '/images/baseImage.png'),
('Sita', 'Nair', 'Password123!', 'sita.nair@example.com', 'Street 6, City Mumbai', 'customer', '9876543215', '/images/baseImage.png'),
('Vikas', 'Kumar', 'Password123!', 'vikas.kumar@example.com', 'Street 7, City Bengaluru', 'vendor', '9876543216', '/images/baseImage.png'),
('Rita', 'Joshi', 'Password123!', 'rita.joshi@example.com', 'Street 8, City Chennai', 'director', '9876543217', '/images/baseImage.png'),
('Ajay', 'Reddy', 'Password123!', 'ajay.reddy@example.com', 'Street 9, City Delhi', 'sales', '9876543218', '/images/baseImage.png'),
('Anjali', 'Chaudhary', 'Password123!', 'anjali.chaudhary@example.com', 'Street 10, City Mumbai', 'customer', '9876543219', '/images/baseImage.png'),
('Karan', 'Patel', 'Password123!', 'karan.patel@example.com', 'Street 11, City Bengaluru', 'vendor', '9876543220', '/images/baseImage.png'),
('Sunita', 'Gupta', 'Password123!', 'sunita.gupta@example.com', 'Street 12, City Chennai', 'director', '9876543221', '/images/baseImage.png'),
('Manish', 'Yadav', 'Password123!', 'manish.yadav@example.com', 'Street 13, City Delhi', 'sales', '9876543222', '/images/baseImage.png'),
('Shalini', 'Bose', 'Password123!', 'shalini.bose@example.com', 'Street 14, City Mumbai', 'customer', '9876543223', '/images/baseImage.png'),
('Vijay', 'Malhotra', 'Password123!', 'vijay.malhotra@example.com', 'Street 15, City Bengaluru', 'vendor', '9876543224', '/images/baseImage.png');


--Inserting data into VsProducts
INSERT INTO VsProducts (Title, Description, Brand, Price, Stock, Category, ImageUrl) VALUES
('Samsung Galaxy M05', 'Latest model with high-resolution camera', 'Samsung', 10900,1000,'SmartPhone','/images/products/smartphones/galaxy_M05.jpg'),
('Samsung Galaxy S22', '5G 8GB RAM 128GB','Samsung', 49980,1000,'SmartPhone','/images/products/smartphones/galaxy_S22.jpg'),
('Samsung Galaxy S23 Ultra', '5G AI-Smartphone 12GB RAM 256GB ','Samsung', 89000,500,'SmartPhone','/images/products/smartphones/galaxy_S23.jpg'),
('iPhone 16', '5G 128GB ','Apple', 86000,1500,'SmartPhone','/images/products/smartphones/iphone_16.jpg'),
('iPhone 14', '5G 128GB ','Apple', 55000,1300,'SmartPhone','/images/products/smartphones/iphone_14.jpg'),
('iPhone 13', '5G 256GB ','Apple', 54999,1500,'SmartPhone','/images/products/smartphones/iphone_13.jpg'),
('OnePlus 11', '5G 12GB RAM 256GB', 'OnePlus', 54999, 800, 'SmartPhone', '/images/products/smartphones/oneplus_11.jpg'),
('OnePlus 12', '5G 16GB RAM 512GB', 'OnePlus', 66999, 600, 'SmartPhone', '/images/products/smartphones/oneplus_12.jpg'),
('OnePlus Nord CE 4', '5G 8GB RAM 128GB', 'OnePlus', 23999, 1000, 'SmartPhone', '/images/products/smartphones/oneplus_nord_ce4.jpg'),
('Lenovo ThinkPad E14', 'Intel Core i5 8GB RAM 512GB SSD', 'Lenovo', 47999, 400, 'Laptop', '/images/products/laptops/lenovo_e14.jpg'),
('Lenovo ThinkPad E15', 'Intel Core i7 16GB RAM 512GB SSD', 'Lenovo', 58999, 350, 'Laptop', '/images/products/laptops/lenovo_e15.jpg'),
('Lenovo ThinkPad L14', 'Intel Core i3 8GB RAM 256GB SSD', 'Lenovo', 36999, 500, 'Laptop', '/images/products/laptops/lenovo_l14.jpg'),
('Dell Inspiron 5410', 'Intel Core i5 8GB RAM 512GB SSD', 'Dell', 52999, 450, 'Laptop', '/images/products/laptops/dell_inspiron_5410.jpg'),
('Dell Inspiron 5310', 'Intel Core i7 16GB RAM 512GB SSD', 'Dell', 64999, 300, 'Laptop', '/images/products/laptops/dell_inspiron_5310.jpg'),
('Dell Inspiron 3412', 'Intel Core i3 8GB RAM 256GB SSD', 'Dell', 35999, 600, 'Laptop', '/images/products/laptops/dell_inspiron_3412.jpg'),
('HP Pavilion x360', 'Intel Core i5 8GB RAM 512GB SSD', 'HP', 56999, 500, 'Laptop', '/images/products/laptops/hp_pavilion_x360.jpg'),
('HP Envy 13', 'Intel Core i7 16GB RAM 512GB SSD', 'HP', 74999, 400, 'Laptop', '/images/products/laptops/hp_envy_13.jpg'),
('HP Elite Dragonfly', 'Intel Core i5 8GB RAM 256GB SSD', 'HP', 97999, 350, 'Laptop', '/images/products/laptops/hp_elite_dragonfly.jpg'),
('Samsung 55" 4K QLED TV', 'Samsung QLED 4K Smart TV with AI upscaling', 'Samsung', 64999, 200, 'TV', '/images/products/tvs/samsung_qled_55.jpg'),
('Samsung 65" 4K UHD TV', 'Samsung Crystal UHD 4K Smart TV', 'Samsung', 74999, 150, 'TV', '/images/products/tvs/samsung_crystal_65.jpg'),
('Samsung 75" 4K QLED TV', 'Samsung 4K QLED Smart TV with Ambient Mode', 'Samsung', 89999, 120, 'TV', '/images/products/tvs/samsung_qled_75.jpg'),
('LG 55" OLED TV', 'LG OLED Smart TV with 4K resolution', 'LG', 89999, 120, 'TV', '/images/products/tvs/lg_oled_55.jpg'),
('LG 65" 4K UHD Smart TV', 'LG 4K UHD Smart TV with ThinQ AI', 'LG', 74999, 180, 'TV', '/images/products/tvs/lg_65_4k.jpg'),
('LG 75" NanoCell TV', 'LG 75" 4K UHD NanoCell Smart TV', 'LG', 84999, 150, 'TV', '/images/products/tvs/lg_nano_75.jpg'),
('Vu 50" 4K LED TV', 'Vu Premium 4K LED Smart TV', 'Vu', 39999, 300, 'TV', '/images/products/tvs/vu_50_4k.jpg'),
('Vu 55" 4K LED TV', 'Vu 4K LED Smart TV with Android OS', 'Vu', 44999, 250, 'TV', '/images/products/tvs/vu_55_4k.jpg'),
('Vu 65" 4K LED TV', 'Vu 65" 4K LED Smart TV with HDR', 'Vu', 59999, 200, 'TV', '/images/products/tvs/vu_65_4k.jpg');

