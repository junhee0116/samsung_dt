// async/await 예약어
// 프라미스 객체 역시 함수체이닝을 사용해서 계속 연결될 경우
// 콜백 지옥처럼 복잡해 보일 수 있다.
// 이런 문제를 해결하기 위해 ES2017부터 지원

async function init(){
    const response = await fetch("http://jsonplaceholder.typicode.com/users");
    const users = await response.json();        // 가져온 결과(JSON)를 users 객체에 저장
    console.log(users);
}

init();