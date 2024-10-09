SHOW DATABASES;

CREATE DATABASE shop_db;

USE shop_db;

CREATE TABLE member (
member_id varchar(50) NOT NULL PRIMARY KEY,
member_name varchar(50) NOT NULL,
member_addr varchar(50)
);

CREATE TABLE product (
product_name varchar(50) NOT NULL PRIMARY KEY,
cost int NOT NULL,
make_date DATE,
company varchar(50),
amount int
);

INSERT INTO member VALUES('tess', '나훈아', '경기 부천시 중동');
INSERT INTO member VALUES('hero', '임영웅', '서울 은평구 중산동');
INSERT INTO member VALUES('iyou', '아이유', '인천 남구 주안동');
INSERT INTO member VALUES('jyp', '박진영', '경기 고양시 장항동');

INSERT INTO product VALUES('바나나', 1500, '2021-07-01', '델몬트', 17);
INSERT INTO product VALUES('카스', 2500, '2022-03-01', 'OB', 3);
INSERT INTO product VALUES('삼각김밥', 800, '2023-09-01', 'CJ', 22);

DELETE FROM member WHERE member_id = 'tess';

SELECT * FROM member;
SELECT * FROM product;
SELECT member_id, member_name FROM member;
SELECT * FROM member WHERE member_name = '아이유';

# INDEX ~ ON
SELECT * FROM member WHERE member_name = '아이유';
CREATE INDEX idx_member_name ON member(member_name);
SELECT * FROM member WHERE member_name = '아이유';

CREATE VIEW member_view
AS SELECT * FROM member;

SELECT * FROM member_view;

-- DROP PROCEDURE myProc;
DELIMITER //
CREATE PROCEDURE myProc()
BEGIN
	SELECT * FROM member WHERE member_name = '나훈아';
    SELECT * FROM product WHERE product_name = '삼각김밥';
END //
DELIMITER ;

CALL myProc;


