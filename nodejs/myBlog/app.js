// 블로그 앱 만들기

// npm 초기화(node.js 앱 초기화)
// npm init -y
// -y 옵션: 선택사항을 기본으로 처리

// 일반 사용자 모드
// 1. 자기 게시물 (Post) - 보기, 작성, 수정, 삭제 가능
// 2. 타인 게시물 - 보기만 가능

// 관리자 모드
// 1. 모든 게시물 - 보기, 작성, 수정, 삭제 가능

// nodemon: 소스 변경시 자동으로 app.js 재시작
// npm i nodemon
// express, dotenv 설치
// npm i express, dotenv

const express = require("express");
require("dotenv").config();
const expressLayouts = require("express-ejs-layouts");
const connectDB = require("./config/db");
const cookieParser = require("cookie-parser");
const methodOverride = require("method-override");

const app = express();
const port = process.env.PORT || 3000;  // .env에 PORT 없으면 3000번 사용

// DB 연결
connectDB();

// 레이아웃과 뷰 엔진 설정
app.use(expressLayouts);
app.set("view engine", "ejs");
app.set("views", "./views");

app.use(express.static("public"));

app.use(express.json());
app.use(express.urlencoded({extended: true}));

app.use(methodOverride("_method"));
app.use(cookieParser());

app.use("/", require("./routes/main"));
app.use("/", require("./routes/admin"));

app.listen(port, () => {
    console.log(`${port}에서 서버 실행 중...`);
});