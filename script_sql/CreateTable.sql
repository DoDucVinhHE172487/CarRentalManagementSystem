CREATE DATABASE CarRentalManagementSystem;
GO

USE CarRentalManagementSystem;
GO

-- Bảng Staff
CREATE TABLE Staff (
    StaffId INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(50) NOT NULL UNIQUE,
    StaffName NVARCHAR(255) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Salary DECIMAL(10, 2),
    isDeleted BIT,
    createdBy NVARCHAR(255),
    updatedBy NVARCHAR(255),
);
GO

-- Bảng Customer
CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    createdBy NVARCHAR(255),
    updatedBy NVARCHAR(255),
    isDeleted BIT
);
GO

-- Bảng CarStatus
CREATE TABLE CarStatus (
    CarStatusId INT PRIMARY KEY IDENTITY(1,1),
    CarStatusName NVARCHAR(50) NOT NULL
);
GO

-- Bảng Car
CREATE TABLE Car (
    CarId INT PRIMARY KEY IDENTITY(1,1),
    CarName NVARCHAR(80) NOT NULL,
    [Type] NVARCHAR(50) NOT NULL,
    DateCar DATETIME2,
    Color NVARCHAR(50) NOT NULL,
    Brand NVARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    [Image] NVARCHAR(255),
    NumberOfSeats INT NOT NULL,
    CarStatusId INT,
    Fuel NVARCHAR(50) NOT NULL,
    createdBy NVARCHAR(255),
    updatedBy NVARCHAR(255),
    RentalPrice DECIMAL(10, 2) NOT NULL,
    isDeleted BIT,
    FOREIGN KEY (CarStatusId) REFERENCES CarStatus(CarStatusId)
);
GO

-- Bảng CarRental
CREATE TABLE CarRental (
    RentalId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT,
    CarId INT,
    CarPrice DECIMAL(10, 2) NOT NULL,
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    createdBy NVARCHAR(255),
    updatedBy NVARCHAR(255),
    isDeleted BIT,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
    FOREIGN KEY (CarId) REFERENCES Car(CarId)
);
GO

-- Bảng HistoryCarRental
CREATE TABLE HistoryCarRental (
    HistoryCarRentalId INT PRIMARY KEY IDENTITY(1,1),
    RentalId INT,
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    ActualReturnTime DATETIME2,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    createdBy NVARCHAR(255),
    updatedBy NVARCHAR(255),
    FOREIGN KEY (RentalId) REFERENCES CarRental(RentalId)
);
GO
