import { useState, useEffect } from "react";
import axios from 'axios';
import buscarConsultas from "../services/buscarConsultas";

import React from 'react';

export default function Card_Consulta() {

    const [listaConsultas, setListaConsultas] = useState([]);

    const [isLoading, setIsLoading] = useState(false);
    const [dataConsulta, setDataConsulta] = useState(new Date());
    const [idPac, setIdPac] = useState(0);
    const [idMed, setIdMed] = useState(0);


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

        axios.post('http://localhost:5000/api/Consultas',
            {
                idPaciente: idPac
            },
            {
                idMedico: idMed
            },
            {
                dataHorario: dataConsulta
            },
            {
                headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
            }
        )
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log("Consulta cadastrada com sucesso!");
                    setDataConsulta(null);
                    setIdPac(0);
                    setIdMed(0);
                    buscarConsultas();
                    setIsLoading(false);
                }
            })
            .catch(
                erro => console.log(erro), setDataConsulta(null),
                setIdPac(0), setIdMed(0), setIsLoading(false)
            );
    }




    useEffect(buscarConsultas, []);

    return (

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
    )
}