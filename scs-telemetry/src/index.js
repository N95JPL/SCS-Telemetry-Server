import { createRoot } from "react-dom/client";
import { HashRouter, Routes, Route } from "react-router-dom";
import Layout from "./Modules/Layout";
import Home from "./Modules/Home";
import About from "./Modules/About";
import Settings from "./Modules/Settings";
import Closing from "./Modules/Closing";
import NoPage from "./Modules/NoPage";

export default function App() {
  return (
    <HashRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/settings" element={<Settings />} />
          <Route path="/closing" element={<Closing />} />
          <Route path="/*" element={<NoPage />} />
        </Route>
      </Routes>
    </HashRouter>
  );
}
const root = createRoot(document.getElementById("root"));
root.render(<App />);
