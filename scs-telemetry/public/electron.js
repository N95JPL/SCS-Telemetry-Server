var { Truck } = require("./Vars/Truck");
var { Trailer } = require("./Vars/Trailer");
var { Navigation } = require("./Vars/Navigation");
var { Game } = require("./Vars/Game");
var { Event } = require("./Vars/Event");
var { Job } = require("./Vars/Job");
var { Server } = require("./Vars/Server");
var Combined = [{ Error: "Telemetry empty! Check Server!", Code: 401 }];
var timers = [];
const electron = require("electron");
const app = electron.app;
const ipcMain = electron.ipcMain;
const BrowserWindow = electron.BrowserWindow;

const path = require("path");
const url = require("url");
const isDev = require("electron-is-dev");
const fs = require("fs");
const net = require("net");
var express = require("express");
var exp = express();
var WebSocketServer = require("ws");
var canIds = fs.readFileSync(__dirname + "/preload.js");
console.log(canIds);
var buffer = "";

var client = new net.Socket();
var clientServer;
//wscat -c localhost:3001

var wsTimer;
var wsAutoUpdate = true;
var wsTest;
var wsVar = [];
var wss;

let mainWindow;
let splashWindow;

function createWindow() {
  splashWindow = new BrowserWindow({
    show: true,
    frame: false,
    movable: false,
    width: 800,
    maxWidth: 800,
    minWidth: 800,
    height: 600,
    center: true,
    maxHeight: 600,
    minHeight: 600,
  });
  splashWindow.loadURL(path.join(__dirname, "splashScreen.html"));
  splashWindow.center();
  mainWindow = new BrowserWindow({
    show: false,
    frame: false,
    movable: true,
    width: 800,
    maxWidth: 800,
    minWidth: 800,
    height: 600,
    center: true,
    maxHeight: 600,
    minHeight: 600,
    webPreferences: {
      nativeWindowOpen: true,
      nodeIntegration: true,
      enableRemoteModule: true,
      contextIsolation: false,
      devTools: true,
      preload: path.join(__dirname, "preload.js"),
    },
  });
  mainWindow.loadURL(
    isDev
      ? "http://localhost:3000"
      : `file://${path.join(__dirname, "../build/index.html")}`
  );

  mainWindow.once("ready-to-show", () => {
    setTimeout(() => {
      mainWindow.show();
      splashWindow.destroy();
      mainWindow.openDevTools();
    }, 2000);
  });
  mainWindow.on("closed", () => (mainWindow = null));
}

app.on("ready", () => {
  createWindow();
  const updateTruck = setInterval(() => {
    mainWindow.webContents.send("update-truck", JSON.stringify(Truck));
  }, 1000);
  timers.push(updateTruck);
  const updateServer = setInterval(() => {
    mainWindow.webContents.send("update-server", JSON.stringify(Server));
  }, 100);
  timers.push(updateServer);
  ipcMain.on("Telemetry", (event, arg) => {
    console.log(event + " : " + arg);
    if (arg) {
      startTelemetry();
    } else {
      stopTelemetry();
    }
    return Server.Telemetry;
  });
  ipcMain.on("WebSocket", (event, arg) => {
    console.log(event + " : " + arg);
    if (arg) {
      startWS();
    } else {
      stopWS();
    }
    return Server.WebSocket.Active;
  });
  ipcMain.on("Server", (event, arg) => {
    console.log(event + " : " + arg);
    if (arg) {
      startServer();
    } else {
      stopServer();
    }
    return Server.Server.Active;
  });
  ipcMain.on("Close", (event, arg) => {
    console.log(event + " : " + arg);
    closeServer();
    return;
  });
  exp.get("/:id?/:step?/:step2?/:step3?/:step4?", (req, res) => {
    console.log("Request");
    if (Server.Telemetry) {
      if (req.params.id == undefined) {
        res.json(Combined);
      } else {
        let id = eval(req.params.id);
        let lastParam = req.params.id;
        if (req.params.step != undefined) {
          id = id[req.params.step];
          lastParam = req.params.step;
        }
        if (req.params.step2 != undefined) {
          id = id[req.params.step2];
          lastParam = req.params.step2;
        }
        if (req.params.step3 != undefined) {
          id = id[req.params.step3];
          lastParam = req.params.step3;
        }
        if (req.params.step4 != undefined) {
          id = id[req.params.step4];
          lastParam = req.params.step4;
        }
        if (id != undefined) {
          res.json(id);
        } else {
          res.json([{ Error: lastParam + " not found", Code: 404 }]);
        }
      }
    } else {
      res.json({ Error: "No Telemetry", Code: 402 });
    }
  });
  ipcMain.handle("closeApp", () => {
    app.quit();
  });
});

app.on("window-all-closed", () => {
  if (process.platform !== "darwin") {
    app.quit();
  }
});

app.on("activate", () => {
  if (mainWindow === null) {
    createWindow();
  }
});

client.onerror = function (event) {
  console.log("Error");
  Server.Telemetry = false;
  mainWindow.webContents.send("TelemetryR", Server.Telemetry);
};
function closeServer() {
  timers.map(clearInterval);
  if (Server.WebSocket.Active) {
    stopWS();
  }
  if (Server.Server.Active) {
    stopServer();
  }
  if (Server.Telemetry) {
    stopTelemetry();
  }
  setTimeout(() => {
    mainWindow.close();
  }, 2000);
}
async function startTelemetry() {
  if (!Server.Telemetry) {
    try {
      client.connect(45454, "localhost", function () {
        Server.Telemetry = true;
        console.log("Connected");
      });
    } catch {
      Server.Telemetry = false;
    }
  } else {
  }
  mainWindow.webContents.send("TelemetryR", Server.Telemetry);
}
function stopTelemetry() {
  client.destroy();
  console.log("Client Ended");
  Server.Telemetry = false;
  mainWindow.webContents.send("TelemetryR", Server.Telemetry);
}

async function parseData(obj) {
  Object.keys(obj).forEach((key) => {
    if (typeof obj[key] === "object" && obj[key] !== null) {
      parseData(obj[key]);
    } else if (obj.hasOwnProperty("Type")) {
      if (obj.Type == "bool") {
        obj.Value = Boolean(
          parseInt(buffer.slice(obj.Offset, obj.OffsetEnd).toString("hex"))
        );
      } else if (obj.Type == "char") {
        obj.Value = buffer
          .slice(obj.Offset, obj.OffsetEnd)
          .toString()
          .replace(/[^a-z0-9 ,.?!]/gi, "");
      } else if (obj.Type == "float") {
        obj.Value = buffer.slice(obj.Offset, obj.OffsetEnd).readFloatLE(0);
        if (obj.hasOwnProperty("MPH")) {
          obj.MPH = Math.round(obj.Value * 2.23693629);
          obj.KPH = Math.round(obj.Value * 3.6);
        }
      } else if (obj.Type == "int") {
        obj.Value = parseInt(
          buffer.slice(obj.Offset, obj.OffsetEnd).toString("hex")
        );
      } else if (obj.Type == "long") {
        obj.Value = buffer
          .slice(obj.Offset, obj.OffsetEnd)
          .readBigUint64LE()
          .toString();
      } else if (obj.Type == "double") {
        obj.Value = buffer.slice(obj.Offset, obj.OffsetEnd).readDoubleLE();
      } else {
        console.log("ERROR: " + obj + ": " + obj.Type);
      }
    } else {
      console.log("Hmmm... there might be a problem...");
    }
  });
}

function combineAll() {
  Combined = [
    {
      Truck: Truck,
      Game: Game,
      Job: Job,
      Event: Event,
      Trailer: Trailer,
      Navigation: Navigation,
    },
  ];
}

client.on("data", function async(data) {
  buffer = data.slice(4, data.length);
  if (buffer.length > 20000) {
    parseData(Truck);
    parseData(Trailer);
    parseData(Game);
    parseData(Navigation);
    parseData(Event);
    parseData(Job);
    combineAll();
  } else {
    console.log("Buffer too small: " + buffer.length);
  }
});
client.on("close", function () {
  console.log("Closed!");
});
// For API Server
function startServer() {
  clientServer = exp.listen(Server.Server.Port, () => {
    console.log("Server running on port " + Server.Server.Port);
    Server.Server.Active = true;
  });
  mainWindow.webContents.send("ServerR", Server.Server.Active);
}
function stopServer() {
  if (Server.Server.Active) {
    try {
      clientServer.close();
      Server.Server.Active = false;
    } catch {}
  }
  mainWindow.webContents.send("ServerR", Server.Server.Active);
}
// For WS
function looper() {
  let firstLoop = true;
  let response = "Failed";
  for (let x in wsVar) {
    if (firstLoop == true) {
      response = eval(wsVar[x]);
      firstLoop = false;
    } else {
      response = response[wsVar[x]];
    }
    if (response == null) {
      response = [{ Error: wsVar[x] + " not found", Code: 404 }];
    }
  }
  return response;
}
function startWS() {
  if (!Server.WebSocket.Active) {
    try {
      wss = new WebSocketServer.Server({ port: Server.WebSocket.Port });
      Server.WebSocket.Active = true;
    } catch {}
    if (Server.WebSocket.Active) {
      WS();
    } else {
    }
  } else {
  }
  mainWindow.webContents.send("WebSocketR", Server.WebSocket.Active);
}
function WS() {
  console.log("Websocket started on port " + Server.WebSocket.Port);
  wss.on("connection", async (ws) => {
    console.log("new client connected");
    const active = setInterval(() => {
      if (!Server.WebSocket.Active) {
        ws.close(1000, "Closed via program!");
        clearInterval(active);
        clearInterval(wsTimer);
      }
    }, 100);
    ws.on("message", (data) => {
      console.log(`Client has sent us: ${data}`);
      wsTest = false;
      wsVar = data.toString().split("/");
      console.log(wsVar[0]);
      try {
        wsTest = eval(wsVar[0]);
      } catch {
        ws.send(JSON.stringify([{ Error: data + " not found", Code: 404 }]));
      }
      if (wsTest) {
        let response;
        if (wsAutoUpdate) {
          clearInterval(wsTimer);
          wsTimer = setInterval(() => {
            if (Server.Telemetry) {
              response = looper();
              ws.send(JSON.stringify(response));
            } else {
              ws.send(JSON.stringify([{ Error: "No Telemetry", Code: 402 }]));
            }
          }, 100);
        } else {
          if (Server.Telemetry) {
            response = looper();
            ws.send(JSON.stringify(response));
          } else {
            ws.send(JSON.stringify([{ Error: "No Telemetry", Code: 402 }]));
          }
        }
      }
    });
    ws.on("close", () => {
      console.log("Client Disconnected");
      clearInterval(wsTimer);
    });
    ws.onerror = function () {
      console.log("Some Error occurred");
    };
  });
}
function changeWS() {
  wss.close();
  Server.WebSocket.Active = false;
  startWS();
}
function stopWS() {
  if (Server.WebSocket.Active) {
    try {
      wss.close();
      Server.WebSocket.Active = false;
    } catch {}
  }
  mainWindow.webContents.send("WebSocketR", Server.WebSocket.Active);
}
