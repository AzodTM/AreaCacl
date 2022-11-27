CREATE TABLE Products (
ID INT PRIMARY KEY,
"Name" TEXT
);

INSERT INTO Products
VALUES 
(1, 'Laptop'),
(2, 'PC'),
(3, 'Keyboard'),
(4, 'Headset'),
(5, 'Mouse'),
(6, 'Dwarf fortress'),
(7, 'Kerbal space program'),
(8, 'Victoria 3'),
(9, 'Chair');

CREATE TABLE Categories (
	Id INT PRIMARY KEY,
	"Name" TEXT
	);

INSERT INTO Categories
VALUES
(1, 'Technics'),
(2, 'Peripherals'),
(3, 'Games');

CREATE TABLE ProductCategories (
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO ProductCategories
VALUES
	(1, 1),
	(2, 1),
	(3, 2),
	(4, 2),
	(5, 2),
	(6, 3),
	(7, 3),
	(8, 3);

SELECT P."Name", C."Name"
FROM Products P
LEFT JOIN ProductCategories PC
ON P.Id = PC.ProductId
LEFT JOIN Categories C
ON PC.CategoryId = C.Id;
