import React, { useState, useEffect, useContext } from "react";
import { HashRouter, Link, Route, Routes } from "react-router-dom";
import Home from "./Home";
import About from "./About";
import Settings from "./Settings";
import logo from "../assets/logo.svg";
import "./Style.css";

const App = (props) => {
  const [state, setState] = useState({});
  return (
    <HashRouter>
      <div className="App">
        <Routes>
          <Route exact path="/" component={Home} />
          <Route exact path="/About" component={About} />
          <Route exact path="/Settings" component={Settings} />
        </Routes>
      </div>
    </HashRouter>
  );
};
export default App;
