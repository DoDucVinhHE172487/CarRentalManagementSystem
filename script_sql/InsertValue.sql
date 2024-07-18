USE CarRentalManagementSystem;
GO

-- Thêm dữ liệu vào bảng Staff
INSERT INTO Staff (Email, StaffName, [Password], Address, PhoneNumber, Salary, isDeleted, createdBy, updatedBy)
VALUES
('john.doe@example.com', 'John Doe', 'password123', '123 Main St', '1234567890', 50000.00, 0, 'admin', 'admin'),
('jane.smith@example.com', 'Jane Smith', 'password123', '456 Elm St', '0987654321', 60000.00, 0, 'admin', 'admin');
GO

-- Thêm dữ liệu vào bảng Customer
INSERT INTO Customer (CustomerName, PhoneNumber, Address, createdBy, updatedBy, isDeleted)
VALUES
('Alice Johnson', '1112223333', '789 Pine St', 'admin', 'admin', 0),
('Bob Williams', '4445556666', '321 Oak St', 'admin', 'admin', 0);
GO

-- Thêm dữ liệu vào bảng CarStatus
INSERT INTO CarStatus (CarStatusName)
VALUES
('Available'),
('Rented'),
('Under Maintenance');
GO

-- Thêm dữ liệu vào bảng Car
INSERT INTO Car (LicensePlates, CarName, [Type], DateCar, Color, Brand, Price, NumberOfSeats, CarStatusId, Fuel, RentalPrice, createdBy, updatedBy, isDeleted)
VALUES
('ABC123', 'Toyota Camry', 'Sedan', '2020-05-01', 'Red', 'Toyota', 30000.00, 5, 1, 'Gasoline', 100.00, 'admin', 'admin', 0),
('XYZ789', 'Honda Civic', 'Sedan', '2019-08-15', 'Blue', 'Honda', 25000.00, 5, 1, 'Gasoline', 90.00, 'admin', 'admin', 0);
GO

-- Thêm dữ liệu vào bảng CarRental
INSERT INTO CarRental (CustomerId, LicensePlates, StartDate, EndDate, createdBy, updatedBy, isDeleted, Total)
VALUES
(1, 'ABC123', '2024-07-01 10:00:00', '2024-07-10 10:00:00', 'admin', 'admin', 0, 1000.00),
(2, 'XYZ789', '2024-07-05 14:00:00', '2024-07-15 14:00:00', 'admin', 'admin', 0, 900.00);
GO

-- Thêm dữ liệu vào bảng HistoryCarRental
INSERT INTO HistoryCarRental (RentalId, StartDate, EndDate, ActualReturnTime, TotalPrice, createdBy, updatedBy)
VALUES
(1, '2024-07-01 10:00:00', '2024-07-10 10:00:00', '2024-07-10 09:45:00', 1000.00, 'admin', 'admin'),
(2, '2024-07-05 14:00:00', '2024-07-15 14:00:00', '2024-07-15 13:50:00', 900.00, 'admin', 'admin');
GO
