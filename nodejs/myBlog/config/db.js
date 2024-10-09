const mongoose = require("mongoose");
const asynchandler = require("express-async-handler");
require("dotenv").config();     // .env 파일을 사용하기 위해

const connectDB = asynchandler(async () => {
    // .env 파일에 있는 MONGODB_URI 값을 사용해 접속
    const connect = await mongoose.connect(process.env.MONGODB_URI);
});

module.exports = connectDB;