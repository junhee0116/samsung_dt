USE market_db;
CREATE TABLE cluster (
	mem_id 		CHAR(8),
    mem_name 	VARCHAR(10)
);

INSERT INTO cluster VALUES('TWC', '트와이스');
INSERT INTO cluster VALUES('BLK', '블랙핑크');
INSERT INTO cluster VALUES('WMN', '여자친구');
INSERT INTO cluster VALUES('OMY', '오마이걸');
INSERT INTO cluster VALUES('GRL', '소녀시대');
INSERT INTO cluster VALUES('ITZ', '잇지');
INSERT INTO cluster VALUES('RED', '레드벨벳');
INSERT INTO cluster VALUES('APN', '에이핑크');
INSERT INTO cluster VALUES('SPC', '우주소녀');
INSERT INTO cluster VALUES('MMU', '마마무');

SELECT * FROM cluster;
# 클러스터형 인덱스 구성
ALTER TABLE cluster
	ADD CONSTRAINT
    PRIMARY KEY (mem_id);
SELECT * FROM cluster;


CREATE TABLE second (
	mem_id 		CHAR(8),
    mem_name 	VARCHAR(10)
);

INSERT INTO second VALUES('TWC', '트와이스');
INSERT INTO second VALUES('BLK', '블랙핑크');
INSERT INTO second VALUES('WMN', '여자친구');
INSERT INTO second VALUES('OMY', '오마이걸');
INSERT INTO second VALUES('GRL', '소녀시대');
INSERT INTO second VALUES('ITZ', '잇지');
INSERT INTO second VALUES('RED', '레드벨벳');
INSERT INTO second VALUES('APN', '에이핑크');
INSERT INTO second VALUES('SPC', '우주소녀');
INSERT INTO second VALUES('MMU', '마마무');

# 보조인덱스 구성
ALTER TABLE second
	ADD CONSTRAINT
    UNIQUE (mem_id);
SELECT * FROM second;



USE market_db;
SELECT * FROM member;

# 테이블에 생성된 인덱스 정보
SHOW INDEX FROM member;
# 테이블에 생성된 인덱스의 크기 확인
SHOW TABLE STATUS LIKE 'member';

# 중복을 허용하는 단순 보조 인덱스를 생성
CREATE INDEX idx_member_addr 
   ON member (addr);

# Non_unique = 1 이면 중복을 허용한다는 의미로 고유 보조 인덱스가 아니라는 것
SHOW INDEX FROM member;
SHOW TABLE STATUS LIKE 'member';

# 인덱스를 실제로 적용하기 위해 사용
ANALYZE TABLE member;
SHOW TABLE STATUS LIKE 'member';

# 중복된 값이 있어 중복을 허용하지 않는 고유 보조 인덱스 생성 불가하므로 오류 발생
CREATE UNIQUE INDEX idx_member_mem_number
    ON member (mem_number);

# Non_unique = 0 이면 중복을 허용하지 않는다는 의미로 고유 보조 인덱스
CREATE UNIQUE INDEX idx_member_mem_name
    ON member (mem_name);

SHOW INDEX FROM member;

INSERT INTO member VALUES('MOO', '마마무', 2, '태국', '001', '12341234', 155, '2020.10.10');

ANALYZE TABLE member;
SHOW INDEX FROM member;


# Full Table Scan
SELECT * FROM member;

# Full Table Scan
SELECT mem_id, mem_name, addr FROM member;

# Single Row (Constant)
SELECT mem_id, mem_name, addr 
    FROM member 
    WHERE mem_name = '에이핑크';
    
    
CREATE INDEX idx_member_mem_number
    ON member (mem_number);
ANALYZE TABLE member;

# Index Range Scan
SELECT mem_name, mem_number 
    FROM member 
    WHERE mem_number >= 7; 

# 인덱스 검색보다는 전체 테이블 검색이 낫다고 생각하여 Full Table Scan
SELECT mem_name, mem_number 
    FROM member 
    WHERE mem_number >= 1; 

# WHERE 문에서 열에 연산이 가해지면 인덱스를 사용하지 않는다
SELECT mem_name, mem_number 
    FROM member 
    WHERE mem_number*2 >= 14;     
# 다음과 같이 수정하면 인덱스를 사용
SELECT mem_name, mem_number 
    FROM member 
    WHERE mem_number >= 14/2;   
    
SHOW INDEX FROM member;

DROP INDEX idx_member_mem_name ON member;
DROP INDEX idx_member_addr ON member;
DROP INDEX idx_member_mem_number ON member;

ALTER TABLE member 
    DROP PRIMARY KEY;


SELECT table_name, constraint_name
    FROM information_schema.referential_constraints
    WHERE constraint_schema = 'market_db';

ALTER TABLE buy 
    DROP FOREIGN KEY buy_ibfk_1;
ALTER TABLE member 
    DROP PRIMARY KEY;

    
SELECT mem_id, mem_name, mem_number, addr 
    FROM member 
    WHERE mem_name = '에이핑크';
    
    
    
    
    
USE market_db;
DROP PROCEDURE IF EXISTS user_proc;
DELIMITER $$
CREATE PROCEDURE user_proc()
BEGIN
    SELECT * FROM member; -- 스토어드 프로시저 내용
END $$
DELIMITER ;

CALL user_proc();

DROP PROCEDURE user_proc;

USE market_db;
DROP PROCEDURE IF EXISTS user_proc1;
DELIMITER $$
CREATE PROCEDURE user_proc1(IN userName VARCHAR(10))
BEGIN
  SELECT * FROM member WHERE mem_name = userName; 
END $$
DELIMITER ;

CALL user_proc1('에이핑크');


DROP PROCEDURE IF EXISTS user_proc2;
DELIMITER $$
CREATE PROCEDURE user_proc2(
    IN userNumber INT, 
    IN userHeight INT  )
BEGIN
  SELECT * FROM member 
    WHERE mem_number > userNumber AND height > userHeight;
END $$
DELIMITER ;

CALL user_proc2(6, 165);


DROP PROCEDURE IF EXISTS user_proc3;
DELIMITER $$
CREATE PROCEDURE user_proc3(
    IN txtValue CHAR(10),
    OUT outValue INT     )
BEGIN
  INSERT INTO noTable VALUES(NULL,txtValue);
  SELECT MAX(id) INTO outValue FROM noTable; 
END $$
DELIMITER ;

DESC noTable;


CREATE TABLE IF NOT EXISTS noTable(
    id INT AUTO_INCREMENT PRIMARY KEY, 
    txt CHAR(10)
);

CALL user_proc3 ('테스트1', @myValue);
SELECT CONCAT('입력된 ID 값 ==>', @myValue);

DROP PROCEDURE IF EXISTS ifelse_proc;
DELIMITER $$
CREATE PROCEDURE ifelse_proc(
    IN memName VARCHAR(10)
)
BEGIN
    DECLARE debutYear INT; -- 변수 선언
    SELECT YEAR(debut_date) into debutYear FROM member
        WHERE mem_name = memName;
    IF (debutYear >= 2015) THEN
            SELECT '신인 가수네요. 화이팅 하세요.' AS '메시지';
    ELSE
            SELECT '고참 가수네요. 그동안 수고하셨어요.'AS '메시지';
    END IF;
END $$
DELIMITER ;

CALL ifelse_proc ('오마이걸');

SELECT YEAR(CURDATE()), MONTH(CURDATE()), DAY(CURDATE());


DROP PROCEDURE IF EXISTS while_proc;
DELIMITER $$
CREATE PROCEDURE while_proc()
BEGIN
    DECLARE hap INT; -- 합계
    DECLARE num INT; -- 1부터 100까지 증가
    SET hap = 0; -- 합계 초기화
    SET num = 1; 
    
    WHILE (num <= 100) DO  -- 100까지 반복.
        SET hap = hap + num;
        SET num = num + 1; -- 숫자 증가
    END WHILE;
    SELECT hap AS '1~100 합계';
END $$
DELIMITER ;

CALL while_proc();


DROP PROCEDURE IF EXISTS dynamic_proc;
DELIMITER $$
CREATE PROCEDURE dynamic_proc(
    IN tableName VARCHAR(20)
)
BEGIN
  SET @sqlQuery = CONCAT('SELECT * FROM ', tableName);
  PREPARE myQuery FROM @sqlQuery;
  EXECUTE myQuery;
  DEALLOCATE PREPARE myQuery;
END $$
DELIMITER ;

CALL dynamic_proc ('member');





# 스토어드 함수 생성 권한을 허용
SET GLOBAL log_bin_trust_function_creators = 1;

# 스토어드 함수의 사용
USE market_db;
DROP FUNCTION IF EXISTS sumfunc;
DELIMITER $$
CREATE FUNCTION sumfunc(number1 INT, number2 INT)
	RETURNS INT
BEGIN
	RETURN number1 + number2;
END $$
DELIMITER ;

SELECT sumfunc(100, 200);


DROP FUNCTION IF EXISTS calcyearfun;
DELIMITER $$
CREATE FUNCTION calcyearfun(dyear INT)
	RETURNS INT
BEGIN
	DECLARE runyear INT;
    SET runyear = YEAR(CURDATE()) - dyear;
    RETURN runyear;
END $$
DELIMITER ;

SELECT calcyearfun(2010);

# SELECT ~ INTO
SELECT calcyearfun(2007) INTO @debut2007;
SELECT calcyearfun(2013) INTO @debut2013;
SELECT @debut2007 - @debut2013;

SELECT mem_id, mem_name, calcyearfun(YEAR(debut_date)) AS '활동 햇수'
	FROM member;
    

# 커서
USE market_db;
DROP PROCEDURE IF EXISTS cursor_proc;
DELIMITER $$
CREATE PROCEDURE cursor_proc()
BEGIN
	# 1. 사용할 변수 준비하기
	DECLARE memnumber INT;
    DECLARE cnt INT DEFAULT 0;
    DECLARE totnumber INT DEFAULT 0;
    DECLARE endofrow BOOLEAN DEFAULT FALSE;
    
    # 2. 커서 선언하기
    DECLARE membercursor CURSOR FOR
		SELECT mem_number FROM member;
	
	# 3. 반복 조건 선언하기
	DECLARE CONTINUE HANDLER
		FOR NOT FOUND SET endofrow = TRUE;
	
    # 4. 커서 열기
	OPEN membercursor;
    
    # 5. 행 반복하기
    cursor_loop : LOOP
	# FETCH - 한 행씩 읽어오는 것
		FETCH membercursor INTO memnumber;
        
        IF endofrow THEN
			LEAVE cursor_loop;
		END IF;
        
        SET cnt = cnt + 1;
        SET totnumber = totnumber + memnumber;
	END LOOP cursor_loop;
    
    SELECT (totnumber / cnt) AS '회원의 평균 인원 수';
    
    # 6. 커서 닫기
    CLOSE membercursor;
END $$
DELIMITER ;

CALL cursor_proc();


# 트리거 기본 작동
CREATE TABLE IF NOT EXISTS trigger_table(id INT, text VARCHAR(10));
INSERT INTO trigger_table VALUES(1, '레드벨벳');
INSERT INTO trigger_table VALUES(2, '잇지');
INSERT INTO trigger_table VALUES(3, '블랙핑크');

# 트리거 부착
DROP TRIGGER IF EXISTS mytrigger
DELIMITER $$
CREATE TRIGGER mytrigger
	AFTER DELETE
    ON trigger_table
    FOR EACH ROW
BEGIN
	SET @msg = '가수 그룹이 삭제됨';
END $$
DELIMITER ;

SET @msg = '';
INSERT INTO trigger_table VALUES(4, '마마무');
SELECT @msg;
UPDATE trigger_table SET text = '블핑' WHERE id = 3;
SELECT @msg;
DELETE FROM trigger_table WHERE id = 4;
SELECT @msg;

# 트리거 활용
CREATE TABLE singer(SELECT mem_id, mem_name, mem_number, addr FROM member);
CREATE TABLE backup_singer(
	mem_id		CHAR(8) NOT NULL,
    mem_name	VARCHAR(10) NOT NULL,
    mem_number	INT NOT NULL,
    addr		CHAR(2)	NOT NULL,
    modtype		CHAR(2),
    moddate		DATE,
    moduser		VARCHAR(30)
);


# 수정 트리거
DROP TRIGGER IF EXISTS singer_update
DELIMITER $$
CREATE TRIGGER signer_update
	AFTER UPDATE
    ON singer
    FOR EACH ROW
BEGIN
	INSERT INTO backup_singer VALUES(OLD.mem_id, OLD.mem_name, OLD.mem_number, OLD.addr, '수정', CURDATE(), CURRENT_USER());
END $$
DELIMITER ;

# 삭제 트리거
DROP TRIGGER IF EXISTS singer_delete
DELIMITER $$
CREATE TRIGGER signer_delete
	AFTER DELETE
    ON singer
    FOR EACH ROW
BEGIN
	INSERT INTO backup_singer VALUES(OLD.mem_id, OLD.mem_name, OLD.mem_number, OLD.addr, '삭제', CURDATE(), CURRENT_USER());
END $$
DELIMITER ;

UPDATE singer SET addr = '영국' WHERE mem_id = 'BLK';
DELETE FROM singer WHERE mem_number >= 7;
SELECT * FROM backup_singer;

# DELETE TRIGGER X
TRUNCATE TABLE singer;
SELECT * FROM backup_singer;


DROP PROCEDURE IF EXISTS gugudan;
DELIMITER $$
CREATE PROCEDURE gugudan(
	IN dan1 INT,
    IN dan2 INT
)
BEGIN
	DECLARE i INT;
	DECLARE j INT;
    DROP TABLE IF EXISTS gugudan;
    CREATE TABLE gugudan(DAN INT, GOP INT, DAN_GOP INT);
	WHILE (dan1 <= dan2) DO
		SET j = 1;
		WHILE (j <= 9) DO
			SET i = dan1 * j;
			INSERT INTO gugudan VALUES(dan1, j, i);
			SET j = j + 1;
		END WHILE;
		SET dan1 = dan1 + 1;
	END WHILE;
	SELECT DAN, GOP, DAN_GOP AS 'DAN * GOP' FROM gugudan;
END $$
DELIMITER ;

CALL gugudan(5, 10);
