const express = require('express');
const http = require('http');
const WebSocket = require('ws');
const path = require('path');

const app = express();
const server = http.createServer(app);
const wss = new WebSocket.Server({ server });

// 정적 파일 서비스 (HTML 파일 제공)
app.use(express.static(path.join(__dirname, 'public')));

// 클라이언트가 WebSocket으로 연결될 때
wss.on('connection', (ws) => {
    console.log('클라이언트가 연결되었습니다.');

    let notificationCount = 0;

    // 새로운 알림이 발생했을 때 클라이언트로 알림 전송
    const sendNotification = () => {
        notificationCount++;
        ws.send(JSON.stringify({ newNotificationCount: notificationCount }));
    };

    // 예시: 10초마다 새로운 알림을 클라이언트로 보냄
    setInterval(sendNotification, 3000);
});

// 서버 실행
const PORT = 3000;
server.listen(PORT, () => {
    console.log(`서버가 http://localhost:${PORT} 에서 실행 중입니다.`);
});
