import React, { useEffect, useState } from "react";
import logo from "../assets/logo.svg";
import "./Style.css";

function Home() {
  var [Telemetry, setTelemetry] = useState(false);
  var [TelemetryButton, setTelemetryButton] = useState("Start Telemetry");
  var [WS, setWS] = useState(false);
  var [WSButton, setWSButton] = useState("Start WebSocket");
  var [Server, setServer] = useState(false);
  var [ServerButton, setServerButton] = useState("Start API Server");

  useEffect(() => {
    window.ipcRenderer.on("update-server", (event, msg) => {
      var test = JSON.parse(msg);
      setServer(test.Server.Active);
      setWS(test.WebSocket.Active);
      setTelemetry(test.Telemetry);
    });
    window.ipcRenderer.on("ServerR", (event, msg) => {
      setServer(msg);
    });
    window.ipcRenderer.on("WebSocketR", (event, msg) => {
      setWS(msg);
    });
    window.ipcRenderer.on("TelemetryR", (event, msg) => {
      setTelemetry(msg);
    });
  }, []);
  useEffect(() => {
    if (WS) {
      setWSButton("Stop WebSocket");
    } else {
      setWSButton("Start WebSocket");
    }
  }, [WS]);
  useEffect(() => {
    if (Telemetry) {
      setTelemetryButton("Stop Telemetry");
    } else {
      setTelemetryButton("Start Telemetry");
    }
  }, [Telemetry]);
  useEffect(() => {
    if (Server) {
      setServerButton("Stop API Server");
    } else {
      setServerButton("Start API Server");
    }
  }, [Server]);
  return (
    <div className="App-outlet">
      <header>
        <table id="ControlTable">
          <thead>
            <tr>
              <th>
                <button
                  className={`ControlButton rounded ${
                    Telemetry ? "bg-green-700" : "bg-red-700"
                  }`}
                  id="TelemetryButton"
                  onClick={() => {
                    if (!Telemetry) {
                      window.ipcRenderer.send("Telemetry", true);
                    } else {
                      window.ipcRenderer.send("Telemetry", false);
                    }
                  }}
                >
                  {TelemetryButton}
                </button>
              </th>
              <th>
                <button
                  className={`ControlButton rounded ${
                    WS ? "bg-green-700" : "bg-red-700"
                  }`}
                  id="WSButton"
                  onClick={() => {
                    if (!WS) {
                      window.ipcRenderer.send("WebSocket", true);
                    } else {
                      window.ipcRenderer.send("WebSocket", false);
                    }
                  }}
                >
                  {WSButton}
                </button>
              </th>
              <th>
                <button
                  className={`ControlButton rounded ${
                    Server ? "bg-green-700" : "bg-red-700"
                  }`}
                  id="ServerButton"
                  onClick={() => {
                    if (!Server) {
                      window.ipcRenderer.send("Server", true);
                    } else {
                      window.ipcRenderer.send("Server", false);
                    }
                  }}
                >
                  {ServerButton}
                </button>
              </th>
            </tr>
          </thead>
        </table>
        <img src={logo} className="App-logo" alt="logo" />
      </header>
    </div>
  );
}

export default Home;
