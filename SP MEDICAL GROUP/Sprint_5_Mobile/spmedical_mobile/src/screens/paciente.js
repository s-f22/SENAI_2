import React, { Component, useEffect, useState } from "react";
import { NavigationContainer } from "@react-navigation/native";
import {
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    useColorScheme,
    View,
    Image,
    ImageBackground,
    TouchableOpacity,
    FlatList,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';


import {
    Colors,
    DebugInstructions,
    Header,
    LearnMoreLinks,
    ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';



export default class Home extends Component {
    constructor(props) {
        super(props)
        this.state = {
            listaConsultas: [],
        };
    }

    Logout = async () => {
        await AsyncStorage.removeItem('userToken');
        this.props.navigation.navigate('Login');
    }


    buscarConsultas = async () => {
        const resposta = await api.get('/Usuarios/ListarMinhasConsultas');
        // console.warn(resposta);
        const dadosDaApi = resposta.data;
        this.setState({ listaConsultas: dadosDaApi });
    };

    componentDidMount() {
        this.buscarConsultas();
    }


    render() {
        return (
            <ImageBackground style={styles.fundoMedico} source={require('../../assets/img/pacient.jpeg')}>
                <FlatList
                    contentContainerStyle={styles.mainBodyContent}
                    data={this.state.listaConsultas}
                    keyExtractor={item => item.idConsulta}
                    renderItem={this.renderItem}
                />
            </ImageBackground>
        )
    }

    //EDITAR AQUI
    // renderItem = ({ item }) => (
    //     // <Text style={{ fontSize: 20, color: 'red' }}>{item.nomeEvento}</Text>

    //     <View style={styles.flatItemRow}>
    //         <View style={styles.flatItemContainer}>
    //             <Text style={styles.flatItemTitle}>{item.nomeEvento}</Text>
    //             <Text style={styles.flatItemInfo}>{item.descricao}</Text>

    //             <Text style={styles.flatItemInfo}>
    //                 {Intl.DateTimeFormat("pt-BR", {
    //                     year: 'numeric', month: 'short', day: 'numeric',
    //                     hour: 'numeric', minute: 'numeric', hour12: true
    //                 }).format(new Date(item.dataEvento))}
    //             </Text>
    //         </View>

    //         <View style={styles.flatItemImg}>
    //             <TouchableOpacity
    //                 onPress={() => this.inscrever(item.idEvento)}
    //                 style={styles.flatItemImgIcon}>
    //                 <Image source={require('../../assets/img/view.png')} />
    //             </TouchableOpacity>
    //         </View>
    //     </View>
    // );
}

const styles = StyleSheet.create({

    fundoMedico: {
        width: '100%',
        height: '100%',
    },

});

