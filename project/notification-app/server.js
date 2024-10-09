const express = require('express');
const http = require('http');
const socketIo = require('socket.io');
const mysql = require('mysql2');
const path = require('path');

const app = express();
const server = http.createServer(app);
const io = socketIo(server);

// MySQL 연결 설정
const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '0000',
  database: 'news_database'
});

db.connect();

// 정적 파일: 웹 서버가 HTML, CSS, JavaScript 파일과 이미지와 같은 정적 자원을 클라이언트(브라우저)에게 제공하는 기능제공
app.use(express.static(path.join(__dirname, 'public')));

let lastId = 0;

// 새로운 데이터가 추가되었는지 확인하는 쿼리 실행
setInterval(() => {
  db.query('SELECT * FROM notifications WHERE id > ? ORDER BY id DESC', [lastId], (err, results) => {
    if (err) throw err;
    if (results.length > 0) {
      lastId = results[0].id; // 가장 최신 데이터의 ID 업데이트
      io.emit('newRecord', results); // 클라이언트에 데이터 전송
    }
  });
}, 5000); // 5초마다 확인

// Socket.IO 연결 설정
io.on('connection', (socket) => {
  console.log('A user connected');
  socket.on('disconnect', () => {
    console.log('User disconnected');
  });
});

// 서버 실행
server.listen(3000, () => {
  console.log('Server running on port 3000');
});