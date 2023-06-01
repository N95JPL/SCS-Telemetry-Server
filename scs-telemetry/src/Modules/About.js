import logo from '../assets/logo.svg';
import './Style.css';

function About() {
  return (
    <div className="App-outlet">
      <header className="About-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/About.js</code> and save to reload.
        </p>
        <a
          className="About-link"
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

export default About;
