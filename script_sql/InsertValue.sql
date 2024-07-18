USE CarRentalManagementSystem;
GO

-- Insert data into Staff table
INSERT INTO Staff (Email, StaffName, [Password], Address, PhoneNumber, Salary, isDeleted)
VALUES
('john.doe@example.com', 'John Doe', 'password123', '123 Main St', '1234567890', 5000.00, 0),
('jane.smith@example.com', 'Jane Smith', 'password123', '456 Elm St', '0987654321', 5500.00, 0);
GO

-- Insert data into RankLevelCustomer table
INSERT INTO RankLevelCustomer (RankLevelName)
VALUES
('Bronze'),
('Silver'),
('Gold'),
('Platinum');
GO

-- Insert data into Customer table
INSERT INTO Customer (CustomerName, PhoneNumber, Address, Point, RankLevel, isDeleted)
VALUES
('Alice Johnson', '1112223333', '789 Oak St', 150, 2, 0),
('Bob Williams', '2223334444', '321 Pine St', 300, 3, 0);
GO

-- Insert data into CarStatus table
INSERT INTO CarStatus (CarStatusName)
VALUES
('Available'),
('Rented'),
('In Maintenance');
GO

-- Insert data into Car table
INSERT INTO Car (LicensePlates, CarName, [Type], DateCar, Color, Brand, Price, NumberOfSeats, CarStatusId, Fuel, RentalPrice, isDeleted)
VALUES
('ABC123', 'Toyota Corolla', 'Sedan', '2021-05-10', 'White', 'Toyota', 20000.00, 5, 1, 'Gasoline', 100.00, 0),
('DEF456', 'Honda Civic', 'Sedan', '2020-03-15', 'Black', 'Honda', 18000.00, 5, 1, 'Gasoline', 90.00, 0);
GO

-- Insert data into CarRental table
INSERT INTO CarRental (CustomerId, LicensePlates, StartDate, EndDate, StaffId, Total, isDeleted)
VALUES
(1, 'ABC123', '2023-06-01 10:00:00', '2023-06-10 10:00:00', 1, 1000.00, 0),
(2, 'DEF456', '2023-06-05 14:00:00', '2023-06-12 14:00:00', 2, 900.00, 0);
GO

-- Insert data into HistoryCarRental table
INSERT INTO HistoryCarRental (RentalId, StartDate, EndDate, ActualReturnTime, TotalPrice, createdBy)
VALUES
(1, '2023-06-01 10:00:00', '2023-06-10 10:00:00', '2023-06-10 09:45:00', 1000.00, 'John Doe'),
(2, '2023-06-05 14:00:00', '2023-06-12 14:00:00', '2023-06-12 13:30:00', 900.00, 'Jane Smith');
GO
