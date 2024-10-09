## 데이터 형식

# 정수형 - TINYINT SMALLINT INT BIGINT
USE market_db;
CREATE TABLE hongong4 (
	tinyint_col 	TINYINT,
    smallint_col 	SMALLINT,
    int_col			INT,
    bigint_col		BIGINT
);

# 각 열의 최대값을 입력
INSERT INTO hongong3 VALUES(127, 32767, 2147483647, 9000000000000000000);
# 각 열의 최대값 + 1
INSERT INTO hongong3 VALUES(128, 32768, 2147483648, 90000000000000000000);


# UNSIGNED - 범위가 0부터 시작
CREATE TABLE member (
	mem_id  	CHAR(8) NOT NULL PRIMARY KEY,
    mem_name    VARCHAR(10) NOT NULL, 
    mem_number	TINYINT NOT NULL, 
    addr	  	CHAR(2) NOT NULL, 
	phone1		CHAR(3), 
	phone2		CHAR(8), 
	height    	TINYINT UNSIGNED,
	debut_date	DATE 
);


# 대량의 데이터 형식
CREATE DATABASE netflix_db;
USE netflix_db;
CREATE TABLE movie (
	movie_id		INT,
    movie_title		VARCHAR(30),
    movie_director	VARCHAR(20),
    movie_star		VARCHAR(20),
    movie_script	LONGTEXT,
    movie_file		LONGBLOB
);

# 변수의 사용
USE market_db;
SET @myVar1 = 5;
SET @myVar2 = 4.25;

SELECT @myVar1;
SELECT @myVar1 + @myVar2;

SET @txt = '가수 이름 ==>';
SET @height = 166;
SELECT @txt, mem_name FROM member WHERE height > @height;

SET @count = 3;
PREPARE mySQL FROM 'SELECT mem_name, height FROM member ORDER BY height LIMIT ?';
EXECUTE mySQL USING @count;

# 데이터 형 변환
SELECT CAST(AVG(price) AS SIGNED) '평균 가격' FROM buy;
SELECT CONVERT(AVG(price), SIGNED) '평균 가격' FROM buy;

SELECT CAST('2022$12$12' AS DATE);
SELECT CAST('2022/12/12' AS DATE);
SELECT CAST('2022%12%12' AS DATE);
SELECT CAST('2022@12@12' AS DATE);

SELECT num, CONCAT(CAST(price AS CHAR), 'X', CAST(amount AS CHAR), '=')
	'가격 X 수량', price * amount '구매액'
	FROM buy;


SELECT CONCAT(100, '200');
SELECT 100 + '200';


USE market_db;
SELECT *
	FROM buy
		INNER JOIN member
        ON buy.mem_id = member.mem_id
	WHERE buy.mem_id = 'GRL';
    
# 내부 조인의 간결한 표현
# mem_id의 테이블이 불확실하여 오류 발생
SELECT mem_id, mem_name, prod_name, addr, CONCAT(phone1, phone2) '연락처'
	FROM buy
		INNER JOIN member
		ON buy.mem_id = member.mem_id;
        
SELECT buy.mem_id, mem_name, prod_name, addr, CONCAT(phone1, phone2) '연락처'
	FROM buy
		INNER JOIN member
		ON buy.mem_id = member.mem_id;
        
# 별칭 지정
SELECT B.mem_id, M.mem_name, B.prod_name, M.addr, CONCAT(phone1, phone2) '연락처'
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id;
        
# 내부 조인의 활용
SELECT B.mem_id, M.mem_name, B.prod_name, M.addr
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id
	ORDER BY M.mem_id;
    
# 중복된 결과 1개만 출력
SELECT DISTINCT M.mem_id, M.mem_name, M.addr
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id
	ORDER BY M.mem_id;
    

# 외부 조인
SELECT M.mem_id, M.mem_name, B.prod_name, M.addr
	FROM member M
		LEFT OUTER JOIN buy B
        ON M.mem_id = B.mem_id
	ORDER BY M.mem_id;

SELECT M.mem_id, M.mem_name, B.prod_name, M.addr
	FROM member M
		RIGHT OUTER JOIN buy B
        ON M.mem_id = B.mem_id
	ORDER BY M.mem_id;
    

# 외부 조인의 활용
SELECT DISTINCT M.mem_id, B.prod_name, M.mem_name, M.addr
	FROM member M
		LEFT OUTER JOIN buy B
        ON M.mem_id = B.mem_id
	WHERE B.prod_name IS NULL
	ORDER BY M.mem_id;
    
# 상호 조인
SELECT *
	FROM buy
		CROSS JOIN member;
        
CREATE TABLE cross_table
	SELECT *
		FROM sakila.actor				-- 200개
			CROSS JOIN world.country;	-- 239개
SELECT COUNT(*) FROM cross_table;


CREATE TABLE emp_table (emp CHAR(4), manager CHAR(4), phone VARCHAR(8));
INSERT INTO emp_table VALUES('대표', NULL, '0000');
INSERT INTO emp_table VALUES('영업이사', '대표', '1111');
INSERT INTO emp_table VALUES('관리이사', '대표', '2222');
INSERT INTO emp_table VALUES('정보이사', '대표', '3333');
INSERT INTO emp_table VALUES('영업과장', '영업이사', '1111-1');
INSERT INTO emp_table VALUES('경리부장', '관리이사', '2222-1');
INSERT INTO emp_table VALUES('인사부장', '관리이사', '2222-2');
INSERT INTO emp_table VALUES('개발팀장', '정보이사', '3333-1');
INSERT INTO emp_table VALUES('개발주임', '정보이사', '3333-1-1');

# 자체 조인
SELECT A.emp '직원', B.emp '직속상관', B.phone '직속상관연락처'
	FROM emp_table A
		INNER JOIN emp_table B
        ON A.manager = B.emp
	WHERE A.emp = '경리부장';
    
    
# IF
DROP PROCEDURE IF EXISTS ifProc1;
DELIMITER $$
CREATE PROCEDURE ifProc1()
BEGIN
	IF 100 = 100 THEN
		SELECT '100은 100과 같습니다';
	END IF;
END $$
DELIMITER ;

CALL ifProc1();

# IF ~ ELSE
DROP PROCEDURE IF EXISTS ifProc2;
DELIMITER $$
CREATE PROCEDURE ifProc2()
BEGIN
	DECLARE myNum INT;
    SET myNum = 200;
    IF myNum = 100 THEN
		SELECT '100입니다';
	ELSE
		SELECT '100이 아닙니다';
	END IF;
END $$
DELIMITER ;

CALL ifProc2();

# IF 활용
DROP PROCEDURE IF EXISTS ifProc3;
DELIMITER $$
CREATE PROCEDURE ifProc3()
BEGIN
	DECLARE debutDate DATE;
    DECLARE curDate DATE;
    DECLARE days INT;
    SELECT debut_date INTO debutDate
		FROM market_db.member
        WHERE mem_id = 'APN';
        
	SET curDate = CURRENT_DATE();
    SET days = DATEDIFF(curDate, debutDate);
    
    IF (days / 365) >= 5 THEN
		SELECT 'Good!';
	ELSE
		SELECT 'Bad!';
	END IF;
END $$
DELIMITER ;

CALL ifProc3();

SELECT CURRENT_DATE(), DATEDIFF('2021-12-31', '2000-1-1');




###### test
USE market_db;
SHOW TABLES;
SELECT * FROM buy;
SELECT * FROM member;

# Q1) 구매 금액이 1000원 이상인 회원 이름과 구매물품명, 구매 금액을 조회 하시오.
SELECT mem_name, prod_name, price
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id;
	
# Q2) 구매 분류가 디지털인 항목을 구매한 회원 명, 전화번호, 구매분류, 물품명, 구매금액을 조회하시오.
SELECT mem_name, CONCAT(phone1, phone2), group_name, prod_name, price
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id
	WHERE group_name = '디지털';
    
# Q3) 인원이 6명 이상인 회원이 구매한 물품, 회원명, 회원수, 구매금액을 가격 높은순으로 조회 하시오.
SELECT prod_name, mem_name, mem_number, price
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id
	WHERE M.mem_number >= 6
    ORDER BY price DESC;
    
# Q4) 가장 비싼 단가를 가진 물품을 구매한 회원의 회원명, 구매단가, 구매물품, 국번전화번호, 평균키, 데뷔 일자를 구하시오. 국번전화번호의 값은 중간에 '-' 으로 연결, 나온 결과값의 정렬은 데뷔 일자가 가장 빠른 순으로 구하시오.
SELECT mem_name, price, prod_name, CONCAT(phone1, '-', phone2), height, debut_date
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id
	ORDER BY debut_date ASC;
        
# Q5) 키가 165 이하이고 총 구매 금액이 500이 넘는 회원의 회원 아이디, 회원 키, 총구매 금액을 총 구매 수량이 많은 순으로 탑3 까지 조회
SELECT B.mem_id, height, SUM(price * amount)
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id
	WHERE height <= 165
    GROUP BY B.mem_id, height
    HAVING SUM(price * amount) > 500;
		
# Q6) 서울 출생이고 구매하지 않는 회원의 회원 아이디, 데뷔일자를 데뷔 일자가 빠른 순으로 탑2 까지 조회
SELECT M.mem_id, debut_date
	FROM member M
		LEFT OUTER JOIN buy B
        ON M.mem_id = B.mem_id
	WHERE addr = '서울' AND price IS NULL
    ORDER BY debut_date
    LIMIT 2;
    
# Q7) 멤버 이름이 4글자인 멤버의 총 평균 키를 조회하시오
SELECT mem_name, AVG(height)
	FROM member
    WHERE mem_name LIKE '____'
    GROUP BY mem_name;

# Q8) 서적을 구매한 회원 네임과 멤버의 전화번호, 환불할 총 구매 금액을 조회 하시오.
SELECT mem_name, CONCAT(phone1, phone2), SUM(price * amount)
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id
	WHERE group_name = '서적'
    GROUP BY mem_name, CONCAT(phone1, phone2);
    
# Q9
INSERT INTO member VALUES('IZO', '아이즈원', 10, '거제', NULL, NULL, 170, '2018-10-29');
INSERT INTO buy VALUES(13, 'IZO', '에어팟', '디지털', 80, 3);
INSERT INTO buy VALUES(13, 'IZO', '청바지', '패션', 50, 3);

# Q10
UPDATE member
	SET height = 166
    WHERE mem_name = '마마무';