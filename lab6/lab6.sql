--1. (#15)  Напишите SQL запросы  для решения задач ниже. 
CREATE TABLE PC 
(
	id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	cpu INTEGER NOT NULL,
	memory INTEGER NOT NULL,
	hdd INTEGER NOT NULL
);

INSERT INTO PC (cpu, memory, hdd)
VALUES
	(1600, 2000, 500),
	(2400, 3000, 800),
	(3200, 3000, 1200),
	(2400, 2000, 500);
	
--1) Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб.
SELECT id, cpu, memory
FROM PC
WHERE memory = 3000;

--2) Минимальный объём жесткого диска, установленного в компьютере на складе.
SELECT MIN(hdd) AS min_hdd
FROM PC;

--3) Количество компьютеров с минимальным объемом жесткого диска, доступного на складе.
SELECT COUNT(id) AS count, hdd
FROM PC
WHERE hdd = (SELECT MIN(hdd) FROM PC)
GROUP BY hdd;

/* 2. (#30) Есть таблица следующего вида:
    Напишите SQL-запрос, возвращающий все пары (download_count, user_count), 
    удовлетворяющие следующему условию: 
    user_count — общее ненулевое число пользователей, сделавших 
    ровно download_count скачиваний 19 ноября 2010 года. */
CREATE TABLE track_downloads
(
	download_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	track_id INTEGER NOT NULL,
	user_id	INTEGER NOT NULL,
	download_time TEXT NOT NULL
);

INSERT INTO track_downloads (track_id, user_id, download_time) 
VALUES
	(3, 1, '2010-11-19'),
	(5, 3, '2010-11-19'),
	(7, 2, '2010-11-19'),
	(3, 3, '2010-11-19'),
	(9, 1, '2010-12-19'),
	(6, 2, '2010-12-19'),
    (2, 1, '2010-11-19');
	
SELECT download_count, COUNT(*) AS user_count
FROM (
	SELECT track_id, COUNT(*) AS download_count
	FROM track_downloads
	WHERE download_time = '2010-11-19'
	GROUP BY user_id
) AS download_count
GROUP BY download_count;

/*3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP

DATETIME предназначен для хранения целого числа: YYYYMMDDHHMMSS. 
И это время не зависит от временной зоны настроенной на сервере.
DATETIME представляет из себя дату, как в календаре и время, 
которое мы видим на часах, в нашей временной зоне.
Хранит: 8 байт 

TIMESTAMP  хранит значение равное количеству секунд, прошедших с 
полуночи 1 января 1970 года по усреднённому времени Гринвича. 
При получении из базы отображается с учётом часового пояса.
TIMESTAMP же представляет из себя время, точно определённое для 
всех, ведь в мире много временных зон. 
Хранит: 4 байта.
 
В базе данных SQLite нет типа данных для хранения даты или времени. 
Предполагается хранить дату и время либо в строковом поле, либо в виде числа.
Для представления даты и времени есть функция date(), которая возвращает дату 
в формате «YYYY-MM-DD». */

/* 4.(#20)  Необходимо создать таблицу студентов (поля id, name) и таблицу 
курсов (поля id, name). Каждый студент может посещать несколько курсов. Названия 
курсов и имена студентов - произвольны. */

CREATE TABLE student (
	id_student INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE course (
	id_course INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE course_student (
	id_course_student INTEGER PRIMARY KEY AUTOINCREMENT,
	id_course INTEGER NOT NULL,
	id_student INTEGER NOT NULL,
	FOREIGN KEY(id_student) REFERENCES student(id_student),
	FOREIGN KEY(id_course) REFERENCES course(id_course)
);

INSERT INTO student(name)
VALUES
	('Александр'),
	('Людмила'),
	('Юлия'),
	('Пётр'),
	('Елена'),
	('Валентина'),
	('Михаил');
	
INSERT INTO course(name)
VALUES
	('Русский язык'),
	('Высшая математика'),
	('Философия');

INSERT INTO course_student(id_course, id_student)
VALUES
	(1, 2),
	(1, 4),
	(1, 3),
	(1, 1),
	(1, 5),
	(1, 6),
	(2, 7),
	(2, 3),
	(2, 5),
	(3, 1),
	(3, 2),
	(3, 6),
	(3, 4),
	(3, 5);
	
-- 1. Отобразить количество курсов, на которые ходит более 5 студентов.
SELECT 
	COUNT(course) AS number_of_course
FROM (
  SELECT course_student.id_course AS course
  FROM course_student
  GROUP BY course_student.id_course
  HAVING COUNT(course_student.id_student) > 5);
  
--  2. Отобразить все курсы, на которые записан определенный студент.
SELECT student.name, course.name 
FROM course_student
INNER JOIN student ON course_student.id_student = student.id_student 
INNER JOIN course ON course_student.id_course = course.id_course
ORDER BY student.name;

/*5. (5#) Может ли значение в столбце(ах), на который наложено ограничение 
     foreign key, равняться null? Привидите пример.
	   
	 Значение в столбце(ах), на который наложено ограничение foreign key,
	 может равняться null, если нет ограничения NOT NULL. 
	 
	 Пример:*/
	 
CREATE TABLE phones (
	id_phone INTEGER PRIMARY KEY AUTOINCREMENT,
	model TEXT NOT NULL
);

CREATE TABLE students (
	id_student INTEGER PRIMARY KEY AUTOINCREMENT,
	id_phone INTEGER,
	FOREIGN KEY(id_phone) REFERENCES phones(id_phone)
);

INSERT INTO phones(model)
VALUES
	('Samsung'),
	('Honor'),
	('Xiaomi');

INSERT INTO students(id_phone)
VALUES 
	(NULL),
	(2),
	(3);
	
/*6. (#15) Как удалить повторяющиеся строки с использованием ключевого слова Distinct?
Приведите пример таблиц с данными и запросы. 

SELECT DISTINCT columnsName FROM tableName; 
где: columnsName - одно или несколько реальных имен столбцов,перечисленных через запятую; 
tableName - имя той таблицы, из которой выбираются эти столбцы.

Пример:*/

CREATE TABLE employee
(                            	
	id_employee INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL,
	salary INTEGER NOT NULL
);

INSERT INTO employee (name, salary)
VALUES 
	('Анатолий', 2000),
	('Владимир', 4500),
	('Владислав', 2000),
    ('Павел', 5000);

SELECT DISTINCT salary FROM employee;

/*7. (#10) Есть две таблицы:
    users - таблица с пользователями (users_id, name)
    orders - таблица с заказами (orders_id, users_id, status)*/
CREATE TABLE users (
	users_id INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE orders (
	orders_id INTEGER PRIMARY KEY AUTOINCREMENT,
	users_id INTEGER NOT NULL,
	status INTEGER NOT NULL,
	FOREIGN KEY(users_id) REFERENCES users(users_id)
);

INSERT INTO users(name)
VALUES 
	('Александра'),
	('Кристина'),
	('Игорь'),
	('Максим'),
	('Екатерина'),
	('Софья');

INSERT INTO orders(users_id, status)
VALUES 
	(1, 1),
	(2, 0),
	(3, 0),
	(4, 1),
	(5, 1),
	(6, 1),
	(3, 0),
	(5, 0),
	(4, 0),
	(2, 0);

--  1) Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders 
-- имеют status = 0.
SELECT users.users_id, users.name
FROM users
INNER JOIN orders ON users.users_id = orders.users_id
GROUP BY users.users_id
HAVING SUM(orders.status) = 0;

-- 2) Выбрать всех пользователей из таблицы users, у которых больше 5 записей
-- в таблице orders имеют status = 1.
SELECT users.users_id, users.name
FROM users
INNER JOIN orders ON users.users_id = orders.users_id
WHERE orders.status = 1
GROUP BY users.users_id
HAVING COUNT(orders.orders_id) > 5;


/* 8. (#10)  В чем различие между выражениями HAVING и WHERE?
WHERE - это ограничивающее выражение. Оно выполняется до того, 
как будет получен результат операции.

HAVING - фильтрующее выражение. Оно применяется к результату операции и 
выполняется уже после того как этот результат будет получен, в отличии от where.

Выражения WHERE используются вместе с операциями SELECT, UPDATE, DELETE, в то 
время как HAVING только с SELECT и предложением GROUP BY.*/