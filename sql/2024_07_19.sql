# CASE
DROP PROCEDURE IF EXISTS caseProc;
DELIMITER $$
CREATE PROCEDURE caseProc()
BEGIN
	DECLARE point INT;
    DECLARE credit CHAR(1);
    SET point = 88;
    
    CASE
		WHEN point >= 90 THEN
			SET credit = 'A';
		WHEN point >= 80 THEN
			SET credit = 'B';
		WHEN point >= 70 THEN
			SET credit = 'C';
		WHEN point >= 60 THEN
			SET credit = 'D';
		ELSE
			SET credit = 'F';
	END CASE;
    SELECT CONCAT('취득 점수 ==> ', point), CONCAT('학점 ==> ', credit);
END $$
DELIMITER ;

CALL caseProc();

# CASE 활용
# GROUP BY
SELECT mem_id, SUM(price * amount) '총 구매액'
	FROM buy
    GROUP BY mem_id;
    
# ORDER BY
SELECT mem_id, SUM(price * amount) '총 구매액'
	FROM buy
    GROUP BY mem_id
    ORDER BY SUM(price * amount) DESC;

# INNER JOIN
SELECT B.mem_id, M.mem_name, SUM(price * amount) '총 구매액'
	FROM buy B
		INNER JOIN member m
        ON B.mem_id = M.mem_id
	GROUP BY B.mem_id
    ORDER BY SUM(price * amount) DESC;
    
# OUTER JOIN
SELECT M.mem_id, M.mem_name, SUM(price * amount) '총 구매액'
	FROM buy B
		RIGHT OUTER JOIN member m
        ON B.mem_id = M.mem_id
	GROUP BY M.mem_id
    ORDER BY SUM(price * amount) DESC;

SELECT M.mem_id, M.mem_name, SUM(price * amount) '총 구매액',
	CASE
		WHEN (SUM(price * amount) >= 1500) THEN '최우수고객'
		WHEN (SUM(price * amount) >= 1000) THEN '우수고객'
		WHEN (SUM(price * amount) >= 1) THEN '일반고객'
		ELSE '유령고객'
	END '회원등급'
	FROM buy B
		RIGHT OUTER JOIN member M
        ON B.mem_id = M.mem_id
	GROUP BY M.mem_id
    ORDER BY SUM(price * amount) DESC;

# WHILE
DROP PROCEDURE IF EXISTS whileProc;
DELIMITER $$
CREATE PROCEDURE whileProc()
BEGIN
	DECLARE i INT;					-- 1에서 100까지 증가할 변수
    DECLARE hap INT;				-- 더한 값을 누적할 변수
	SET i = 1;
    SET hap = 0;
    
    WHILE (i <= 100) DO
		SET hap = hap + i;
        SET i = i + 1;
	END WHILE;
    SELECT '1부터 100까지의 합 ==> ', hap;
END $$
DELIMITER ;

CALL whileProc();

# WHILE 응용
DROP PROCEDURE IF EXISTS whileProc2;
DELIMITER $$
CREATE PROCEDURE whileProc2()
BEGIN
	DECLARE i INT;
    DECLARE hap INT;
    SET i = 1;
    SET hap = 0;
    
    myWhile:
    WHILE (i <= 100) DO
		IF (i % 4 = 0) THEN
			SET i = i + 1;
            ITERATE myWhile;
		END IF;
        SET hap = hap + i;
        
        IF (hap > 1000) THEN
			LEAVE myWhile;
		END IF;
        SET i = i + 1;
	END WHILE;
    
    SELECT '1부터 100까지의 합(4의 배수 제외), 1000 넘으면 종료 ==> ', hap;
    
END $$
DELIMITER ;

CALL whileProc2();

# 동적 SQL
# PREPARE, EXECUTE
PREPARE myQuery FROM 'SELECT * FROM member WHERE mem_id = "BLK"';
EXECUTE myQuery;
DEALLOCATE PREPARE myQuery;

# 동적 SQL 활용
DROP TABLE IF EXISTS gate_table;
CREATE TABLE gate_table (id INT AUTO_INCREMENT PRIMARY KEY, entry_time DATETIME);

SET @curDate = CURRENT_TIMESTAMP();		-- 현재 날짜와 시간

PREPARE myQuery FROM 'INSERT INTO gate_table VALUES(NULL, ?)';
EXECUTE myQuery USING @curDate;
DEALLOCATE PREPARE myQuery;

SELECT * FROM gate_table;


# FOREIGN KEY
DROP DATABASE IF EXISTS naver_db;
CREATE DATABASE naver_db;

DROP TABLE IF EXISTS member;
CREATE TABLE member -- 회원 테이블
( mem_id  		CHAR(8) NOT NULL PRIMARY KEY, -- 사용자 아이디(PK)
  mem_name    	VARCHAR(10) NOT NULL, -- 이름
  mem_number    INT NOT NULL,  -- 인원수
  addr	  		CHAR(2) NOT NULL, -- 지역(경기,서울,경남 식으로 2글자만입력)
  phone1		CHAR(3), -- 연락처의 국번(02, 031, 055 등)
  phone2		CHAR(8), -- 연락처의 나머지 전화번호(하이픈제외)
  height    	SMALLINT,  -- 평균 키
  debut_date	DATE  -- 데뷔 일자
);
DROP TABLE IF EXISTS buy;
# AUTO_INCREMENT로 지정한 열은 PRIMARY KEY나 UNIQUE로 지정해줘야함
CREATE TABLE buy -- 구매 테이블
(  num 		INT AUTO_INCREMENT NOT NULL PRIMARY KEY, -- 순번(PK)
   mem_id  	CHAR(8) NOT NULL, -- 아이디(FK)
   prod_name 	CHAR(6) NOT NULL, --  제품이름
   group_name 	CHAR(4)  , -- 분류
   price     	INT  NOT NULL, -- 가격
   amount    	SMALLINT  NOT NULL, -- 수량
   FOREIGN KEY (mem_id) REFERENCES member(mem_id)
);


INSERT INTO member VALUES('TWC', '트와이스', 9, '서울', '02', '11111111', 167, '2015.10.19');
INSERT INTO member VALUES('BLK', '블랙핑크', 4, '경남', '055', '22222222', 163, '2016.08.08');
INSERT INTO member VALUES('WMN', '여자친구', 6, '경기', '031', '33333333', 166, '2015.01.15');

INSERT INTO buy VALUES(NULL, 'BLK', '지갑', NULL, 30, 2);
INSERT INTO buy VALUES(NULL, 'BLK', '맥북프로', '디지털', 1000, 1);
# 'APN'이 회원 테이블에 존재하지 않아서 오류 발생 (외래키)
INSERT INTO buy VALUES(NULL, 'APN', '아이폰', '디지털', 200, 1);
# 'APN'을 회원 테이블에 입력
INSERT INTO member VALUES('APN', '에이핑크', 6, '경기', '031', '77777777', 164, '2011.02.10');
INSERT INTO buy VALUES(NULL, 'APN', '아이폰', '디지털', 200, 1);



# 기본 키 제약조건
USE naver_db;
DROP TABLE IF EXISTS member;
CREATE TABLE member(
	mem_id CHAR(8) NOT NULL PRIMARY KEY
);

DROP TABLE IF EXISTS member;
CREATE TABLE member(
	mem_id CHAR(8) NOT NULL,
    PRIMARY KEY (mem_id)
);

# DESCRIBE
DESCRIBE member;

# ALTER TABLE
DROP TABLE IF EXISTS member;
CREATE TABLE member(
	mem_id CHAR(8) NOT NULL
);
ALTER TABLE member
	ADD CONSTRAINT
    PRIMARY KEY (mem_id);
    
# 기본 키에 이름 저장
DROP TABLE IF EXISTS member;
CREATE TABLE member(
	mem_id CHAR(8) NOT NULL,
    CONSTRAINT PRIMARY KEY PK_member_mem_id (mem_id)
);


# 외래 키 제약조건
DROP TABLE IF EXISTS member, buy;
CREATE TABLE member(
	mem_id CHAR(8) NOT NULL PRIMARY KEY
);
CREATE TABLE buy(
	mem_id CHAR(8) NOT NULL,
    FOREIGN KEY (mem_id) REFERENCES member(mem_id)
);

# ALTER TABLE
DROP TABLE IF EXISTS member, buy;
CREATE TABLE member(
	mem_id  CHAR(8) NOT NULL PRIMARY KEY, 
	mem_name VARCHAR(10) NOT NULL,
	height INT NOT NULL
);
CREATE TABLE buy(
	num INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
	mem_id CHAR(8) NOT NULL,
    prod_name CHAR(6) NOT NULL
);
ALTER TABLE buy
	ADD CONSTRAINT
    FOREIGN KEY (mem_id)
    REFERENCES member(mem_id);

# 기준 테이블의 열이 변경될 경우
INSERT INTO member VALUES('BLK', '블랙핑크', 163);
INSERT INTO buy VALUES(NULL, 'BLK', '지갑');
INSERT INTO buy VALUES(NULL, 'BLK', '맥북');

SELECT M.mem_id, M.mem_name, B.prod_name
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id;

# 기본 키-외래 키 관계가 설정되면 기준 테이블의 열은 변경, 삭제가 불가
UPDATE member SET mem_id = 'PINK' WHERE mem_id = 'BLK';
DELETE FROM member WHERE mem_id = 'PINK';


# ON UPDATE CASCADE, ON DELETE CASCADE
DROP TABLE IF EXISTS buy;
CREATE TABLE buy(
	num INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    mem_id CHAR(8) NOT NULL,
    prod_name CHAR(6) NOT NULL
);
ALTER TABLE buy
	ADD CONSTRAINT
	FOREIGN KEY (mem_id) REFERENCES member(mem_id)
    ON UPDATE CASCADE
    ON DELETE CASCADE;

INSERT INTO buy VALUES(NULL, 'BLK', '지갑');
INSERT INTO buy VALUES(NULL, 'BLK', '맥북');

UPDATE member SET mem_id = 'PINK' WHERE mem_id = 'BLK';

SELECT M.mem_id, M.mem_name, B.prod_name
	FROM buy B
		INNER JOIN member M
        ON B.mem_id = M.mem_id;
        
DELETE FROM member WHERE mem_id = 'PINK';

SELECT * FROM buy;

# 고유 키 제약조건
DROP TABLE IF EXISTS member;
CREATE TABLE member(
	mem_id  CHAR(8) NOT NULL PRIMARY KEY, 
	mem_name VARCHAR(10) NOT NULL,
	height INT NOT NULL,
    email  CHAR(30) NULL UNIQUE
);

INSERT INTO member VALUES('BLK', '블랙핑크', 163, 'abc@naver.com');
# 공백 가능
INSERT INTO member VALUES('TWC', '트와이스', 167, NULL);
# 중복 불가
INSERT INTO member VALUES('APN', '에이핑크', 163, 'abc@naver.com');

# 체크 제약조건
DROP TABLE IF EXISTS member;
CREATE TABLE member(
	mem_id  CHAR(8) NOT NULL PRIMARY KEY, 
	mem_name VARCHAR(10) NOT NULL,
	height INT NOT NULL CHECK (height >= 100),
    phone  CHAR(3) NULL
);

INSERT INTO member VALUES('BLK', '블랙핑크', 163, NULL);
# 설정한 값의 범위를 벗어나 오류 발생
INSERT INTO member VALUES('TWC', '트와이스', 99, NULL);

ALTER TABLE member
	ADD CONSTRAINT
    CHECK (phone IN ('02', '031', '055'));
    
INSERT INTO member VALUES('OMG', '오마이걸', 163, '02');
# 설정한 값의 범위를 벗어나 오류 발생
INSERT INTO member VALUES('TWC', '트와이스', 167, '010');

# 기본 값 정의
DROP TABLE IF EXISTS member;
CREATE TABLE member(
	mem_id  CHAR(8) NOT NULL PRIMARY KEY, 
	mem_name VARCHAR(10) NOT NULL,
	height INT NOT NULL DEFAULT 160,
    phone  CHAR(3) NULL
);
ALTER TABLE member
	ALTER COLUMN phone SET DEFAULT '02';

INSERT INTO member VALUES('OMG', '오마이걸', 163, '031');
INSERT INTO member VALUES('TWC', '트와이스', default, default);
SELECT * FROM member;



# VIEW
USE market_db;
CREATE VIEW v_member
AS
	SELECT mem_id, mem_name, addr FROM member;

SELECT * FROM v_member;
SELECT mem_name, addr FROM v_member WHERE addr IN ('서울', '경기');

# VIEW는 복잡한 SQL을 단순화
CREATE VIEW v_memberbuy
AS
	SELECT B.mem_id, M.mem_name, B.prod_name
		FROM buy B
			INNER JOIN member M
            ON B.mem_id = M.mem_id;
SELECT * FROM v_memberbuy WHERE mem_name = '블랙핑크';

# 뷰의 실제 생성, 수정, 삭제
CREATE VIEW v_view1
AS
	SELECT B.mem_id 'Member ID', M.mem_name AS 'Member Name', B.prod_name 'Product Name'
		FROM buy B
			INNER JOIN member M
            ON B.mem_id = M.mem_id;
SELECT DISTINCT `Member ID`, `Member Name` FROM v_view1;


ALTER VIEW v_view1
AS
	SELECT B.mem_id '회원 아이디', M.mem_name AS '회원 이름', B.prod_name '제품 이름'
		FROM buy B
			INNER JOIN member M
            ON B.mem_id = M.mem_id;
SELECT DISTINCT `회원 아이디`, `회원 이름` FROM v_view1;

DROP VIEW v_view1;

# 뷰의 정보 확인
# CREATE OR REPLACE VIEW - 기존에 뷰가 있어도 덮어쓰는 효과로 오류가 발생하지 않는다
CREATE OR REPLACE VIEW v_view2
AS
	SELECT mem_id, mem_name, addr FROM member;

# 기본 키 등의 정보는 확인 불가
DESCRIBE v_view2;
DESCRIBE member;

SHOW CREATE VIEW v_view2;

# 뷰를 통한 데이터의 수정/삭제
UPDATE v_member SET addr = '부산' WHERE mem_id = 'BLK';
# member에서 mem_number이 NOT NULL이라 오류 발생
INSERT INTO v_member(mem_id, mem_name, addr) VALUES('BTS', '방탄소년단', '경기');

CREATE VIEW v_height167
AS
	SELECT * FROM member WHERE height >= 167;
SELECT * FROM v_height167;

DELETE FROM v_height WHERE height < 167;

INSERT INTO v_height167 VALUES('TRA', '티아라', 6, '서울', NULL, NULL, 159, '2005-01-01');

SELECT * FROM v_height167;

# WITH CHECK OPTION
ALTER VIEW v_height167
AS
	SELECT * FROM member WHERE height >= 167
		WITH CHECK OPTION;
INSERT INTO v_height167 VALUES('TOB', '텔레토비', 4, '영국',NULL, NULL, 140, '1995-01-01');


# 복합 뷰
CREATE VIEW v_complex
AS
	SELECT B.mem_id, M.mem_name, B.prod_name
		FROM buy B
			INNER JOIN member M
			ON B.mem_id = M.mem_id;
            
# 뷰가 참조하는 테이블 삭제
DROP TABLE IF EXISTS buy, member;
# 테이블은 뷰가 참조하고 있어도 삭제
SELECT * FROM v_height167;
CHECK TABLE v_height167;




# 자동으로 생성되는 인덱스 - 클러스터형 인덱스
# 고유 인덱스
CREATE TABLE table1 (
	col1 INT PRIMARY KEY,
    col2 INT,
    col3 INT
);

# key_name = PRIMARY
SHOW INDEX FROM table1;

# 고유 키로 생성되는 인덱스는 보조 인덱스
CREATE TABLE table2 (
	col1 INT PRIMARY KEY,
    col2 INT UNIQUE,
    col3 INT UNIQUE
);

# key_name = column_name
SHOW INDEX FROM table2;

# 자동으로 정렬되는 클러스터형 인덱스
DROP TABLE IF EXISTS member, buy;
CREATE TABLE member(
	mem_id  CHAR(8),
	mem_name VARCHAR(10),
	mem_number INT
);

INSERT INTO member VALUES('TWC', '트와이스', 9);
INSERT INTO member VALUES('BLK', '블랙핑크', 4);
INSERT INTO member VALUES('WMN', '여자친구', 6);
INSERT INTO member VALUES('GRL', '소녀시대', 8);
SELECT * FROM member;

ALTER TABLE member
	ADD CONSTRAINT
    PRIMARY KEY(mem_id);
SELECT * FROM member;

# 기본 키 제거
ALTER TABLE member DROP PRIMARY KEY;
# 클러스터형 인덱스 생성
ALTER TABLE member
	ADD CONSTRAINT
    PRIMARY KEY(mem_name);
SELECT * FROM member;

INSERT INTO member VALUES('GRD', '걸스데이', 5);
SELECT * FROM member;


# 정렬되지 않는 보조 인덱스
DROP TABLE IF EXISTS member;
CREATE TABLE member (
	mem_id 		CHAR(8),
    mem_name 	VARCHAR(10),
    mem_number 	INT,
    addr 		CHAR(2)
);

INSERT INTO member VALUES('TWC', '트와이스', 9, '서울');
INSERT INTO member VALUES('BLK', '블랙핑크', 4, '경남');
INSERT INTO member VALUES('WMN', '여자친구', 6, '경기');
INSERT INTO member VALUES('OMY', '오마이걸', 7, '서울');
SELECT * FROM member;

# 보조 인덱스를 생성해도 데이터의 순서는 변경되지 않고 별도로 인덱스를 만든다
ALTER TABLE member
	ADD CONSTRAINT
    UNIQUE (mem_id);
SELECT * FROM member;

ALTER TABLE member
	ADD CONSTRAINT
    UNIQUE (mem_name);
SELECT * FROM member;

# 보조 인덱스는 여러개 생성 가능
# 보조 인덱스를 만들 때마다 데이터베이스의 공간을 차지하게 되고 시스템에 악영향
INSERT INTO member VALUES('GRL', '소녀시대', 8, '서울');
SELECT * FROM member;





# 구구단 구하기
DELIMITER //
CREATE PROCEDURE gugudan()
BEGIN
	DROP TABLE IF EXISTS gugudan1;
	CREATE TABLE gugudan1 (Dan INT);
	DROP TABLE IF EXISTS gugudan2;
	CREATE TABLE gugudan2 (Gop INT);
    
    INSERT INTO gugudan1 VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9);
    INSERT INTO gugudan2 VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9);
    
    SELECT Dan, Gop, Dan * Gop
		FROM gugudan1
			CROSS JOIN gugudan2
		WHERE Dan BETWEEN 2 AND 9
		ORDER BY Dan, Gop;
END //
DELIMITER ;

CALL gugudan();

# WHILE 사용
DROP PROCEDURE IF EXISTS gugudan;
DELIMITER //
CREATE PROCEDURE gugudan()
BEGIN
	DECLARE i INT;
    SET i = 1;
	
    DROP TABLE IF EXISTS gugudan1;
	CREATE TABLE gugudan1 (Dan INT);
	DROP TABLE IF EXISTS gugudan2;
	CREATE TABLE gugudan2 (Gop INT);
    
    WHILE (i <= 9) DO
		INSERT INTO gugudan1 VALUES(i);
        INSERT INTO gugudan2 VALUES(i);
        SET i = i + 1;
	END WHILE;
  
    SELECT Dan, Gop, Dan * Gop
		FROM gugudan1
			CROSS JOIN gugudan2
		WHERE Dan BETWEEN 2 AND 9
		ORDER BY Dan, Gop;
END //
DELIMITER ;

CALL gugudan();

DROP PROCEDURE IF EXISTS gugudan;
DELIMITER //
CREATE PROCEDURE gugudan()
BEGIN
	DECLARE i INT;
    DECLARE j INT;
    SET i = 1;
    CREATE TABLE gugudan (DAN INT, GOP INT);
    WHILE (i <= 9) DO
		SET j = 1;
		WHILE (j <= 9) DO
			INSERT INTO gugudan VALUES(i, j);
            SET j = j + 1;
		END WHILE;
        SET i = i + 1;
	END WHILE;
	SELECT DAN, GOP, DAN * GOP
		FROM gugudan;
END //
DELIMITER ;

CALL gugudan();