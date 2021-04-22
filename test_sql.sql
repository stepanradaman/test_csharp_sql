/*
Допустим есть 3 таблицы:
Таблица1.Продукты: индекс1, название1
Таблица2.Категории: индекс2, название2
Таблица3.ПродуктыКатегории, таблица совмещения (готовилась отдельно или результат разбивки строк по массиву категорий):
индекс1, индекс2
*/

CREATE TABLE products (
	id INT PRIMARY KEY,
	productname VARCHAR(200)
);

INSERT INTO products VALUES
(1, 'product1'),
(2, 'product2'),
(3, 'product3');

CREATE TABLE categories (
	id INT PRIMARY KEY,
	categoryname VARCHAR(200)
);

INSERT INTO categories VALUES
(1, 'category1'),
(2, 'category2'),
(3, 'category3');

CREATE TABLE prcat (
	prid INT,
	catid INT
);

INSERT INTO prcat VALUES
(1, 1),
(1, 3),
(2, 2),
(3, 1);

SELECT products.productname, categories.categoryname
FROM prcat 
LEFT JOIN  products
ON prcat.prid = products.id 
LEFT JOIN  categories
ON prcat.catid = categories.id; 

/*
+-------------+--------------+
| productname | categoryname |
+-------------+--------------+
| product1    | category1    |
| product1    | category3    |
| product2    | category2    |
| product3    | category1    |
+-------------+--------------+
*/
