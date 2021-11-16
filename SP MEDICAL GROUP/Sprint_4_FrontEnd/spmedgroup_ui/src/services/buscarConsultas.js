import { useState, useEffect } from "react";
import axios from 'axios';
import setListaConsultas from '../Components/card_consulta'
import listaConsulta from '../Components/card_consulta'

import React from 'react';

export default async function buscarConsultas() {

    try {
        const response = await axios('http://localhost:5000/api/Consultas',
            {
                headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
            }
        );
        if (response.status === 200) {
            setListaConsultas(response.data);
        }
    } catch (erro) {
        return console.log(erro);
    }
    
};