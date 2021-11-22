import React from 'react'
import logo from '../assets/img/logo_spmedgroup_v2.png'
import { Link, useHistory } from 'react-router-dom';

export default function Cabecalho() {

    let history = useHistory();

    function LogOut(){
        
        localStorage.clear();
        history.push('/login');
        console.log("Logout efetuado com sucesso.")

    }
    

    return (
        <header className="header_cadastro_consultas">
            <div className="posix_header_cadastro_consultas grid">
                <img src={logo} alt="" className="spm_logo_cadastro_consultas" />
                <nav className="menu_principal_cadastro_consultas">
                    <a href="">Convênios</a>
                    <a href="">Nossas Unidades</a>
                    <a href="">Especialidades</a>
                    <Link onClick={() => LogOut()}>Logout</Link>
                </nav>
            </div>
        </header>
    )
}