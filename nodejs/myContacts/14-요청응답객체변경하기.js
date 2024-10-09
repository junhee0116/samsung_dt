// 요청 객체나 응답 객체 변경하기

// 관련 파일
// ./routes/contactRoutes-2.js


const express = require("express");
const app = express();

const port = 3000;

// 미들웨어를 통해 req.requestTime 속성을 설정한다
const requestTime = (req, res, next) => {
    let today = new Date();
    let now = today.toLocaleTimeString();
    req.requestTime = now;
    next();     // 다음 미드웨어 실행
};

app.use(requestTime);

// 맨 처음에 루프경로에 처리를 한다 미들웨어가 앞에 있으면, 미들웨어 먼저 처리됨
app.get("/", (req, res) => {
    const responseText = `Hello Node! \n 요청시간: ${req.requestTime}`;
    req.set("Content-Type", "text/plain");
    res.send(responseText);
});

app.listen(port, () => {
    console.log("Server is running on port 3000");
});
