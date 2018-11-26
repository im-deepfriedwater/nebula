const WebSocket = require("ws");

const wss = new WebSocket.Server({ port: 5050 });

const { generateProgram, runProgram } = require("./utils/nebula");

console.log("Launching server on port 5050!");

wss.on("connection", function connection(ws) {
  ws.on("message", function incoming(message) {
    console.log("received: %s", message);
    const obj = JSON.parse(message);
    console.log();
    const program = generateProgram(obj.constructs, obj.links);
    console.log(program);
    console.log();
    ws.send("Program result: " + runProgram(program));
  });

  ws.send("recieved data from server");
});
