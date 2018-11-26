using System.Collections;
using System.Collections.Generic;
using Assets.Scenes.Clases;
using UnityEngine.UI;
using UnityEngine;

public class registrar : MonoBehaviour {

    public InputField txfNick;
    public InputField txfNombre;
    public InputField txfPass;
    public InputField txfPass2;
    public InputField txfCorreo;
    public Image warning;
    public Text warningTxt;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Registrar() {
        string nick = txfNick.text;
        string nombre = txfNombre.text;
        string pass = txfPass.text;
        string pass2 = txfPass2.text;
        string correo = txfCorreo.text;
        if (nick.Equals("") || nombre.Equals("") || pass.Equals("") || pass2.Equals("") || correo.Equals("")) {
            warning.gameObject.SetActive(true);
        } else {
            if (pass.Equals(pass2)) {
                Usuario usuario = new Usuario(nick,nombre,correo,pass);
                usuario.RegistrarUsuario();
            } else {
                warningTxt.text = "LAS CONTRASEÑAS NO COINCIDEN";
                warning.gameObject.SetActive(true);
            }
        }
    }
}
