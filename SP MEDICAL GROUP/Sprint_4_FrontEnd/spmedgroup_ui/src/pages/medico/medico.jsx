import { useState, useEffect } from "react";
import axios from 'axios';
import React from 'react';

import Cabecalho from '../../Components/cabecalho';
import Rodape from '../../Components/rodape';
import Card_Consulta from '../../Components/card_consulta'; // TENTAR POSSIBILIDADE DE COMPONENTIZAR. É POSSIVEL EXPORTAR /ISOLAR A FUNÇÃO BUSCARCONSULTA?


export default function Medico() {

    const [listaConsultas, setListaConsultas] = useState([]);

    const [isLoading, setIsLoading] = useState(false);
    const [idDaConsulta, setIdDaConsulta] = useState('');
    const [descricaoAtualizada, setDescricaoAtualizada] = useState('');


    function buscarConsultas() {
        console.log('buscou as consultaaas')
        axios
            ('http://localhost:5000/api/Usuarios/ListarMinhasConsultas',
                {
                    headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
                }
            )
            .then(response => {
                if (response.status === 200) {
                    setListaConsultas(response.data)
                }
            })
            .catch(erro => console.log(erro));
    };





    function atualizarResumo(atualizacao) {

        setIsLoading(true);

        atualizacao.preventDefault();


        axios.patch('http://localhost:5000/api/Consultas/descricao/' + idDaConsulta, { resumo: descricaoAtualizada },
            {
                headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
            }
        )
            .then(resposta => {
                if (resposta.status === 204) {
                    console.log("Resumo atualizado com sucesso!");
                    buscarConsultas();
                    //setIdDaConsulta(null);
                    //setDescricaoAtualizada('');
                    //setIsLoading(false);

                }

            })
            .catch(
                erro => console.log(erro, "DEU RUIM"), setIdDaConsulta(''),
                setDescricaoAtualizada(''), setIsLoading(false)
            );
    }




    useEffect(buscarConsultas, []);





    return (
        <div className="body_medicos">

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
                                                    <p> {consulta.idMedicoNavigation.nomeCompleto} </p>
                                                </div>
                                                <div className="linha_campos_cadastro_consultas">
                                                    <h4> Data: </h4>
                                                    <p> {consulta.dataHorario} </p>
                                                </div>
                                                <div className="linha_campos_cadastro_consultas">
                                                    <h4> Situação: </h4>
                                                    <p> {consulta.idSituacaoNavigation.titulo} </p>
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
                    <div className="container_editar_descricao">
                        <h2>Resumo do Atendimento</h2>
                        <div className="editar_descricao">
                            <form onSubmit={atualizarResumo} className="conteiner_form_editar_descricao">
                                <div className="form_inputs_editar_descricao">
                                    <input type="text" placeholder="Nº da Consulta" name="idConsulta" value={idDaConsulta} onChange={(campo) => setIdDaConsulta(campo.target.value)} />
                                    <textarea name="resumoAtualizado" id="" cols="30" rows="10" placeholder="Insira abaixo a descrição do atendimento" value={descricaoAtualizada} onChange={(campo) => setDescricaoAtualizada(campo.target.value)}></textarea>
                                </div>
                                <button>Inserir</button>
                            </form>
                        </div>
                    </div>


                </section>
            </div>

            <Rodape />

        </div>
    )

}