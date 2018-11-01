const WebSocket = require("ws");

const ws = new WebSocket("ws:localhost:5050");

ws.on("open", function open() {
  ws.send("recieved data from client");
});

ws.on("message", function incoming(data) {
  console.log(data);
});
