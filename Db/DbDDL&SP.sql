CREATE DATABASE CrudAppDB;
USE CrudAppDB;

-- Parent Table: Categories
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);
GO

-- Child Table: Products
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    PicturePath NVARCHAR(MAX),
    Stock INT NOT NULL,
    CategoryID INT FOREIGN KEY REFERENCES 
	Categories(CategoryID) ON DELETE CASCADE
);
GO

--Stored Procedure to Add Product

CREATE PROCEDURE AddProduct
    @ProductName NVARCHAR(100),
    @CategoryID INT,
    @Price DECIMAL(10,2),
    @PicturePath NVARCHAR(MAX),
    @Stock INT
AS
BEGIN
    INSERT INTO Products (ProductName, CategoryID, Price, PicturePath, Stock)
    VALUES (@ProductName, @CategoryID, @Price, @PicturePath, @Stock);
END;
GO


--Stored Procedure to Update Product
CREATE PROCEDURE UpdateProduct
    @ProductID INT,
    @ProductName NVARCHAR(100),
    @CategoryID INT,
    @Price DECIMAL(10,2),
    @PicturePath NVARCHAR(MAX),
    @Stock INT
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        CategoryID = @CategoryID,
        Price = @Price,
        PicturePath = @PicturePath,
        Stock = @Stock
    WHERE ProductID = @ProductID;
END;
GO


--Stored Procedure to Delete Product

CREATE PROCEDURE DeleteProduct
    @ProductID INT
AS
BEGIN
    DELETE FROM Products WHERE ProductID = @ProductID;
END;
GO


--Stored Procedure to Add New Category

CREATE PROCEDURE AddCategory
@CategoryName NVARCHAR(100)
AS
BEGIN
	INSERT INTO Categories(CategoryName)
	VALUES(@CategoryName);
END;
GO


--Stored Procedure to Get All Products
CREATE PROCEDURE GetProducts
AS
BEGIN
    SELECT p.ProductID, p.ProductName, c.CategoryName, p.Price, p.PicturePath, p.Stock
    FROM Products p
    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID;
END;
GO

--Stored Procedure to Get Product by Id
CREATE PROCEDURE GetProductById
@ProductID INT
AS
BEGIN
    SELECT p.ProductID, p.ProductName, c.CategoryName, p.Price, p.PicturePath, p.Stock
    FROM Products p
    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
	WHERE p.ProductID= @ProductID;
END;
GO


--Stored Procedure to Get All Products by Category
CREATE PROCEDURE GetProductsByCategory
@CategoryID INT
AS
BEGIN
    SELECT p.ProductID, p.ProductName, c.CategoryName, p.Price, p.PicturePath, p.Stock
    FROM Products p
    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
	WHERE C.CategoryID = @CategoryID;
END;
GO


--Stored Procedure to Get All Categories
CREATE PROCEDURE GetCategories
AS
BEGIN
    SELECT CategoryID, CategoryName
    FROM Categories
END;
GO


--Stored Procedure to Update Category
CREATE PROCEDURE UpdateCategory
    @CategoryID INT,
    @CategoryName NVARCHAR(100)    
AS
BEGIN
    UPDATE Categories
    SET CategoryName = @CategoryName
    WHERE CategoryID = @CategoryID;
END;
GO

--Stored Procedure to Delete Category

CREATE PROCEDURE DeleteCategory
    @CategoryID INT
AS
BEGIN
    DELETE FROM Categories WHERE CategoryID = @CategoryID;
END;
GO

--Stored Procedure to find Category by ID

CREATE OR ALTER PROCEDURE sp_GetCategoryById
	@CategoryId INT
AS
BEGIN
	SELECT CategoryID, CategoryName FROM Categories
	WHERE CategoryID = @CategoryId
END;
GO