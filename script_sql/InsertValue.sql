USE CarRentalManagementSystem;
GO

-- Chèn dữ liệu vào bảng RankLevelCustomer
INSERT INTO RankLevelCustomer (RankLevelName, Discount) VALUES
('Bronze', 5),
('Silver', 10),
('Gold', 15),
('Platinum', 20);
GO

-- Chèn dữ liệu vào bảng Staff
INSERT INTO Staff (Email, StaffName, [Password], Address, PhoneNumber, Salary, isDeleted) VALUES
('john.doe@example.com', 'John Doe', 'password123', '123 Main St', '1234567890', 50000.00, 0),
('jane.smith@example.com', 'Jane Smith', 'password456', '456 Elm St', '0987654321', 60000.00, 0);
GO

-- Chèn dữ liệu vào bảng Customer
INSERT INTO Customer (CustomerName, PhoneNumber, Address, Point, RankLevel, isDeleted) VALUES
('Alice Johnson', '0123456789', '789 Oak St', 100, 1, 0),
('Bob Brown', '9876543210', '321 Pine St', 200, 2, 0);
GO

-- Chèn dữ liệu vào bảng CarStatus
INSERT INTO CarStatus (CarStatusName) VALUES
('Available'),
('Rented'),
('Maintenance');
GO

-- Chèn dữ liệu vào bảng Car
INSERT INTO Car (LicensePlates, CarName, [Type], DateCar, Color, Brand, Price, NumberOfSeats, CarStatusId, Fuel, RentalPrice, isDeleted) VALUES
('ABC123', 'Toyota Camry', 'Sedan', '2020-01-01', 'Black', 'Toyota', 30000.00, 5, 1, 'Gasoline', 100.00, 0),
('XYZ789', 'Honda Accord', 'Sedan', '2021-06-15', 'White', 'Honda', 28000.00, 5, 1, 'Gasoline', 90.00, 0);
GO

-- Chèn dữ liệu vào bảng CarRental
INSERT INTO CarRental (CustomerId, LicensePlates, StartDate, EndDate, StaffId, Total, isDeleted) VALUES
(1, 'ABC123', '2023-07-01', '2023-07-10', 1, 1000.00, 0),
(2, 'XYZ789', '2023-07-05', '2023-07-15', 2, 900.00, 0);
GO

-- Chèn dữ liệu vào bảng HistoryCarRental
INSERT INTO HistoryCarRental (RentalId, StartDate, EndDate, ActualReturnTime, TotalPrice, createdBy) VALUES
(1, '2023-07-01', '2023-07-10', '2023-07-10 14:00:00', 1000.00, 'john.doe@example.com'),
(2, '2023-07-05', '2023-07-15', '2023-07-15 16:00:00', 900.00, 'jane.smith@example.com');
GO
