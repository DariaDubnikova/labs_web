-- 2. Добавьте таблицы
CREATE TABLE dvd (
	dvd_id INTEGER PRIMARY KEY AUTOINCREMENT,
	title TEXT NOT NULL,
	production_year INTEGER NOT NULL
);
CREATE TABLE customer (
	customer_id INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name TEXT NOT NULL,
	last_name TEXT NOT NULL,
	passport_code INTEGER NOT NULL,
	registration_date TEXT NOT NULL
);
CREATE TABLE offer (
	offer_id INTEGER PRIMARY KEY AUTOINCREMENT,
	dvd_id INTEGER NOT NULL,
	customer_id INTEGER NOT NULL,
	offer_date TEXT NOT NULL,
	return_date TEXT
);
-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.
INSERT INTO dvd (title, production_year) 
VALUES 
	('Престиж', 2006), 
	('Игры разума', 2001), 
	('Гладиатор', 2001),
	('Отступники', 2006), 
	('Начало', 2010),
        ('Ловушка', 2010), 
	('Рапунцель', 2010);

INSERT INTO customer (first_name, last_name, passport_code, registration_date) 
VALUES
	('Василий', 'Васильев', 1243700360, '2020-02-13'), 
	('Иван', 'Петров', 8427495025, '2020-02-03'), 
	('Ольга', 'Лаптева', 4732185974, '2020-02-11');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) 
VALUES 
	(1, 2, '2018-02-05', '2020-02-19'), 
	(2, 3, '2020-01-13', '2020-01-27'), 
	(3, 3, '2019-04-01', '2020-04-15'),
        (4, 2, '2020-03-15', '2020-03-30');

INSERT INTO offer (dvd_id, customer_id, offer_date) 
VALUES 
	(5, 2, '2020-03-03'), 
	(6, 1, '2020-01-20'), 
	(7, 1, '2020-04-13');

-- 4. Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, 
--    отсортированных в алфавитном порядке по названию DVD.
SELECT * 
FROM dvd 
WHERE production_year = 2010 
ORDER BY title ASC;

--5. Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее 
--   время находятся у клиентов.
SELECT dvd.dvd_id, dvd.title, dvd.production_year  
FROM dvd
INNER JOIN offer ON dvd.dvd_id = offer.dvd_id
WHERE offer.return_date IS NULL;

--6. Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD 
--   диски в текущем году. В результатах запроса необходимо также отразить какие диски 
--   брали клиенты.
SELECT 
        customer.customer_id,  
	customer.first_name, 
	customer.last_name,
        dvd.dvd_id,  
	dvd.title,
	dvd.production_year
FROM customer
INNER JOIN offer ON customer.customer_id = offer.customer_id
INNER JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE 
	strftime('%Y', offer.offer_date) = '2020';


