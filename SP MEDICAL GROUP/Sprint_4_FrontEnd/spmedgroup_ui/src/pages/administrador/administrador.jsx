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
                    <div className="cadastrar_consultas_cadastro_consultas">
                        <h2>Cadastrar Consulta</h2>
                        <form onSubmit={cadastrarConsulta} className="conteiner_form_cadastro_consultas">
                            <div className="form_inputs_cadastro_consultas">

                                <input type="datetime-local" name="dataConsulta" value={dataConsulta} onChange={(campo) => setDataConsulta(campo.target.value)} />

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

                            </div>
                            <button type="submit">Cadastrar</button>
                        </form>
                    </div>

                </section>
            </div>

            <Rodape />

        </div>
    )

}