using System;
using System.Collections.Generic;


namespace ServerDamas.Server.Interface
{
    public interface I_damas{
        //METODOS DE USUARIOS

        Boolean RegistrarUsuario(String nick, String nombre, string password, String correo);

        List<String> Ingresar(String nick, string password);

        List<int> Registros(int id);

        List<String> Ranking();

        Boolean Actualizar(int id, string nick, string nombre, string correo);
    }
}
