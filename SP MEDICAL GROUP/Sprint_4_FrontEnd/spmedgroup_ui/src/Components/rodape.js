import React from 'react'

import logo from '../assets/img/logo_spmedgroup_v2.png'
import face from '../assets/img/facebook.png';
import insta from '../assets/img/instagram.png';
import youtube from '../assets/img/youtube.png';

export default function Rodape() {
    return (
        <footer className="footer_cadastro_consultas">
                <div className="container_footer_cadastro_consultas">
                    <div className="acima_linha_cadastro_consultas">
                        <table className="tabela_footer_cadastro_consultas">
                            <thead>
                                <tr>
                                    <th>Mobile App</th>
                                    <th>Comunidade</th>
                                    <th>A empresa</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Funcionalidade</td>
                                    <td>Nosso time</td>
                                    <td>Quem somos?</td>
                                </tr>
                                <tr>
                                    <td>Compartilhe</td>
                                    <td>Nosso portal</td>
                                    <td>Entre em contato</td>
                                </tr>
                                <tr>
                                    <td>Desenvolvedores</td>
                                    <td>Nossos eventos</td>
                                    <td>Parceiros</td>
                                </tr>
                            </tbody>
                        </table>
                        <img src={logo} alt="" />
                    </div>
                    <hr />
                    <div className="abaixo_linha_cadastro_consultas">
                        <p>SP Medical Group 2021. Saúde Online</p>
                        <div className="box_seguir_cadastro_consultas">
                            <p>Siga-nos: </p>
                            <img src={face} alt="" />
                            <img src={insta} alt="" />
                            <img src={youtube} alt="" />
                        </div>
                    </div>
                </div>
            </footer>
    )
}