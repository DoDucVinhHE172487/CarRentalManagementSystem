USE CarRentalManagementSystem;
GO

-- Insert values into Staff table
INSERT INTO Staff (Email, StaffName, [Password], Address, PhoneNumber, Salary, isDeleted)
VALUES 
('duong', 'John Doe', '2', '123 Main St', '123-456-7890', 50000.00, 0),
('jane.smith@example.com', 'Jane Smith', 'password456', '456 Elm St', '987-654-3210', 55000.00, 0);
GO

-- Insert values into RankLevelCustomer table
INSERT INTO RankLevelCustomer (RankLevelName, Discount)
VALUES 
('Bronze', 5),
('Silver', 10),
('Gold', 15),
('Platinum', 20);
GO

-- Insert values into Customer table
INSERT INTO Customer (CustomerName, PhoneNumber, Address, Point, RankLevel, isDeleted)
VALUES 
('Alice Johnson', '111-222-3333', '789 Maple Ave', 100, 2, 0),
('Bob Brown', '444-555-6666', '101 Pine St', 200, 3, 0);
GO

-- Insert values into CarStatus table
INSERT INTO CarStatus (CarStatusName)
VALUES 
('Available'),
('Rented'),
('Maintenance');
GO

-- Insert values into Car table
INSERT INTO Car (LicensePlates, CarName, [Type], DateCar, Color, Brand, Price, NumberOfSeats, CarStatusId, Fuel, RentalPrice, isDeleted)
VALUES 
('ABC123', 'Toyota Camry', 'Sedan', '2020-01-01', 'Black', 'Toyota', 25000.00, 5, 1, 'Gasoline', 100.00, 0),
('DEF456', 'Honda Civic', 'Sedan', '2019-06-15', 'White', 'Honda', 22000.00, 5, 1, 'Gasoline', 90.00, 0);
GO

-- Insert values into CarRental table
INSERT INTO CarRental (CustomerId, LicensePlates, StartDate, EndDate, StaffId, Total, isDeleted)
VALUES 
(1, 'ABC123', '2024-07-01 09:00:00', '2024-07-05 18:00:00', 1, 500.00, 0),
(2, 'DEF456', '2024-07-02 10:00:00', '2024-07-06 17:00:00', 2, 450.00, 0);
GO

-- Insert values into HistoryCarRental table
INSERT INTO HistoryCarRental (RentalId, StartDate, EndDate, ActualReturnTime, TotalPrice, StaffId)
VALUES 
(1, '2024-07-01 09:00:00', '2024-07-05 18:00:00', '2024-07-05 17:30:00', 500.00, 1),
(2, '2024-07-02 10:00:00', '2024-07-06 17:00:00', '2024-07-06 16:45:00', 450.00, 2);
GO
