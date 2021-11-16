import { useState, useEffect } from "react";
import axios from 'axios';
import React from 'react';

import Cabecalho from '../../Components/cabecalho';
import Rodape from '../../Components/rodape';
import Card_Consulta from '../../Components/card_consulta'; // TENTAR POSSIBILIDADE DE COMPONENTIZAR. É POSSIVEL EXPORTAR /ISOLAR A FUNÇÃO BUSCARCONSULTA?


export default function Medico() {

    const [listaConsultas, setListaConsultas] = useState([]);

    const [isLoading, setIsLoading] = useState(false);
    const [dataConsulta, setDataConsulta] = useState(new Date());
    const [idPac, setIdPac] = useState(0);
    const [idMed, setIdMed] = useState(0);
    const [listaPacientes, setListaPacientes] = useState([])
    const [listaMedicos, setListaMedicos] = useState([])





    function buscarConsultas() {
        axios
            ('http://localhost:5000/api/Consultas',
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





    function cadastrarConsulta(novaConsulta) {

        setIsLoading(true);

        novaConsulta.preventDefault();


        let consulta = {
            idPaciente: idPac,
            dataHorario: dataConsulta,
            idMedico: idMed
        };


        axios.post('http://localhost:5000/api/Consultas', consulta,
            {
                headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
            }
        )
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log("Consulta cadastrada com sucesso!");
                    setDataConsulta(new Date());
                    setIdPac(0);
                    setIdMed(0);
                    buscarConsultas();
                    setIsLoading(false);
                }
            })
            .catch(
                erro => console.log(erro, "DEU RUIM"), setDataConsulta(),
                setIdPac(0), setIdMed(0), setIsLoading(false)
            );
    }




    function buscarPacientes() {
        axios
            ('http://localhost:5000/api/Pacientes',
                {
                    headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
                }
            )
            .then(response => {
                if (response.status === 200) {
                    setListaPacientes(response.data)
                }
            })
            .catch(erro => console.log(erro));
    };

    function buscarMedicos() {
        axios
            ('http://localhost:5000/api/Medicos',
                {
                    headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
                }
            )
            .then(response => {
                if (response.status === 200) {
                    setListaMedicos(response.data)
                }
            })
            .catch(erro => console.log(erro));
    };



    useEffect(buscarConsultas, []);
    useEffect(buscarPacientes, []);
    useEffect(buscarMedicos, []);



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
                    <div class="editar_descricao">
                        <h2>Resumo do Atendimento</h2>
                        <form action="" class="conteiner_form_editar_descricao">
                            <div class="form_inputs_editar_descricao">
                                <input type="text" placeholder="Nº da Consulta" />
                                <textarea name="" id="" cols="30" rows="10" placeholder="Insira abaixo a descrição do atendimento"></textarea>
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