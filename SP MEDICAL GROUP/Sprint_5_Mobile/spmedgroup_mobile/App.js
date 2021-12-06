import 'react-native-gesture-handler';

import React from 'react';
import { StatusBar } from 'react-native';

import {NavigationContainer} from '@react-navigation/native';
import {createStackNavigator} from '@react-navigation/stack';

const AuthStack = createStackNavigator();

import Login from './src/screens/login';
import Medico from './src/screens/medico';
import Paciente from './src/screens/paciente';

export default function Stack() {
  return (
    <NavigationContainer>
      <StatusBar
        hidden={true}
      />

      <AuthStack.Navigator
        initialRouteName="pgLogin"
        screenOptions={{
          headerShown: false,
        }}>
        <AuthStack.Screen name="pgLogin" component={Login} />
        <AuthStack.Screen name="pgMedico" component={Medico} />
        <AuthStack.Screen name="pgPaciente" component={Paciente} />
      </AuthStack.Navigator>
    </NavigationContainer>
  );
}