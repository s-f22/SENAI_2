import React, { useState, useEffect } from "react";
import axios from "axios";
import { parseJwt, usuarioAutenticado } from "../../services/auth";

import "../../assets/css/style_geral.css"


function App() {

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [msgErro, setMsgErro] = useState('');
    const [isLoading, setIsLoading] = useState(false);


    function efetuaLogin(evento) {
        console.log('Agora vamos fazer a chamada para a API como login.')

        evento.preventDefault();

        setMsgErro(''); 
        setIsLoading(true);

        axios.post('http://localhost:5000/api/Logins', { Email: email }, { Senha: senha })

            .then((resposta) => {

                if (resposta.status === 200) {
                    localStorage.setItem('usuario-login', resposta.data.token);
                    setIsLoading(false);
                    let base64 = localStorage.getItem('usuario-login').split('.')[1];
                    console.log(base64);
                    
                    if (parseJwt().role === '1') {
                        // history.push('/administrador');
                        this.App.history.push('/administrador');
                        console.log(`estou logado: ` + usuarioAutenticado());
                    } else if (parseJwt().role === '2') {
                        this.App.history.push('/medico');
                        console.log(`estou logado: ` + usuarioAutenticado());
                    } else {
                        this.App.history.push('/paciente');
                        console.log(`estou logado: ` + usuarioAutenticado());
                    }
                }

            })

            .catch(() => {
                setMsgErro({
                    msgErro: 'Email e/ou senha invalidos',
                    isLoading: false
                })
            }

            );

    };

    // atualizaCampo = (campo) => {
        
    //     this.setState({ [campo.target.name]: campo.target.value });
    //   };


    return (
        <div className="body_login">
            <div className="grid posix_login">
                <div className="bem_vindo_login">
                    <div className="img_medicos_login"></div>
                    <div className="msg_login">
                        <h1>SP Medical Group</h1>
                        <p>Fique tranquilo, nossa família de especialistas em saúde vai cuidar da
                            sua!
                        </p>
                    </div>
                </div>
                <div className="box_login">
                    <form action="" className="dados_login" onSubmit={ efetuaLogin }>
                        <h1>Entre e seja bem-vindo!</h1>
                        <div className="inputs_login">
                            <input type="email" value={email} onChange={ (campo) => setEmail( campo.target.value ) } placeholder="E-mail" />
                            <input type="password" value={senha} onChange={ (campo) => setSenha( campo.target.value ) } placeholder="Senha" />
                            <button type="submit">Entrar</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default App;
