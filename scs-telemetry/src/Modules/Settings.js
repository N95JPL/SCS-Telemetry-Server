import logo from '../assets/logo.svg';
import './Style.css';

function Settings() {
  return (
    <div className="App-outlet">
      <header className="Settings-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/Settings.js</code> and save to reload.
        </p>
        <a
          className="Settings-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default Settings;
