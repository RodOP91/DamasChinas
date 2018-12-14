using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class menuIdioma : MonoBehaviour {

    public Text txtNueva;
    public Text txtBuscar;
    public Text txtClasificacion;
    public Text txtPerfil;
    public Text txtSalir;
    public Text txtChatMsg;

    private static string[] idiomaEspañol = {"Perfil","Nueva Partida","Buscar Partida","Clasificación","Salir", "Ingresa tu Mensaje..."};
    private static string[] idiomaIngles = { "Profile", "New Game", "Search Game", "Ranking", "EXIT", "Enter Text..."};

    // Use this for initialization
    void Start () {
        if (idioma.idiomaSeleccionado == 1) {
            traducirEspañol();
        }
        if (idioma.idiomaSeleccionado == 2) {
            traducirIngles();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void traducirEspañol() {
            txtNueva.text = idiomaEspañol[1];
            txtBuscar.text = idiomaEspañol[2];
            txtClasificacion.text = idiomaEspañol[3];
            txtPerfil.text = idiomaEspañol[0];
            txtSalir.text = idiomaEspañol[4];
            txtChatMsg.text = idiomaEspañol[5];
    }

    public void traducirIngles() {
            txtNueva.text = idiomaIngles[1];
            txtBuscar.text = idiomaIngles[2];
            txtClasificacion.text = idiomaIngles[3];
            txtPerfil.text = idiomaIngles[0];
            txtSalir.text = idiomaIngles[4];
            txtChatMsg.text = idiomaIngles[5];
    }
}
