import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Image,
  ImageBackground,
  TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

import jwt_decode from "jwt-decode";

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: 'helena.souza@spmedicalgroup.com.br',
      senha: '41254970',
    };
  }

  realizarLogin = async () => {

    const resposta = await api.post('/Logins', {
      email: this.state.email,
      senha: this.state.senha,
    });


    const token = resposta.data.token;
    await AsyncStorage.setItem('userToken', token);

    let userRole = jwt_decode(token).role;

    if (resposta.status == 200 && userRole === '2') {
      this.props.navigation.navigate('pgMedico');
    }
    else if (resposta.status == 200 && userRole === '3') {
      this.props.navigation.navigate('pgPaciente');
    }

  };

  render() {
    return (
      <ImageBackground
        source={require('../../assets/img/FundoLogin.png')}
        style={StyleSheet.absoluteFillObject}>
        <View style={styles.overlay} />
        <View style={styles.main}>
          <Image
            source={require('../../assets/img/logo_spmedgroup_v2.png')}
            style={styles.mainImgLogin}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="username"
            placeholderTextColor="#3582FF"
            keyboardType="email-address"
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={email => this.setState({ email })}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="password"
            placeholderTextColor="#3582FF"
            keyboardType="default" //para default nao obrigatorio.
            secureTextEntry={true} //proteje a senha.
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={senha => this.setState({ senha })}
          />

          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.realizarLogin}>
            <Text style={styles.btnLoginText}>Login</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    );
  }
}

const styles = StyleSheet.create({
  //antes da main
  overlay: {
    ...StyleSheet.absoluteFillObject, //todas as prop do styleShhet, e vamos aplica o abosluteFIL...
    backgroundColor: 'rgba(3,166,150,0.0)', //rgba pq vamos trabalhar com transparencia.
  },

  // conteúdo da main
  main: {
    // flex: 1,
    //backgroundColor: '#F1F1F1', retirar pra nao ter conflito.
    justifyContent: 'center',
    alignItems: 'center',
    width: '100%',
    height: '100%',
  },

  mainImgLogin: {
    //tintColor: '#FFF', //confirmar que sera branco
    height: 220, //altura
    width: 220, //largura img nao é quadrada
    marginRight: 120, //espacamento em todos os lados,menos pra cima.
    marginBottom: 100, // tira espacamento pra cima
  },

  inputLogin: {
    width: 300, //largura mesma do botao
    marginBottom: 10, //espacamento pra baixo
    backgroundColor: '#FFF',
    fontSize: 18,
    color: '#000',
    borderColor: '#05F29B', //linha separadora
    borderWidth: 2, //espessura.
    borderRadius: 30,
    paddingLeft: 20,
  },

  btnLoginText: {
    fontSize: 12, //aumentar um pouco
    fontFamily: 'Open Sans Light', //troca de fonte
    color: 'rgba(255,255,255,1)', //mesma cor identidade
    letterSpacing: 6, //espacamento entre as letras
    textTransform: 'uppercase', //estilo maiusculo
    fontWeight: 'bold',
  },
  btnLogin: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 38,
    width: 140,
    backgroundColor: '#3582FF',
    borderColor: '#FFFFFF',
    borderWidth: 1,
    borderRadius: 19,
    shadowOffset: { height: 1, width: 1 },
    marginTop: 10,
    marginBottom: 30,
  },
});
