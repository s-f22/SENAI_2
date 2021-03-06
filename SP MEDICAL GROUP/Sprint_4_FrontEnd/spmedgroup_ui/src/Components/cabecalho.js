import React from 'react'
import logo from '../assets/img/logo_spmedgroup_v2.png'
import { Link, useHistory} from 'react-router-dom';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';

export default function Cabecalho() {

    let history = useHistory();

    function LogOut(){
        
        localStorage.removeItem('usuario-login');
        history.push('/login');
        console.log("Logout efetuado com sucesso.")

    }

  
    

    return (
        <header className="header_cadastro_consultas">
            <div className="posix_header_cadastro_consultas grid">
                <img src={logo} alt="" className="spm_logo_cadastro_consultas" />
                <nav className="menu_principal_cadastro_consultas">
                    <Link to="../">Localizações</Link>
                    <a href="">Nossas Unidades</a>
                    <a href="">Especialidades</a>
                    <Link onClick={() => LogOut()}>Logout</Link>
                </nav>
            </div>
        </header>
    )
}