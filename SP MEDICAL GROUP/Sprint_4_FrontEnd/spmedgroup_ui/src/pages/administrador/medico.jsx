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
    const [descricaoAtualizada, setDescricaoAtualizada] = useState( '' );
    





    function buscarConsultas() {
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


        axios.patch('http://localhost:5000/api/Consultas/' + {idDaConsulta}, {resumo: descricaoAtualizada},
            {
                headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
            }
        )
            .then(resposta => {
                if (resposta.status === 204) {
                    console.log("Resumo atualizado com sucesso!");
                    
                    setIdDaConsulta(null);
                    setDescricaoAtualizada('');
                    buscarConsultas();
                    setIsLoading(false);
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
                    <div className="listar_consultas_cadastro_consultas">
                        <h2>Lista de Consultas</h2>
                        {
                            listaConsultas.map((consulta) => {
                                return (
                                    <form action="" className="infos_card_cadastro_consultas" key={consulta.idConsulta}>
                                        <h3 >Consulta {consulta.idConsulta}</h3>
                                        <div className="campos_cadastro_consultas">
                                            <div className="linha_campos_cadastro_consultas">
                                                <label for="">Paciente:</label>
                                                <input type="text" value={consulta.idPacienteNavigation.nomeCompleto} />
                                            </div>
                                            <div className="linha_campos_cadastro_consultas">
                                                <label for="">Médico:</label>
                                                <input type="text" value={consulta.idMedicoNavigation.nomeCompleto} />
                                            </div>
                                            <div className="linha_campos_cadastro_consultas">
                                                <label for="">Data:</label>
                                                <input type="datetime" value={consulta.dataHorario} />
                                            </div>
                                            <div className="linha_campos_cadastro_consultas">
                                                <label for="">Situação:</label>
                                                <input type="text" value={consulta.idSituacaoNavigation.titulo} />
                                            </div>
                                            <div className="linha_campos_cadastro_consultas">
                                                <label for="">Resumo:</label>
                                                <textarea name="" id="" cols="30" rows="3">{consulta.resumo}</textarea>
                                            </div>
                                        </div>
                                    </form>
                                )
                            })
                        }
                    </div>
                    <div className="editar_descricao">
                        <h2>Resumo do Atendimento</h2>
                        <form onSubmit={ atualizarResumo } className="conteiner_form_editar_descricao">
                            <div className="form_inputs_editar_descricao">
                                <input type="text" placeholder="Nº da Consulta" name="idConsulta" value={ idDaConsulta } onChange={(campo) => setIdDaConsulta(campo.target.value)}/>
                                <textarea name="resumoAtualizado" id="" cols="30" rows="10" placeholder="Insira abaixo a descrição do atendimento" value={ descricaoAtualizada } onChange={(campo) => setDescricaoAtualizada(campo.target.value)}></textarea>
                            </div>
                            <button>Inserir</button>
                        </form>
                    </div>


                </section>
            </div>

            <Rodape />

        </div>
    )

}