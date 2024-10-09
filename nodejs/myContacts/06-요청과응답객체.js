// 익스프레스의 요청 객체와 응답 객체

// 요청객체의 주요 속성
// req.body: 서버로 POST 요청할 때 넘겨준 정보를 담고 있다. JSON,File(Bin)
// req.cookies: 클라이언트에 저장된 쿠키 정보를 HTTP에 담아서 보낼 때 쿠키정보를 담고 있음.
//              클라이언트에 저장된 임시값(장바구니-비회원) 저장하는 용도
// req.headers: 서버로 요청을 보낼 때 같인 보낸 헤더 정보를 담고 있음.
// req.params: URL 뒤에 파라미터가 포함되어 있는 경우에 파라미터 정보를 담고 있음.
// req.query: 요청 URL의 포함된 질의 매개변수(query)를 담고 있음.

// 응답객체의 주요 속성
// res.download: 파일을 다운로드할 때 사용함.
// res.end: 응답 프로세스를 종료한다.
// res.json: JSON 응답을 전송한다. Content-Type 헤더를 자동으로 생성함.
// res.jsonp: JSONP 지원을 통해 JSON 응답을 한다.
//        JSONP란 CORS(크로스오리진) 문제를 피하기 위해 별도의 방식으로 JSON을 가져오는 방식
// res.redirect: 요청 경로를 재지정하여 강제 이동한다.
//        응답 헤더의 setLocation 속성에 이동할 경로를 기술하면, 클라가 이 경로로 이동한다.
// res.render: 뷰 템플릿을 화면에 랜더링(그린다)한다.
// res.send: 어떤 유형이든 res.send() 괄호 안에 내용(변수, 객체)을 전달한다.
// res.sendFile: 지정한 경로의 파일을 읽어서 내용을 전달한다.
// res.sendStatus: 상태 메시지와 함께 HTTP 상태 코드를 전송한다.
// res.status: 응답의 상태 코드를 설정한다.


// send() 함수와 json()하수를 사용해보자.
const express = require("express");
const app = express();

const port = 3000;

app.get("/", (req, res) => {
    res.status(200);
    res.send("Hello Node!");
    res.json({message: "Hello Node!"});
});

app.listen(port, () => {
    console.log(`${port}번 포트에서 서버 실행 중...`);
});




















/*

// 라우트 파라미터로 동적 URL 처리하기

// app.js
const express = require('express');
const app = express();

const port = 3000;

// 인덱스(시작) 페이지 요청
app.get('/', (req, res) => {
    res.status(200);    // 상태코드를 200으로 설정
    res.send('Hello Express~');
});

// 모든 연락처 가져오기
app.get("/contacts", (req, res) => {
    res.status(200).send("Get Contacts");
});

// 새 연락처 추가하기
app.post("/contacts", (req, res) => {
    res.status(201).send("Create Contacts");
});

// 연락처 상세보기
// get url: localhost:3000/contacts/10
app.get("/contacts/:id", (req, res) => {
    res.status(200).send(`View Contacts for ID: ${req.params.id}`);
});

// 연락처 수정하기
// put url: localhost:3000/contacts/10
app.put("/contacts/:id", (req, res) => {
    res.status(200).send(`Update Contacts for ID: ${req.params.id}`);
});

// 연락처 삭제하기
app.delete("/contacts/:id", (req, res) => {
    res.status(200).send(`Delete Contacts for ID: ${req.params.id}`);
});

app.listen(port, () => {
    console.log(`${port}번 포트에서 서버 실행 중...`);
});


// HTTP Method: 통신방식
// GET: 데이터를 읽어올 때
// POST: 데이터를 쓸 때
// PUT: 데이터를 수정할 때
// DELETE: 데이터를 삭제할 때

// SQL의 CRUD
// Create: POST
// Read: GET
// Update: PUT
// Delete: DELETE

*/