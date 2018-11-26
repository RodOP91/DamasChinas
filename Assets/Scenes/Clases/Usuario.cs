using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scenes.Clases
{
    public class Usuario {
        private int IdUsuario;
        private String Nick;
        private String Nombre;
        private String Correo;
        private String Password;


        public Usuario()
        {

        }

        public Usuario(string nick, string password) {
            this.Nick = nick;
            this.Password = password;
        }

        public Usuario(string nick, string nombre, string correo, string password)
        {
            this.Nick = nick;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Password = password;
        }

        public Usuario(int idUsuario, string nick, string nombre, string correo, string password)
        {
            IdUsuario = idUsuario;
            Nick = nick;
            Nombre = nombre;
            Correo = correo;
            Password = password;
        }

        public string getNick() {
            return Nick;
        }
        public string getNombre()
        {
            return Nombre;
        }
        public string getCorreo()
        {
            return Correo;
        }
        public string getPassword()
        {
            return Password;
        }

        public Boolean IniciarSesion() {
            return true;
        }

        public void VerPerfil() {
            //recuperar de base de datos
        }

        public void RegistrarUsuario() {

        }
    }
}
