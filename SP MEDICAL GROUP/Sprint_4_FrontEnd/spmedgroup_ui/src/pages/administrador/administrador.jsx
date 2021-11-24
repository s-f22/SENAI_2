import { useState, useEffect } from "react";
import axios from 'axios';
import React from 'react';

import Cabecalho from '../../Components/cabecalho';
import Rodape from '../../Components/rodape';
import Card_Consulta from '../../Components/card_consulta'; // TENTAR POSSIBILIDADE DE COMPONENTIZAR. É POSSIVEL EXPORTAR /ISOLAR A FUNÇÃO BUSCARCONSULTA?


export default function Administrador() {

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
        <div className="body_cadastro_consultas">

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
                                            <h3 >Consulta {consulta.idConsulta}</h3>
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
                    <div className="container_cadastrar_consultas">
                        <h2>Cadastrar Consulta</h2>
                        <div className="cadastrar_consultas_cadastro_consultas">
                            <form onSubmit={cadastrarConsulta} className="conteiner_form_cadastro_consultas">
                                <div className="form_inputs_cadastro_consultas">

                                    <select
                                        name="paciente"
                                        value={idPac}
                                        onChange={(campo) => setIdPac(campo.target.value)}
                                    >
                                        <option value="0">Selecione o paciente:</option>
                                        {
                                            listaPacientes.map((paciente) => {
                                                return (
                                                    <option
                                                        key={paciente.idPaciente}
                                                        value={paciente.idPaciente}
                                                    >
                                                        {paciente.nomeCompleto}
                                                    </option>
                                                );
                                            })
                                        }
                                    </select>

                                    <select
                                        name="medico"
                                        value={idMed}
                                        onChange={(campo) => setIdMed(campo.target.value)}
                                    >
                                        <option value="0">Selecione o medico:</option>
                                        {
                                            listaMedicos.map((medico) => {
                                                return (
                                                    <option
                                                        key={medico.idMedico}
                                                        value={medico.idMedico}
                                                    >
                                                        {medico.nomeCompleto}
                                                    </option>
                                                );
                                            })
                                        }
                                    </select>

                                    <input type="datetime-local" name="dataConsulta" value={dataConsulta} onChange={(campo) => setDataConsulta(campo.target.value)} />

                                </div>
                                <button type="submit">Cadastrar</button>
                            </form>
                        </div>
                    </div>

                </section>
            </div>

            <Rodape />

        </div>
    )

}