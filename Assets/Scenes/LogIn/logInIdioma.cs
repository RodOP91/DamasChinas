using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class logInIdioma : MonoBehaviour {

    public Text txtUsuario;
    public Text txtPassword;
    public Text txtRegistrarse;
    public Text txtIngresar;
    public Text txtInvitado;
    public Text txtEspañol;
    public Text txtIngles;
    private static string[] idiomaEspañol = { "USUARIO...", "CONTRASEÑA...", "Registrarse", "Ingresar", "Invitado", "Español", "Ingles" };
    private static string[] idiomaIngles = { "USER...", "PASSWORD...", "Register", "Log In", "Invitate", "Spanish", "English" };

    // Use this for initialization
    void Start () {
        traducirEspañol();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void traducirEspañol() {
        if(idioma.idiomaSeleccionado == 1) {
            txtUsuario.text = idiomaEspañol[0];
            txtPassword.text = idiomaEspañol[1];
            txtRegistrarse.text = idiomaEspañol[2];
            txtIngresar.text = idiomaEspañol[3];
            txtInvitado.text = idiomaEspañol[4];
            txtEspañol.text = idiomaEspañol[5];
            txtIngles.text = idiomaEspañol[6];
        }
    }

    public void traducirIngles() {
        if (idioma.idiomaSeleccionado == 2) {
            txtUsuario.text = idiomaIngles[0];
            txtPassword.text = idiomaIngles[1];
            txtRegistrarse.text = idiomaIngles[2];
            txtIngresar.text = idiomaIngles[3];
            txtInvitado.text = idiomaIngles[4];
            txtEspañol.text = idiomaIngles[5];
            txtIngles.text = idiomaIngles[6];
        }
    }
}
