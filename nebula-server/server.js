const WebSocket = require("ws");

const wss = new WebSocket.Server({ port: 5050 });

console.log("Launching server on port 5050!");

wss.on("connection", function connection(ws) {
  ws.on("message", function incoming(message) {
    console.log("received: %s", message);
  });

  ws.send("recieved data from server");
});
