// sendFile() 함수를 통해 특정 html 파일로 응답해준다.
// html파일: assets/contacts.html 생성

const express = require("express");
const app = express();

const port = 3000;

app.get("/", (req, res) => {
    res.status(200);
    console.log(__dirname);

    res.sendFile(__dirname + "/assets/contacts.html");
    // res.json({message: "Hello Node!"});
});

app.listen(port, () => {
    console.log(`${port}번 포트에서 서버 실행 중...`);
});