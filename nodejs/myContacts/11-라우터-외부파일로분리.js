// 관련 파일
// ./routes/contactRoutes-1.js
// 실행 파일\
// ./routes/contractRoutes.js

express = require('express');
const app= express();
const router = express.Router();

const port = 3000;

app.get("/", (res, req) => {
    res.status(200).send("Hello Node!");    
});


// 간략화된 경로(라우트 경로), 라우터 모듈 임포트
app.use("/contacts", require("./routes/contactRoutes"));

app.listen(port, () => {
    console.log("Server is running on port 3000");
});