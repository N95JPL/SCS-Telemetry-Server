import React, { Component, useState, useContext, useEffect } from "react";
import { Outlet, Link } from "react-router-dom";
import GlobalState from "../context/GlobalState";
import "./Style.css";
//const { ipcRenderer } = window.require("electron");

function Layout() {
  var [Telemetry, setTelemetry] = useState(false);
  var [WS, setWS] = useState(false);
  var [Server, setServer] = useState(false);
  var [Page, setPage] = useState("Home");
  var [state, setState] = useContext(GlobalState);

  useEffect(() => {
    setState((state) => ({ ...state, address: "dsfsdfsdfsdf" }));
  }, []);
  console.log(state);
  window.ipcRenderer.on("update-server", (event, msg) => {
    var test = JSON.parse(msg);
    // setServer(test.Server.Active);
    // setWS(test.WebSocket.Active);
    // setTelemetry(test.Telemetry);
    setState((state) => ({
      ...state,
      Telemetry: test.Telemetry,
      Server: test.Server.Active,
      WS: test.WebSocket.Active,
    }));
  });

  return (
    <div className="App">
      <div className="App-header">
        <table id="StatusTable">
          <thead>
            <tr>
              <th>
                <div
                  id="TelemetryStatus"
                  className={`StatusIcon rounded-full ${
                    state.Telemetry ? "bg-green-600" : "bg-red-600"
                  }`}
                />
              </th>
              <th>
                <div
                  id="WebSocketStatus"
                  className={`StatusIcon rounded-full ${
                    state.WS ? "bg-green-600" : "bg-red-600"
                  }`}
                />
              </th>
              <th>
                <div
                  id="ServerStatus"
                  className={`StatusIcon rounded-full ${
                    state.Server ? "bg-green-600" : "bg-red-600"
                  }`}
                />
              </th>
            </tr>
            <tr>
              <th>
                <p>Telemetry</p>
              </th>
              <th>
                <p>WebSocket</p>
              </th>
              <th>
                <p>API Server</p>
              </th>
            </tr>
          </thead>
        </table>
      </div>
      <Link to="/closing">
        <button
          id="CloseButton"
          className="closeButton rounded bg-red-700 hover:bg-red-900 hover:text-white"
          onClick={() => {
            window.ipcRenderer.send("Close", true);
          }}
        >
          x
        </button>
      </Link>
      <div className="App-sidebar">
        <nav>
          <ul>
            <Link to="/">
              <li
                id="HomeNav"
                className="h-10 App-sidebar-nav bg-blue-600 hover:bg-blue-400 active:bg-blue-50"
                onClick={() => {
                  setPage("Home");
                }}
              >
                <div
                  className={`App-sidebar-active ${
                    Page == "Home" ? "bg-red-600" : ""
                  }`}
                />
                <button>Home</button>
              </li>
            </Link>
            <Link to="/about">
              <li
                id="AboutNav"
                className="App-sidebar-nav bg-blue-600 hover:bg-blue-400 active:bg-blue-50"
                onClick={() => {
                  setPage("About");
                }}
              >
                <div
                  className={`App-sidebar-active ${
                    Page == "About" ? "bg-red-600" : ""
                  }`}
                />
                <button>About</button>
              </li>
            </Link>
            <Link to="/settings">
              <li
                id="SettingsNav"
                className="App-sidebar-nav bg-blue-600 hover:bg-blue-400 active:bg-blue-50"
                onClick={() => {
                  setPage("Settings");
                }}
              >
                <div
                  className={`App-sidebar-active ${
                    Page == "Settings" ? "bg-red-600" : ""
                  }`}
                />
                <button>Settings</button>
              </li>
            </Link>
          </ul>
        </nav>
      </div>
      <Outlet />
    </div>
  );
}
export default Layout;
