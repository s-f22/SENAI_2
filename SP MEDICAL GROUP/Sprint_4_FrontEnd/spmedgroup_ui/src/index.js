import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from './services/auth';


import './assets/css/style_geral.css';



import HomeLogin from '../src/pages/login/App';
import Administrador from '../src/pages/administrador/administrador'
import Medico from './pages/medico/medico';
import Paciente from './pages/paciente/paciente';


import reportWebVitals from './reportWebVitals';



//---------------------------------------------------------------------------------------------------------------------------------


const PermissaoAdm = ( { component: Component } ) => (
  <Route 
    render = { (props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login"/>
      )
    }
  />
);

const PermissaoMedico = ( { component: Component } ) => (
  <Route 
    render = { (props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login"/>
      )
    }
  />
);

const PermissaoPaciente = ( { component: Component } ) => (
  <Route 
    render = { (props) =>
      usuarioAutenticado() && parseJwt().role === '3' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login"/>
      )
    }
  />
);





const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={HomeLogin} />
        <Route path="/login" component={HomeLogin} />
        <PermissaoAdm path="/administrador" component={Administrador} />
        <PermissaoMedico path="/medico" component={Medico} />
        <PermissaoPaciente path="/paciente" component={Paciente} />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
