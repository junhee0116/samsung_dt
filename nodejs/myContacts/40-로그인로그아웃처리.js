// 로그인, 로그아웃 처리하기
// 사용자 인증

// 1. 로그인 처리
// 세션(토큰발행) 쿠키/서버 저장하기
// 2. 로그아웃 처리
// 세션(토큰) 지우기


// 로그인 관련 파일
// ./routes/loginRoutes-6.js
// ./controllers/loginController-6.js
// ./middleware/checkLogin.js
// ./views/home-3.ejs 

// home-3.ejs(로그인 화면), register.ejs(회원가입) -> _home_header.ejs
// 그 외 모든 ejs에서는 -> _header-2.ejs 사용

// 관련 파일
// ./routes/contactRoutes-6.js
// ./controllers/contactController-16.js
// ./views/include/_header-2.ejs
// ./views/index-5.ejs
// ./views/update-3.ejs
// ./views/add-3.ejs


const express = require("express");
const dbConnect = require("./config/dbConnect");
const methodOverride = require("method-override");

const app = express();

// 뷰엔진 설정하기
app.set("view engine", "ejs");
app.set("views", "./views");

const port = 3000;

// public 폴더
app.use(express.static("./public"));
// method-override 미들웨어 등록
app.use(methodOverride("_method"));

dbConnect();

app.use(express.json());
app.use(express.urlencoded({extended: true}));

app.use("/", require("./routes/loginRoutes"));
app.use("/contacts", require("./routes/contactRoutes")); 

app.listen(port, () => {
    console.log("3000번 포트에서 서버 실행중...")
});
