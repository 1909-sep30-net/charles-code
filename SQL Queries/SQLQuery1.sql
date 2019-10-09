-- basic exercises (Chinook database)

-- Business requirements documents will require good sense in order to interpret the request vs. actual.

-- 1. list all customers (full names, customer ID, and country) who are not in the US

SELECT FirstName + ' ' + LastName AS [FullName], CustomerID, Country
FROM Customer
WHERE Country != 'USA';

-- 2. list all customers from brazil

SELECT *
FROM Customer
WHERE Country = 'Brazil';

-- 3. list all sales agents

SELECT *
FROM Employee
WHERE Title = 'Sales Support Agent';

--this works too
-- From Mr. Nick
SELECT *
FROM Employee
Where Title LIKE '%Sales%Agen_%'; -- % is the wildcard.
--pattern matching with the LIKE operator
-- % - 0 to many of any character
-- [abc] - one of a, b, or c
-- _ = 1 of any character

-- 4. show a list of all countries in billing addresses on invoices.

--distinct is from the Select...
SELECT DISTINCT BillingCountry
FROM Invoice

--Select Distinct means, that after you get all the results rows... remove all the duplicate rows.
-- can be slower on the server, but is faster to transmit (trimmed data)


-- 5. how many invoices were there in 2009, and what was the sales total for that year?
--    (extra challenge: find the invoice count sales total for every year, using one query)

SELECT COUNT (*) [InvCount], SUM(Total)[2009Sales] 
FROM Invoice
WHERE YEAR(InvoiceDate) = 2009;

--KC's Answer
SELECT SUM(Total) AS TOtalAmount, COUNT(InvoiceID) AS InvoicesIn2019
FROM Invoice WHERE InvoiceDate BETWEEN '2009-01-01' AND '2009-12-31'
--also
--WHERE YEAR(InvoiceDate)=2009

--another's answer
--Extra Challenge Answer
SELECT DISTINCT YEAR(InvoiceDate) AS Year, SUM(Total) AS TOtalAmount, COUNT(InvoiceID) AS InvoicesIn2019
FROM Invoice
GROUP BY YEAR(InvoiceDate);


-- So Far
--Select statements have several "clauses"

-- Select clause specifies what columns to have in the result set
-- FROM clause specifies what table to query
-- WHERE clause defines a condition , filtering out rows that don't match
-- GROUP BY clause aggregates rows together based on common information in a column
-- Having clause defines a condition for filtering, but AFTER the group-by
-- ORDER BY clause specifies the sort-order of the result set.  Order by default is undefined.
--          best to order the data as a best practice.

SELECT COUNT(*)  -- <-- aggregate function  to get number of rows in a DB table
FROM Customer;

--find out about any duplicate first names across customers!

--count people who have the same first name.
SELECT FirstName, Count(*) [DupNameCount]
FROM Customer
GROUP BY FirstName;

--same first and last name?  Probably not.
SELECT FirstName, LastName, Count(*) [DupNameCount]
FROM Customer
GROUP BY FirstName, LastName DESC;--not putting LastName here creates problems... first set is often last set.

--aggregate function takes in multiple rows (values) and returns one value


-- Don't care about the unique names?
SELECT FirstName, Count(*) AS DuplicateCount
FROM Customer
--WHERE COUNT(*) > 1  <-- not posssible, WHERE runs before GROUP BY
GROUP BY FirstName
HAVING COUNT(*) > 1  -- <-- having is added onto the end
ORDER BY FirstName;  -- <--and storted!

--- More on Select

-- logical order of operations as a whole in Select statements

--1. SELECT
--2. FROM
--3. WHERE
--4. GROUP BY
--5. HAVING
--6. ORDER BY



-- 6. how many line items were there for invoice #37?

SELECT COUNT(*) 
FROM InvoiceLine
WHERE InvoiceId = 37;

-- 7. how many invoices per country?

SELECT BillingCountry, COUNT(*) [CountryCount]
FROM Invoice
GROUP BY BillingCountry; 



-- 8. show total sales per country, ordered by highest sales first.

SELECT BillingCountry, SUM(Total) [TotalSales]
FROM Invoice
GROUP BY BillingCountry
ORDER BY TotalSales DESC; 

--Another Way by Mr. Nick
SELECT BillingCountry, SUM(Total)
FROM Invoice
GROUP BY BillingCountry
ORDER BY SUM(Total) DESC, BillingCountry;  -- <-- possible to have secondary sort criteria.
