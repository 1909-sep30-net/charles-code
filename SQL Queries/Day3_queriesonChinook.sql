-- SQL has some operators that combine entire queries (select) into one query.
-- the "Set Operators:

-- Literally represented by Venn Diagrams

-- Union
-- Union All
-- Intersect
-- Except

-- To use any of the two queries, they must have the same number and type of columns

-- UNION
-- Gives you all rows that are found in both queries, without duplicates

-- UNION ALL
--  gives you all rows found in both, period, including duplicates.
--   Is faster, but pulls more data

-- INTERSECT
--   All rows that are both queries (No Duplicates)

-- EXCEPT
-- Sometimes called a "set difference"
--   All rows that are in the first query, but are not in the second query.

-- All first Names of Employees and Customers


-- EXAMPLES

--UNION
-- NOte: Can use paranthesese to separate queries, but not needed.

SELECT FirstName FROM Employee
UNION     -- UNION BINDS
SELECT FirstName FROM Customer


--INTERSECT
-- names that a customer has and also an employee h

SELECT FIrstName FROM Employee
INTERSECT
SELECT FirstName FROM Customer


--EXCEPT
-- names thjat employees have but customers sdo not have
SELECT FirstName FROM Employee
EXCEPT
SELECT FirstName FROM Customer;


-- UNIONS are not JOINS
-- Determine the difference between the two other than the syntax.


---------------W2 Day 3 Assignment--------------

-- exercises

-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

SELECT * FROM Artist WHERE ArtistID  
NOT IN (
SELECT ArtistId FROM Album )
ORDER BY ArtistID ASC;

-- 2. which artists did not record any tracks of the Latin genre?

SELECT * FROM Artist WHERE ArtistID  --get the artists not in list of Latin Albums.
NOT IN (
	SELECT AlbumID FROM Track  -- get all the Latin Albums
		WHERE Track.GenreId = 7) -- we looked up the id for Latin

-- Alternate Solution by teacher

SELECT * FROM Artist 
EXCEPT
SELECT ar.* FROM ARTIST AS ar
	LEFT JOIN Album AS al on ar.ArtistID = al.ArtistId
	Left JOIN Track AS t ON al.AlbumId = t.AlbumId
	LEFT JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name = 'Latin';

--Yet another solution
SELECT * FROM Artist
WHERE ArtistId NOT IN (
	SELECT TrackId FROM Track WHERE GenreId = (
		SELECT GenreId FROM Genre WHERE Name = 'Latin'
		)
		)

-- 3. which video track has the longest length? (use media type table)


SELECT TOP 1 * FROM Track 
WHERE Track.MediaTypeId = (          
SELECT MediaTypeId FROM MediaType    -- getting number from 
WHERE Name LIKE '%_ideo%')           -- a table.... single cell returns a value...
ORDER BY Milliseconds DESC 

-- ran this after a direct look at 3.  
-- Using a constant value isn't safe, espcially if 
-- there are more than one similar, but included types
--

SELECT MediaTypeId FROM MediaType
WHERE Name LIKE '%_ideo%'

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.

---- DML Exersizes

-- 1. insert two new records into the employee table.

SELECT * FROM Employee

INSERT INTO Employee (EmployeeId, LastName, FirstName, Title, ReportsTo, BirthDate, HireDate, Address, City, State, Country, PostalCode, Phone, Fax, Email)
VALUES
(90000, 'Grape', 'Gilbert', 'Bosman', '90005', '2000-02-18 00:00:00:000' , '2000-02-18 00:00:00:000', '1234 Seseme Street', 'New York', 'NY', 'USA', 10001, '+1 (555) 123-4567', '+1 (555) 321-9876', 'gilbert@chinookcorp.com' ),
(90005, 'Man', 'Bat', 'Rich Guy', '1', '1949-1-15 00:00:00:000' , '2005-01-01 00:00:00:000', '5780 Gotham Parks Ln', 'Gotham', 'NY', 'USA', 10002, '+1 (555) 555-5555', '+1 (847) 546-8008', 'not_batman@wanecorp.com' )


-- 2. insert two new records into the tracks table.

SELECT * FROM Track
ORDER BY TrackId DESC

INSERT INTO Track (TrackId, Name, AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice)
VALUES
( (SELECT MAX(TrackId) FROM Track) + 5, 'Batman Raps',  132, 1,  17, '', 221701, 7286305, 9.95),
( (SELECT MAX(TrackId) FROM Track) + 10, 'Batman Sings Opera',  132, 1,  25, '', 221701, 7286305, 19.95)

 
-- 3. update customer Aaron Mitchell's name to Robert Walter

SELECT * from Customer

UPDATE Customer
SET 
FirstName = 'Robert',
LastName = 'Walker'
WHERE FirstName LIKE 'Aaron' AND LastName LIKE 'Mitchell'



-- 4. delete one of the employees you inserted.

DELETE From Employee
WHERE EmployeeId = 90000

Select * from Employee

-- 5. delete customer Robert Walter.

--get customer
SELECT * FROM Customer
WHERE FirstName LIKE 'Robert' AND LastName LIKE 'Walker'

--get their invoices
SELECT * FROM Invoice
WHERE CustomerId = 
(
	SELECT CustomerID FROM Customer
	WHERE FirstName LIKE 'Robert' AND LastName LIKE 'Walker'
);

--get their line-items on their invoices

--automate the deletion... WIP
--SELECT * FROM InvoiceLine

SELECT * FROM Invoice
WHERE CustomerId = 
(
	SELECT CustomerID FROM Customer
	WHERE FirstName LIKE 'Robert' AND LastName LIKE 'Walker'
)



DELETE From Customer
WHERE FirstName LIKE 'Walter' AND LastName LIKE 'Mitchel'


--Note, this refers to Referential Integrity, where forign key values point to an existing primary key.  Can't delete data related, and depending on 
-- a specific row.

--Teacher's Solution

DELETE FROM InvoiceLine WHERE InvoiceId IN 
(
	SELECT InvoiceId FROM Invoice Where CustomerId =(
	SELECT CustomerId
	FROM Customer
	WHERE FirstName = 'Robert' AND LastName = 'Walter')
)

DELETE FROM INvoice WHERE CustomerId = 
(
	SELECT CustomerId FROM Customer
	WHERE FirstName = 'Robert' AND LastName = 'Walter'
)

DELETE FROM Customer
	WHERE FirstName = 'Robert' AND LastName = 'Walter'