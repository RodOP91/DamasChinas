using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scenes.Clases;
using UnityEngine.UI;
using UnityEngine;

public class perfil : MonoBehaviour {

    public InputField txfNick;
    public InputField txfNombre;
    public InputField txfCorreo;
    public InputField txfPassword;

    public Text PJugadas;
    public Text PGanadas;
    public Text PorVictorias;
    public Text Puntos;

    // Use this for initialization
    void Start () {
        txfNick.text = UsuarioP.Usuario.getNick();
        txfNombre.text = UsuarioP.Usuario.getNombre();
        txfCorreo.text = UsuarioP.Usuario.getCorreo();
        txfPassword.text = UsuarioP.Usuario.getPassword();

        PJugadas.text = Convert.ToString(UsuarioP.Usuario.GetRegistros().GetPjugadas());
        PGanadas.text = Convert.ToString(UsuarioP.Usuario.GetRegistros().GetPganadas());
        PorVictorias.text = Convert.ToString(UsuarioP.Usuario.GetRegistros().GetPorVictorias());
        Puntos.text = Convert.ToString(UsuarioP.Usuario.GetRegistros().GetPuntos());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
