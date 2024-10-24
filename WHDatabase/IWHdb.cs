﻿using ClassLib;
using System;

namespace WHDatabase
{
    internal interface IWHdb
    {
        /// Este Interfaz se entrga a modo de requisitos mínimos a implementar y probar.
        /// Debéis de incluir funcionalidades adicionales

        /// <summary>
        /// Almacena el usuario.
        /// </summary>
        /// <param name="u">Objeto de la clase Usuario que se desea almacenar.</param>
        /// <returns>Verdadero o falso en función de si ha conseguido insertar/actualizar la información.</returns>
        bool GuardaUsuario(Usuario u);

        /// <summary>
        /// Lee los datos del usuario que se corresponde con la clave que se recibe como parámetro.
        /// </summary>
        /// <param name="email">Cadena con el EMail del usuario que se quiere consultar.</param>
        /// <returns>Retorna el objeto con la infromación del usuario buscado o NULL si no se localiza.</returns>
        Usuario LeeUsuario(String email);

        /// <summary>
        /// Comprueba si el usuario existe existe y el password se corresponde con la almacenada de forma cifrada.
        /// </summary>
        /// <param name="email">Cadena con el EMail del usuario que se quiere consultar.</param>
        /// <param name="password">Cadena con el EMail del usuario que se quiere consultar.</param>
        /// <returns>Retorna TRUE si los datos de autenticación son válidos.</returns>
        bool ValidaUsuario(string email, string password);

        /// <summary>
        /// Retorna el número de usuarios registrados.
        /// </summary>
        /// <returns>Número de Usuarios.</returns>
        int NumUsuarios();

        /// <summary>
        /// OPCIONAL
        /// Retorna el número de usuarios registrados.
        /// </summary>
        /// <returns>Número de Usuarios.</returns>
        int NumUsuariosActivos();

        /// <summary>
        /// Almacena uno de los componentes que puede ser:
        /// Un espacio principal, subespacio, contenedor o un artículo.
        /// </summary>
        /// <param name="e">Objeto de la clase Componente que se quiere almacenar.</param>
        /// <returns>Verdadero o falso en función de si ha conseguido insertar/ actualizar la información.</returns>
        bool GuardaComponente(string tipoElemento, int idUsuario);

        /// <summary>
        /// Lee los datos del elemento referenciado por su ID.
        /// </summary>
        /// <param name="idElemento">Identificador del Componente que se quiere consultar.</param>
        /// <returns>Retorna el objeto con la infromación del conponente buscado o NULL si no se localiza.</returns>
        Elemento LeeComponente(string idElemento);

        /// <summary>
        /// Retorna el número de componentes registrados.
        /// </summary>
        /// <returns>Número de Componentes.</returns>
        int NumComponente();

    }
}