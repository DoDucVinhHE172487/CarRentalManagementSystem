Create Database CarRentalManagementSystem
go
Use CarRentalManagementSystem
go
CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY,
    CustomerName NVARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Address NVARCHAR(255) NOT NULL
);

CREATE TABLE Car (
    CarId INT PRIMARY KEY,
    CarName NVARCHAR(255) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    Brand NVARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Image NVARCHAR(255),
    NumberOfSeats INT NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Fuel NVARCHAR(50) NOT NULL
);

CREATE TABLE CarBooking (
    BookingId INT PRIMARY KEY,
    CustomerId INT,
    CarId INT,
    CarPrice DECIMAL(10, 2) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    RentalPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
    FOREIGN KEY (CarId) REFERENCES Car(CarId)
);

CREATE TABLE Itinerary (
    ItineraryId INT PRIMARY KEY,
    BookingId INT,
    BookingTime DATETIME NOT NULL,
    ReturnTime DATETIME NOT NULL,
    ActualReturnTime DATETIME,
    AmountDue DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (BookingId) REFERENCES CarBooking(BookingId)
);
