create database EmployeeDB

create table Department
(
	ID int identity primary key,
	Name varchar(50) not null,
	Location varchar(50) not null,
)
create table Employee
(
	ID int identity primary key,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	SSN varchar(50) unique not null,
	DeptID int not null,
	CONSTRAINT FK_Employee_DeptID FOREIGN KEY (DeptID)     
    REFERENCES Department (ID)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,
)
create table EmpDetails
(
	ID int identity primary key, 
	EmployeeID int not null, 
	CONSTRAINT FK_EmployeeDetails_Employee FOREIGN KEY (EmployeeID)     
    REFERENCES Employee (ID)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,
	Salary int not null,
	Address1 varchar(50) not null,
	Address2 varchar(50),
	City varchar(50) not null, 
	State varchar(50) not null,
	Country varchar(50) not null,
)
INSERT INTO Department
           (Name
           ,Location)
     VALUES
           ('TEST',
			'TESTLOC')
GO
INSERT INTO Department
           (Name
           ,Location)
     VALUES
           ('TEST2',
			'TESTLOC2')
GO
INSERT INTO Department
           (Name
           ,Location)
     VALUES
           ('TEST3',
			'TESTLOC3')
GO
INSERT INTO Employee
           (FirstName
		   ,LastName
		   ,SSN
           ,DeptID)
     VALUES
           ('TEST',
			'TEST',
			'111-11-1111',
			1)
GO
INSERT INTO Employee
           (FirstName
		   ,LastName
		   ,SSN
           ,DeptID)
     VALUES
           ('TEST2',
			'TEST2',
			'111-12-1111',
			2)
GO
INSERT INTO Employee
           (FirstName
		   ,LastName
		   ,SSN
           ,DeptID)
     VALUES
           ('TEST3',
			'TEST3',
			'111-13-1111',
			3)
GO
INSERT INTO EmpDetails
           (EmployeeID
		   ,Salary
		   ,Address1
           ,Address2
		   ,City
		   ,State
		   ,Country)
     VALUES
           (1,
			50000,
			'1234 Fake Lane',
			'12345 Fake Ave.', 
			'Newark',
			'New Jersey',
			'Poland')
GO
INSERT INTO EmpDetails
           (EmployeeID
		   ,Salary
		   ,Address1
           ,Address2
		   ,City
		   ,State
		   ,Country)
     VALUES
           (2,
			50000,
			'1234 Fake Lane',
			'12345 Fake Ave.', 
			'Newark',
			'New Jersey',
			'Poland')
GO
INSERT INTO EmpDetails
           (EmployeeID
		   ,Salary
		   ,Address1
           ,Address2
		   ,City
		   ,State
		   ,Country)
     VALUES
           (3,
			50000,
			'1234 Fake Lane',
			'12345 Fake Ave.', 
			'Newark',
			'New Jersey',
			'Poland')
GO
INSERT INTO Employee
           (FirstName
		   ,LastName
		   ,SSN
           ,DeptID)
     VALUES
           ('Tina',
			'Smith',
			'111-14-1111',
			(Select ID from Department where Name = 'Marketing'))
GO
INSERT INTO Department
           (Name
           ,Location)
     VALUES
           ('Marketing',
			'5th Floor')
GO
Select * from Employee
where DeptID = (Select ID from Department where Name = 'Marketing')

Select count(Salary) from EmpDetails
where EmployeeID = (Select ID from Employee where DeptID = (Select ID from Department where Name = 'Marketing'))
group by Salary
order by Salary desc

Select count(DeptID) from Employee
group by DeptID

Update EmpDetails
set Salary = 90000 where EmployeeID = (Select ID from Employee where FirstName = 'Tina' and LastName = 'Smith')