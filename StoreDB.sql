-- StoreDB
create database EmployeeDB


create table Products
(
	ID int identity(1, 1) primary key, 
	Name varchar(50) not null,
	Price float not null,
)

create table Customers
(

	ID int identity primary key, 
	Firstname varchar(50) not null,
	Lastname varchar(50) not null, 
	CardNumber int not null,
)

create table Orders
(
	ID int identity primary key,
	ProductID int not null,
	CustomerID int not null,
	CONSTRAINT FK_Orders_ProductID FOREIGN KEY (ProductID)     
    REFERENCES Products (ID)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,
	CONSTRAINT FK_Orders_CustomerID FOREIGN KEY (CustomerID)     
    REFERENCES Customers (ID)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,

)
INSERT INTO Products
           (Name
           ,Price)
     VALUES
           ('TEST',
			5.00)
GO
INSERT INTO Products
           (Name
           ,Price)
     VALUES
           ('TEST1',
			5.00)
GO
INSERT INTO Products
           (Name
           ,Price)
     VALUES
           ('TEST2',
			5.00)
GO
INSERT INTO Customers
           (Firstname
           ,Lastname
		   ,CardNumber)
     VALUES
           ('FIRSTNAME',
			'LASTNAME',
			01234)
GO
INSERT INTO Customers
           (Firstname
           ,Lastname
		   ,CardNumber)
     VALUES
           ('FIRSTNAME2',
			'LASTNAME2',
			012345)
GO
INSERT INTO Customers
           (Firstname
           ,Lastname
		   ,CardNumber)
     VALUES
           ('FIRSTNAME3',
			'LASTNAME3',
			0123456)
GO
INSERT INTO Orders
           (ProductID
		   ,CustomerID)
     VALUES
           (1
		   ,1)
GO
INSERT INTO Orders
           (ProductID
		   ,CustomerID)
     VALUES
           (1
		   ,2)
GO
INSERT INTO Orders
           (ProductID
		   ,CustomerID)
     VALUES
           (1
		   ,3)
GO
INSERT INTO Products
           (Name
           ,Price)
     VALUES
           ('iPhone',
			200.00)
GO
INSERT INTO Customers
           (Firstname
           ,Lastname
		   ,CardNumber)
     VALUES
           ('Tina',
			'Smith',
			1111111)
GO
INSERT INTO Orders
           (ProductID
		   ,CustomerID)
     VALUES
           ((Select ID from Products where Name = 'iPhone')
		   ,(Select ID from Customers where Firstname = 'Tina' and Lastname = 'Smith'))
GO
Select * from Orders
where CustomerID = (Select ID from Customers where Firstname = 'Tina' and Lastname = 'Smith')

Select * from Orders
where ProductID = (Select ID from Products where Name = 'iPhone')

Update Products
set Price = 250 where Name = 'iPhone'
