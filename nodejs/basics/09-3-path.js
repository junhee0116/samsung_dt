// path 모듈 사용하기
const path = require('path');

// path 모듈: Window/Mac(Linux)
// 파일경로 윈도우 C:\users\me
//          리눅스 \users\me
// OS 특성을 고려하여 파일경로에 대한 기능을 제공

// 경로 연결하기
const fullPath = path.join('some', 'work', 'test.txt');
console.log(fullPath);

// 절대 경로: C:\users\me\test.txt    \users\me\test.txt
// 상대경로: .\test.txt  ./test.txt
// .: 현재 경로(디렉토리, 폴더

// 절대 경로
console.log(`파일 정대 경로 : ${__filename}`);

// 폴더이름만 가져오기
const dir = path.dirname(__filename);
console.log(dir);

// 파일 이름만 가져오기
const filename = path.basename(__filename);
console.log(pureFilename);

// 확장자만 가져오기
const ext = path.extname(__filename, ext);
console.log(ext);

pureFilename2 = path.basename(__filename, ext);
console.log([pureFilename])

// 경로분해하기
const parsedPath = path.parse(__filename); 
console.log(parsedPath);
console.log(parsedPath.name);