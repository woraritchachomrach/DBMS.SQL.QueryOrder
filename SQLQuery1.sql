-- ต้องการ รหัสสินค้า ชื่อสินค้า จำนวนในสต๊อก ราคาต่อหน่วย และ ต้องการทราบมูลค่าของสินค้าที่อยู่ในสต๊อกปัจจุบัน
-- เฉพาะสินค้าประเภท "Seafood"
select p.ProductID , P.ProductName , p.UnitsInStock , p.UnitPrice ,
	   p.UnitsInStock*p.UnitPrice มูลค่าปัจจุบัน
from Products p join Categories c on p.CategoryID = c.CategoryID
where CategoryName = 'seafood'

--ต้องการรหัสใบสั่งซื้อ วันที่ออกใบสั่งซื้อ ยอดเงินรวมในใบสั่งซื้อ ที่ออกในเดือน ธันวาคม 1997 เริ่มจากมากไปปน้อย
select o.OrderID, o.OrderDate , 
		Convert(decimal(10,2),sum(od.Quantity * od.UnitPrice *(1-od.Discount))) ยอดเงินรวม
from orders o join [Order Details] od on o.OrderID = od.OrderID
where year(OrderDate) = 1997 and month(OrderDate) = 12
group by o.OrderID , o.OrderDate
order by 3 desc
--ต้องการรหัสสินค้า ชื่อสินค้า จำนวนที่ขายได้ เฉพาะที่ขายได้ในเดือน ธันวาคม 1997

select p.ProductID, p.productName, sum(quantity) จำนวนที่ขายได้
from Products p join [Order Details] od on p.ProductID = od.ProductID
				join orders o on o.OrderID = od.OrderID
where year(OrderDate) = 1997 and month(OrderDate) = 12
group by p.ProductID, P.ProductName

--ต้องการรายการสินค้า รหัส ชื่อสินค้า จำนวนที่ขาย ราคาเฉลี่ย ยอดเงินรวม ที่่ Nancy ขายได้ในปี 1998
--เรียงตามยอดเงินรวมจากมากไปน้อย
select 
    p.ProductID,
    p.ProductName,
    sum(od.Quantity) as จำนวนที่ขาย,
    avg(od.UnitPrice) as ราคาเฉลี่ย,
    sum(od.Quantity * od.UnitPrice * (1 - od.Discount)) as ยอดเงินรวม
from 
    [Order Details] od
join 
    Orders o 
    on od.OrderID = o.OrderID
join 
    Products p 
    on od.ProductID = p.ProductID
join 
    Employees e 
    on o.EmployeeID = e.EmployeeID
where 
    e.FirstName = 'Nancy' 
    and year(o.OrderDate) = 1998
group by 
    p.ProductID, p.ProductName
order by 
    ยอดเงินรวม desc;

--จากข้อก่อนหน้านี้ จงหายอดขายทั้งปี 1998 ของ Nancy
select 
    round(sum(od.Quantity * od.UnitPrice * (1 - od.Discount)), 2) as ยอดขายรวมทั้งปี
from 
    [Order Details] od
join 
    Orders o 
    on od.OrderID = o.OrderID
join 
    Employees e 
    on o.EmployeeID = e.EmployeeID
where 
    e.FirstName = 'Nancy' 
    and year(o.OrderDate) = 1998;
-----------------------------------------------------------------------------------
	declare @id as int
	set @id = 10280

--จงแสดงรหัสใบสั่งซื้อ วันที่ออกใบสั่งซื้อ วันที่รับสินค้า ชื่อบริษัทขนส่ง ชื่อเต็มพนักงาน ชื่อบริษัทลูกค้า เบอร์โทรลูกค้า
--ยอดเงินรวม ในใบเสร็จเลขที่ 10801
SELECT 
    o.OrderID AS "รหัสใบสั่งซื้อ",
    o.OrderDate AS "วันที่ออกใบสั่งซื้อ",
    o.RequiredDate AS "วันที่รับสินค้า",
    s.CompanyName AS "ชื่อบริษัทขนส่ง",
    e.FirstName + ' ' + e.LastName AS "ชื่อเต็มพนักงาน",
    c.CompanyName AS "ชื่อบริษัทลูกค้า",
    c.Phone AS "เบอร์โทรลูกค้า",
    CAST(SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS DECIMAL(18, 2)) AS "ยอดเงินรวม"
FROM 
    Orders o
JOIN 
    [Order Details] od 
    ON o.OrderID = od.OrderID
JOIN 
    Shippers s 
    ON o.ShipVia = s.ShipperID
JOIN 
    Employees e 
    ON o.EmployeeID = e.EmployeeID
JOIN 
    Customers c 
    ON o.CustomerID = c.CustomerID
WHERE 
    o.OrderID = @id
GROUP BY 
    o.OrderID, o.OrderDate, o.RequiredDate, s.CompanyName, e.FirstName, e.LastName, c.CompanyName, c.Phone;



--จงแสดง รหัสสินค้า ชื่อสินค้า จำนวนที่ขายได้ ราคาที่ขาย ส่วนลด(%) ยอดเงินเต็ม ยอดเงินส่วนลด ยอดเงินที่หักส่วนลด
--ในแต่ละรายการในใบเสร็จเลขที่ 10801
SELECT 
    p.ProductID AS "รหัสสินค้า",
    p.ProductName AS "ชื่อสินค้า",
    od.Quantity AS "จำนวนที่ขายได้",
    od.UnitPrice AS "ราคาที่ขาย",
    od.Discount * 100 AS "ส่วนลด(%)",
    (od.Quantity * od.UnitPrice) AS "ยอดเงินเต็ม",
    (od.Quantity * od.UnitPrice * od.Discount) AS "ยอดเงินส่วนลด",
    (od.Quantity * od.UnitPrice * (1 - od.Discount)) AS "ยอดเงินที่หักส่วนลด"
FROM 
    [Order Details] od
JOIN 
    Products p 
    ON od.ProductID = p.ProductID
WHERE 
    od.OrderID = @id
