const mongoose = require("mongoose");

const userSchema = new mongoose.Schema({
    username: {
        type: String,       // 자료유형은 문자열
        required: true,     // 필수항목
        unique: true,       // username은 중복 불가
    },
    password: {
        type: String,       // 자료유형은 문자열
        required: true,     // 필수 항목
    },
});

module.exports = mongoose.model("User", userSchema);