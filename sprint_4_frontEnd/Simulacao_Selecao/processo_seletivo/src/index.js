import React from 'react';
import ReactDOM from 'react-dom';

import './index.css';

import App from './Home/App';
import ConsultarRepos from './Repos_Usuario/ConsultarRepos';

import reportWebVitals from './reportWebVitals';

ReactDOM.render(
  <React.StrictMode>
    <ConsultarRepos />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
