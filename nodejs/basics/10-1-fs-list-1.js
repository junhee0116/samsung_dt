// fs 모듈 사용하기

const fs = require('fs');

// fs 모듈: File System 제어에 관한 기능 제공. 파일(폴더)목록, 파일 읽기/쓰기 가능

// 현재 디렉토리(경로, 폴더) 읽기
// 1. readdirSync(동기): 다 읽을때까지 Blocking(기다림)한다
// 1. readdirSync(비동기): 다 읽을때까지  Non-locking(기다리지 않음)

// 문자열배열로 현재 경로의 파일과 폴더(디렉터리 목록)을 반환
let files = fs.readdirSync('./'); //, 11 으로 줘도 된다
console.log(files);

fs.readdir('./', () => 3);
console.log('나는 딴일을 할래');
console.log(files);

fs.readdir('./', (err, files) => {
    if(err){
        console.log(err);
        return;
    }
    console.log(files);
}) 
console.log('나는 다른일을 한다.')
