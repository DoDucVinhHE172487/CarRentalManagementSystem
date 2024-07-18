USE CarRentalManagementSystem;
GO

INSERT INTO Staff (Email, StaffName, [Password], Address, PhoneNumber, Salary, isDeleted, createdBy, updatedBy)
VALUES
('john.doe@example.com', 'John Doe', 'password123', '123 Elm Street', '1234567890', 5000.00, 0, 'admin', 'admin'),
('jane.smith@example.com', 'Jane Smith', 'password456', '456 Oak Avenue', '0987654321', 5500.00, 0, 'admin', 'admin');

INSERT INTO Customer (CustomerName, PhoneNumber, Address, createdBy, updatedBy, isDeleted)
VALUES
('Alice Johnson', '1122334455', '789 Pine Road', 'admin', 'admin', 0),
('Bob Brown', '5566778899', '101 Maple Lane', 'admin', 'admin', 0);

INSERT INTO CarStatus (CarStatusName)
VALUES
('Available'),
('Rented'),
('Maintenance');

INSERT INTO Car (LicensePlates, CarName, [Type], DateCar, Color, Brand, Price, NumberOfSeats, CarStatusId, Fuel, RentalPrice, createdBy, updatedBy, isDeleted)
VALUES
('ABC-123', 'Toyota Camry', 'Sedan', '2020-05-01', 'Black', 'Toyota', 20000.00, 5, 1, 'Gasoline', 100.00, 'admin', 'admin', 0),
('XYZ-456', 'Honda CR-V', 'SUV', '2019-08-15', 'White', 'Honda', 25000.00, 7, 1, 'Diesel', 120.00, 'admin', 'admin', 0);

INSERT INTO CarRental (CustomerId, LicensePlates, StartDate, EndDate, createdBy, updatedBy, isDeleted)
VALUES
(1, 'ABC-123', '2023-07-01 09:00:00', '2023-07-10 09:00:00', 'admin', 'admin', 0),
(2, 'XYZ-456', '2023-07-05 10:00:00', '2023-07-12 10:00:00', 'admin', 'admin', 0);

INSERT INTO HistoryCarRental (RentalId, StartDate, EndDate, ActualReturnTime, TotalPrice, createdBy, updatedBy)
VALUES
(1, '2023-07-01 09:00:00', '2023-07-10 09:00:00', '2023-07-10 08:30:00', 900.00, 'admin', 'admin'),
(2, '2023-07-05 10:00:00', '2023-07-12 10:00:00', '2023-07-12 09:45:00', 840.00, 'admin', 'admin');

