USE CarRentalManagementSystem;
GO

-- Chèn dữ liệu vào bảng Staff
INSERT INTO Staff (Email, StaffName, [Password], Address, PhoneNumber, Salary, isDeleted)
VALUES 
('john.doe@example.com', 'John Doe', 'password123', '123 Elm Street', '1234567890', 50000.00, 0),
('jane.smith@example.com', 'Jane Smith', 'password456', '456 Oak Avenue', '0987654321', 55000.00, 0);
GO

-- Chèn dữ liệu vào bảng RankLevelCustomer
INSERT INTO RankLevelCustomer (RankLevelName, Discount)
VALUES 
('Bronze', 5),
('Silver', 10),
('Gold', 15);
GO

-- Chèn dữ liệu vào bảng Customer
INSERT INTO Customer (CustomerName, PhoneNumber, Address, Point, RankLevel, isDeleted)
VALUES 
('Alice Johnson', '2345678901', '789 Maple Lane', 100, 1, 0),
('Bob Brown', '3456789012', '101 Pine Road', 200, 2, 0);
GO

-- Chèn dữ liệu vào bảng CarStatus
INSERT INTO CarStatus (CarStatusName)
VALUES 
('Available'),
('Rented'),
('Maintenance');
GO

-- Chèn dữ liệu vào bảng Car
INSERT INTO Car (LicensePlates, CarName, [Type], DateCar, Color, Brand, Price, NumberOfSeats, CarStatusId, Fuel, RentalPrice, isDeleted)
VALUES 
('ABC123', 'Toyota Corolla', 'Sedan', '2018-05-01', 'Red', 'Toyota', 20000.00, 5, 1, 'Gasoline', 50.00, 0),
('DEF456', 'Honda Civic', 'Sedan', '2019-03-15', 'Blue', 'Honda', 22000.00, 5, 1, 'Gasoline', 55.00, 0);
GO

-- Chèn dữ liệu vào bảng CarRental
INSERT INTO CarRental (CustomerId, LicensePlates, StartDate, EndDate, StaffId, Total, isDeleted)
VALUES 
(1, 'ABC123', '2024-07-01 09:00:00', '2024-07-10 18:00:00', 1, 500.00, 0),
(2, 'DEF456', '2024-07-05 10:00:00', '2024-07-15 20:00:00', 2, 550.00, 0);
GO

-- Chèn dữ liệu vào bảng HistoryCarRental
INSERT INTO HistoryCarRental (RentalId, StartDate, EndDate, ActualReturnTime, TotalPrice)
VALUES 
(1, '2024-07-01 09:00:00', '2024-07-10 18:00:00', '2024-07-10 17:30:00', 500.00),
(2, '2024-07-05 10:00:00', '2024-07-15 20:00:00', '2024-07-15 19:45:00', 550.00);
GO
