const hello = (name) => {
    console.log(`${name}님, 안녕하세요?`);
};

const bye = (name) => {
    console.log(`${name}님, 안녕히 가세요`);
};

// 복수 모듈 내보내기
exports.hello = hello;   
exports.bye = bye;   

// 단일 모듈 내보내기
// 키와 밸류가 같으면 하나로 생략
// module.exports = {hello: hello, bye: bye};
module.exports = {hello, bye};