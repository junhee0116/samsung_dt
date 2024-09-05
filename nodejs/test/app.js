const mongoose = require('mongoose');
const express = require('express');
const http = require('http');
const { Server } = require('socket.io');

const app = express();
const server = http.createServer(app);
const io = new Server(server);

const port = 3000;

// MongoDB 연결 설정
mongoose.connect('mongodb://localhost:27017/mydatabase', {
  useNewUrlParser: true,
  useUnifiedTopology: true
}).then(() => {
  console.log('MongoDB에 성공적으로 연결되었습니다.');
}).catch(err => {
  console.error('MongoDB 연결 중 오류 발생:', err);
});

// 사용자 스키마 정의
const UserSchema = new mongoose.Schema({
  name: String,
  email: String,
  age: Number,
});

// 모델 생성
const User = mongoose.model('User', UserSchema);

// 새로운 사용자 추가 및 실시간 알림
app.post('/add-user', async (req, res) => {
  const newUser = new User({
    name: 'John Doe',
    email: 'johndoe@example.com',
    age: 30,
  });

  try {
    const savedUser = await newUser.save();
    io.emit('userAdded', savedUser); // 클라이언트에게 실시간으로 사용자 추가 이벤트 전송
    res.status(201).send(savedUser);
  } catch (err) {
    res.status(500).send(err);
  }
});

// 클라이언트에서 접속 이벤트 처리
io.on('connection', (socket) => {
  console.log('클라이언트가 연결되었습니다.');
  
  socket.on('disconnect', () => {
    console.log('클라이언트가 연결을 끊었습니다.');
  });
});

// 간단한 라우트 설정
app.get('/', (req, res) => {
  res.send('Hello, MongoDB with Node.js and Socket.io!');
});

server.listen(port, () => {
  console.log(`서버가 포트 ${port}에서 실행 중입니다.`);
});