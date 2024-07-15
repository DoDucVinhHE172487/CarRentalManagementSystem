USE CarRentalManagementSystem;
GO


-- Insert data into Staff table
INSERT INTO Staff (Email, StaffName, [Password], Address, PhoneNumber, Salary, isDeleted, createdBy, updatedBy)
VALUES 
('admin@carrental.com', 'Admin User', 'adminpass', '123 Main St', '1234567890', 1000.00, 0, 'system', 'system'),
('staff@carrental.com', 'Staff User', 'staffpass', '456 Main St', '0987654321', 800.00, 0, 'system', 'system');
GO

-- Insert data into Customer table
INSERT INTO Customer (CustomerName, PhoneNumber, Address, createdBy, updatedBy, isDeleted)
VALUES 
('John Doe', '1231231234', '789 Main St', 'admin', 'admin', 0),
('Jane Smith', '9879879876', '101 Main St', 'admin', 'admin', 0);
GO

-- Insert data into CarStatus table
INSERT INTO CarStatus (CarStatusName) VALUES ('Available'), ('Rented'), ('Under Maintenance'), ('Out of Service');
GO

-- Insert data into Car table
INSERT INTO Car (CarName, [Type], DateCar, Color, Brand, Price, [Image], NumberOfSeats, CarStatusId, Fuel, createdBy, updatedBy, RentalPrice, isDeleted)
VALUES 
('Toyota Camry', 'Sedan', '2022-01-01', 'White', 'Toyota', 25000.00, 'camry.jpg', 5, 1, 'Petrol', 'admin', 'admin', 100.00, 0),
('Honda CRV', 'SUV', '2021-05-15', 'Black', 'Honda', 30000.00, 'crv.jpg', 7, 1, 'Diesel', 'admin', 'admin', 120.00, 0);
GO

-- Insert data into CarRental table
INSERT INTO CarRental (CustomerId, CarId, CarPrice, StartDate, EndDate, createdBy, updatedBy, isDeleted)
VALUES 
(1, 1, 100.00, '2024-07-01', '2024-07-07', 'admin', 'admin', 0),
(2, 2, 120.00, '2024-07-03', '2024-07-10', 'admin', 'admin', 0);
GO

-- Insert data into HistoryCarRental table
INSERT INTO HistoryCarRental (RentalId, StartDate, EndDate, ActualReturnTime, TotalPrice, createdBy, updatedBy)
VALUES 
(1, '2024-07-01', '2024-07-07', '2024-07-07', 700.00, 'admin', 'admin'),
(2, '2024-07-03', '2024-07-10', '2024-07-10', 840.00, 'admin', 'admin');
GO
