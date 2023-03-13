--Sales Date Prediction
SELECT c.custid, c.companyname,
	   MAX(o.orderdate) AS LastOrderDate,
       DATEADD(DAY, AVG(DATEDIFF(DAY, o.fecha_anterior, o.orderdate))- 7, MAX(o.orderdate)) AS NextPredictedOrder,
	   AVG(DATEDIFF(DAY, o.fecha_anterior, o.orderdate)) As Promedio_Dias
FROM Sales.Customers c
INNER JOIN (
    SELECT custid, orderdate, 
			(SELECT MAX(orderdate) 
            FROM Sales.Orders o2 
            WHERE o2.custid = o1.custid AND o2.orderdate < o1.orderdate) AS fecha_anterior,
           (SELECT AVG(DATEDIFF(DAY, o2.orderdate, o3.orderdate))
            FROM Sales.Orders o2 
            INNER JOIN Sales.Orders o3 ON o3.custid = o2.custid AND o3.orderdate < o2.orderdate
            WHERE o2.custid = o1.custid AND o2.orderdate = (SELECT MAX(orderdate) FROM Sales.Orders WHERE custid = o1.custid)
            GROUP BY o2.custid) AS promedio_dias_anteriores
    FROM Sales.Orders o1
) o ON c.custid = o.custid
GROUP BY c.custid, c.companyname;

--Get Client Orders
SELECT Sales.Orders.orderid, Sales.Orders.requireddate, Sales.Orders.shippeddate, Sales.Orders.shipname, Sales.Orders.shipaddress, Sales.Orders.shipcity
    FROM Sales.Orders 
    JOIN Sales.Customers ON Customers.custid = Sales.Orders.custid 
  ORDER  BY
  Sales.Customers.companyname 

--Get employee
SELECT empid, CONCAT(firstname, ' ', lastname) FROM HR.Employees

--Get Shippers
SELECT shipperid, companyname FROM Sales.Shippers

--Get Products
SELECT productid, productname FROM Production.Products

  --Add New Order
  SET IDENTITY_INSERT Sales.Orders ON;
  INSERT INTO Sales.Orders(orderid, custid, empid, orderdate, requireddate, shippeddate, shipperid, freight, shipname, shipaddress, shipcity, shipregion, shippostalcode, shipcountry)
  VALUES(11078, 85, 5, '20060704 00:00:00.000', '20060801 00:00:00.000', '20060716 00:00:00.000', 3, 32.38, N'Ship to 85-B', N'6789 rue de l''Abbaye', N'Reims', NULL, N'10311', N'Colombia');

  DECLARE @OrderId AS BIGINT;
  SELECT @OrderId = SCOPE_IDENTITY();

  INSERT INTO Sales.OrderDetails(orderid, productid, unitprice, qty, discount)
  VALUES(@OrderId, 11, 14.00, 12, 0);


  select * from Sales.Customers where custid = 85
    select * from Sales.Orders where custid = 85