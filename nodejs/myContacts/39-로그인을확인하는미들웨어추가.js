// 로그인을 확인하는 미들웨어 추가하기
// 사용자 인증
// 예) /contacts에 접근하려면, 로그인 인증(token값)을 거쳐야한다.


// 로그인 관련 파일
// ./routes/loginRoutes-5.js
// ./controllers/loginController-5.js
// ./middleware/checkLogin.js

// 관련 파일
// ./routes/contactRoutes-6.js
// ./controllers/contactController-15.js

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
