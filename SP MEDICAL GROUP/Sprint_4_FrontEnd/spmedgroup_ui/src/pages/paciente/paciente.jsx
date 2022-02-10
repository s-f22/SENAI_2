import { useState, useEffect } from "react";
import axios from 'axios';
import React from 'react';

import Cabecalho from '../../Components/cabecalho';
import Rodape from '../../Components/rodape';
import Card_Consulta from '../../Components/card_consulta'; // TENTAR POSSIBILIDADE DE COMPONENTIZAR. É POSSIVEL EXPORTAR /ISOLAR A FUNÇÃO BUSCARCONSULTA?


export default function Paciente() {

    const [listaConsultas, setListaConsultas] = useState([]);

    const [isLoading, setIsLoading] = useState(false);



    function buscarConsultas() {
        console.log('buscou as consultaaas')
        axios
            ('https://62055d05161670001741ba30.mockapi.io/consulta',
               
            )
            .then(response => {
                
                    setListaConsultas(response.data)
                
            })
            .catch(erro => console.log(erro));
    };





    useEffect(buscarConsultas, []);





    return (
        <div className="body_pacientes">

            <Cabecalho />

            <div className="grid">
                <section className="conteudos_cadastro_consultas">
                    <div className="container_listar_consultas">
                        <h2>Lista de Consultas</h2>
                        <div className="listar_consultas_cadastro_consultas">
                            {
                                listaConsultas.map((consulta) => {
                                    return (
                                        <article className="infos_card_cadastro_consultas" key={consulta.idConsulta}>
                                            <h3> Consulta {consulta.idConsulta} </h3>
                                            <div className="campos_cadastro_consultas">
                                                <div className="linha_campos_cadastro_consultas">
                                                    <h4> Paciente: </h4>
                                                    <p> {consulta.idPacienteNavigation.nomeCompleto} </p>
                                                </div>
                                                <div className="linha_campos_cadastro_consultas">
                                                    <h4> Médico: </h4>
                                                    <p> {consulta.idMedicoNavigation[0].nomeCompleto} </p>
                                                </div>
                                                <div className="linha_campos_cadastro_consultas">
                                                    <h4> Data: </h4>
                                                    {/* <p> {consulta.dataHorario} </p> */}
                                                </div>
                                                <div className="linha_campos_cadastro_consultas">
                                                    <h4> Situação: </h4>
                                                    {/* <p> {consulta.idSituacaoNavigation.titulo} </p> */}
                                                </div>
                                                <div className="linha_campos_cadastro_consultas">
                                                    <h4> Resumo: </h4>
                                                    <p> {consulta.resumo} </p>
                                                </div>
                                            </div>
                                        </article>
                                    )
                                })
                            }
                        </div>


                    </div>
                </section>
            </div>

            <Rodape />

        </div>
    )

}