--Write a function that returns the initials of a customer based on his ID

CREATE FUNCTION dbo.GetCustInitials2(@CustID INT)
RETURNS NVARCHAR
AS
BEGIN
	
	
	RETURN
	( 
		SELECT SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1)  
			FROM Customer WHERE CustomerId = @CustID 
	);
END

GO

SELECT SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1) FROM Customer WHERE CustomerId = 5;		


SELECT dbo.GetCustInitials2(20);


--assignment, create a new Database on a different schema.... will put on Chinook

GO
CREATE SCHEMA ica;  	
GO

CREATE TABLE ica.Department
(
DeptID INT NOT NULL,
DeptName NVARCHAR(40) NOT NULL,
Location NVARCHAR(40) NOT NULL,
CONSTRAINT PK_DepartmentID PRIMARY KEY (DeptID)

);

GO

CREATE TABLE ica.Employee
(
	EmpID INT NOT NULL,
	FirstName NVARCHAR(40) NOT NULL,
	LastName NVARCHAR(40) NOT NULL,
	SSN NVARCHAR(9) NOT NULL,
	DeptID INT NOT NULL,
	CONSTRAINT PK_EmpID PRIMARY KEY (EmpID)
);

GO

CREATE TABLE ica.EmpDetails
(
EmpID INT NOT NULL,
Salary MONEY NOT NULL,
Address1 NVARCHAR(70) NOT NULL,
Address2 NVARCHAR(70) NOT NULL,
City NVARCHAR(40) NOT NULL,
State NVARCHAR(40) NOT NULL,
PostalCode NVARCHAR(10) NOT NULL,
Country NVARCHAR(40) NOT NULL,
CONSTRAINT PK_EmpDetID PRIMARY KEY (EmpID)
);
GO


ALTER TABLE ica.EmpDetails
ADD CONSTRAINT
FK_EmpID_Employee FOREIGN KEY (EmpID) REFERENCES ica.Employee (EmpID)
GO


ALTER TABLE ica.Employee
ADD CONSTRAINT
FK_DeptID FOREIGN KEY (DeptID) REFERENCES ica.Department (DeptID)
GO

INSERT INTO ica.Department (DeptID, DeptName, Location)
VALUES
( 1, 'Sales', 'Houston' ),
( 2, 'Marketing', 'New York'),
( 3, 'R&D', 'Virginia')

SELECT * FROM ica.Department

INSERT INTO ica.Employee (EmpID, FirstName, LastName, SSN, DeptID)
VALUES
( 1, 'Bat', 'Man',     '123456789', 2),
( 2, 'Leggo', 'Guy',   '555123456', 1),
( 3, 'Shark', 'Thing', '333333765', 3)

SELECT * FROM ica.Employee
