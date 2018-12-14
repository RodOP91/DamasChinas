using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ServerDamas.Server.Interface;
using Unity;
using UnityEngine;
using System.Security.Cryptography;


namespace Assets.Scenes.Clases
{
    public class Usuario {
        private int IdUsuario;
        private String Nick;
        private String Nombre;
        private String Correo;
        private String Password;
        private Registro RegistrosU;

        private TcpClientChannel canal;

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

        public Usuario(int idUsuario, string nick, string nombre, string correo)
        {
            IdUsuario = idUsuario;
            Nick = nick;
            Nombre = nombre;
            Correo = correo;
        }
        public int getId()
        {
            return IdUsuario;
        }
        public Registro GetRegistros()
        {
            return RegistrosU;
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

        private string HashPassword()
        {
            byte[] passB;
            byte[] passH;

            passB = ASCIIEncoding.ASCII.GetBytes(Password);
            passH = new MD5CryptoServiceProvider().ComputeHash(passB);

            return BitConverter.ToString(passH).Replace("-", String.Empty);
        }

        public Usuario IniciarSesion() {
            if (ChannelServices.RegisteredChannels.Length == 0) {
                Debug.Log("canal null");
                canal = new TcpClientChannel();
                ChannelServices.RegisterChannel(canal, false);
            }
            I_damas obj = (I_damas)Activator.GetObject(
                typeof(I_damas), "tcp://localhost:5555/serverDamas");

            if (obj.Equals(null))
            {
                Debug.Log("Error");
                return null;
            }
            else
            {
                string pass = HashPassword();
                List<String> usuario = obj.Ingresar(Nick, pass);
                IdUsuario = Convert.ToInt32(usuario[0]);
                Nick = usuario[1];
                Nombre = usuario[2];
                Password = usuario[3];
                Correo = usuario[4];

                List<int> registros = obj.Registros(IdUsuario);

                if (registros == null) {
                    RegistrosU = new Registro(0,0,0,0);
                } else {
                    RegistrosU = new Registro(registros[1], registros[2], registros[3], registros[0]);
                }
                
                return this;
            }
        }

        public Boolean RegistrarUsuario() {
            if (ChannelServices.RegisteredChannels.Length == 0) {
                Debug.Log("canal null");
                canal = new TcpClientChannel();
                ChannelServices.RegisterChannel(canal, false);
            }
            I_damas obj = (I_damas)Activator.GetObject(
                typeof(I_damas), "tcp://localhost:5555/serverDamas");

            if (obj.Equals(null))
            {
                Debug.Log("Error");
                return false;
            }
            else
            {
                string pass = HashPassword();
                Boolean flag = obj.RegistrarUsuario(Nick, Nombre, pass, Correo);

                return flag;
            }
        }
        public Boolean EditarUsuario()
        {
            if (ChannelServices.RegisteredChannels.Length == 0)
            {
                Debug.Log("canal null");
                canal = new TcpClientChannel();
                ChannelServices.RegisterChannel(canal, false);
            }
            I_damas obj = (I_damas)Activator.GetObject(
                typeof(I_damas), "tcp://localhost:5555/serverDamas");

            if (obj.Equals(null))
            {
                Debug.Log("Error");
                return false;
            }
            else
            {
                return obj.Actualizar(IdUsuario, Nick, Nombre, Correo);
            }
        }
    }
}
