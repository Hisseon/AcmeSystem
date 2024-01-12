CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Code NVARCHAR(50),
    UnitPrice DECIMAL(10, 2)
);

CREATE TABLE Subsidiaries (
    SubsidiaryID INT IDENTITY(1,1) PRIMARY KEY,
    SubsidiaryName NVARCHAR(100)
);

CREATE TABLE Inventories (
    InventoryID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    SubsidiaryID INT,
    Stock INT,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (SubsidiaryID) REFERENCES Subsidiaries(SubsidiaryID)
);

CREATE TABLE Purchases (
    PurchaseID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    SubsidiaryID INT,
    QuantityPurchased INT,
    PurchaseDate DATETIME,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (SubsidiaryID) REFERENCES Subsidiaries(SubsidiaryID)
);

CREATE TABLE Sales (
    SaleID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    SubsidiaryID INT,
    QuantitySold INT,
    SaleDate DATETIME,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (SubsidiaryID) REFERENCES Subsidiaries(SubsidiaryID)
);
