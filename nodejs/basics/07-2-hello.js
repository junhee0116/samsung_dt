// 터미널에 사용자 이름을 출력해주는 함수 - hello.js
// exports.hello도 가능
const hello = (name) => {
    console.log(`${name}님, 안녕하세요?`);
};

module.exports = hello;         // hello 함수 내보내기

