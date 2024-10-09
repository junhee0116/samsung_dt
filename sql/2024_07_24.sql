USE market_db;

DROP TABLE IF EXISTS solve;
CREATE TABLE solve(
	problem VARCHAR(255),
    querys	VARCHAR(255)
);

INSERT INTO solve VALUES("Q1) 구매 금액이 1000원 이상인 회원 이름과 구매물품명, 구매 금액을 조회 하시오.", "SELECT mem_name, prod_name, price FROM buy B INNER JOIN member M ON B.mem_id = M.mem_id;");
INSERT INTO solve VALUES("Q2) 구매 분류가 디지털인 항목을 구매한 회원 명, 전화번호, 구매분류, 물품명, 구매금액을 조회하시오.", "SELECT mem_name, CONCAT(phone1, phone2), group_name, prod_name, price FROM buy B INNER JOIN member M ON B.mem_id = M.mem_id WHERE group_name = '디지털';");
INSERT INTO solve VALUES("Q3) 인원이 6명 이상인 회원이 구매한 물품, 회원명, 회원수, 구매금액을 가격 높은순으로 조회 하시오.", "SELECT prod_name, mem_name, mem_number, price FROM buy B INNER JOIN member M ON B.mem_id = M.mem_id WHERE M.mem_number >= 6 ORDER BY price DESC;");
INSERT INTO solve VALUES("Q4) 가장 비싼 단가를 가진 물품을 구매한 회원의 회원명, 구매단가, 구매물품, 국번전화번호, 평균키, 데뷔 일자를 구하시오. 국번전화번호의 값은 중간에 '-' 으로 연결, 나온 결과값의 정렬은 데뷔 일자가 가장 빠른 순으로 구하시오.", "SELECT mem_name, price, prod_name, CONCAT(phone1, '-', phone2), height, debut_date FROM buy B INNER JOIN member M ON B.mem_id = M.mem_id ORDER BY debut_date ASC;");
INSERT INTO solve VALUES("Q5) 키가 165 이하이고 총 구매 금액이 500이 넘는 회원의 회원 아이디, 회원 키, 총구매 금액을 총 구매 수량이 많은 순으로 탑3 까지 조회", "SELECT B.mem_id, height, SUM(price * amount) FROM buy B INNER JOIN member M ON B.mem_id = M.mem_id WHERE height <= 165 GROUP BY B.mem_id, height HAVING SUM(price * amount) > 500;");
INSERT INTO solve VALUES("Q6) 서울 출생이고 구매하지 않는 회원의 회원 아이디, 데뷔일자를 데뷔 일자가 빠른 순으로 탑2 까지 조회", "SELECT M.mem_id, debut_date FROM member M LEFT OUTER JOIN buy B ON M.mem_id = B.mem_id WHERE addr = '서울' AND price IS NULL ORDER BY debut_date LIMIT 2;");
INSERT INTO solve VALUES("Q7) 아이즈원은 거제 출생이고, 폰은 없다. 평균키는 170이며 데뷔 날짜및 멤버수는 검색, ID는 IVE 이다. 아이즈 원은 청바지와 에어팟을 각 3개씩 샀다. insert 하세요.", "INSERT INTO member VALUES('IVE', '아이즈원', 12,'거제', NULL, NULL, 170, '2018.10.29');INSERT INTO buy VALUES(NULL, 'IVE', '에어팟', '디지털', 80, 3);INSERT INTO buy VALUES(NULL, 'IVE', '청바지', '패션', 50, 3);");
INSERT INTO solve VALUES("Q8) 마마무가 자신들의 평균키가 166이라고 정정해달라는 요청이 왔다. 이를 update 하시오.", "UPDATE member SET height = 166 WHERE mem_name = '마마무';");
INSERT INTO solve VALUES("Q9) 멤버 이름이 4글자인 멤버의 총 평균 키를 조회하시오:", "SELECT mem_name, AVG(height) FROM member WHERE mem_name LIKE '____' GROUP BY mem_name;");
INSERT INTO solve VALUES("Q10) 서적이 모두 환불 되었습니다. 서적을 구매한 회원 네임과 멤버의 전화번호, 환불할 총 구매 금액을 조회 하시오.", "SELECT mem_name, CONCAT(phone1, phone2), SUM(price * amount) FROM buy B INNER JOIN member M ON B.mem_id = M.mem_id WHERE group_name = '서적' GROUP BY mem_name, CONCAT(phone1, phone2);");


SELECT * FROM solve;