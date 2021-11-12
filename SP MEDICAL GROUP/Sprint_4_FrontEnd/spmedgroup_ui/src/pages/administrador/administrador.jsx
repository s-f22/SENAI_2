import { useState, useEffect } from "react";
import axios from 'axios';

export default function Administrador() {

    return (
        <div className="body_cadastro_consultas">
            <header className="header_cadastro_consultas">
                <div className="posix_header_cadastro_consultas grid">
                    <img src="..//img/logo_spmedgroup_v2.png" alt="" className="spm_logo_cadastro_consultas" />
                    <nav className="menu_principal_cadastro_consultas">
                        <a href="">Convênios</a>
                        <a href="">Nossas Unidades</a>
                        <a href="">Especialidades</a>
                        <a href="">Logout</a>
                    </nav>
                </div>
            </header>

            <div className="grid">
                <section className="conteudos_cadastro_consultas">
                    <div className="listar_consultas_cadastro_consultas">
                        <h2>Lista de Consultas</h2>

                        <form action="" className="infos_card_cadastro_consultas">
                            <h3>Consulta X</h3>
                            <div className="campos_cadastro_consultas">
                                <div className="linha_campos_cadastro_consultas">
                                    <label for="">Paciente:</label>
                                    <input type="text" value="Fulano da Silva" />
                                </div>
                                <div className="linha_campos_cadastro_consultas">
                                    <label for="">Médico:</label>
                                    <input type="text" value="Dr. Ciclano Souza" />
                                </div>
                                <div className="linha_campos_cadastro_consultas">
                                    <label for="">Data:</label>
                                    <input type="datetime" value="01/01/2001" />
                                </div>
                                <div className="linha_campos_cadastro_consultas">
                                    <label for="">Situação:</label>
                                    <input type="text" value="Confirmada" />
                                </div>
                                <div className="linha_campos_cadastro_consultas">
                                    <label for="">Resumo:</label>
                                    <textarea name="" id="" cols="30" rows="3">Paciente orientado a retornar em 15 dias para nova avaliação com especialista.
                                    </textarea>
                                </div>
                            </div>
                        </form>


                    </div>
                    <div className="cadastrar_consultas_cadastro_consultas">
                        <h2>Cadastrar Consulta</h2>
                        <form action="" className="conteiner_form_cadastro_consultas">
                            <div className="form_inputs_cadastro_consultas">
                                <input type="text" placeholder="Nome do paciente" />
                                <input type="datetime-local" placeholder="Data da consulta" />
                                <input type="text" placeholder="Nome do médico" />
                            </div>
                            <button style="margin-top: 30px;">Cadastrar</button>
                        </form>
                    </div>

                </section>
            </div>

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
                        <img src="..//img/logo_spmedgroup_v2.png" alt="" style="height: 100%;" />
                    </div>
                    <hr style="color: white;" />
                    <div className="abaixo_linha_cadastro_consultas">
                        <p>SP Medical Group 2021. Saúde Online</p>
                        <div className="box_seguir_cadastro_consultas">
                            <p>Siga-nos: </p>
                            <img src="..//img/facebook.png" alt="" />
                            <img src="..//img/instagram.png" alt="" />
                            <img src="..//img/youtube.png" alt="" />
                        </div>
                    </div>
                </div>
            </footer>
        </div>

    )

}