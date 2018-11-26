using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using Assets.Scenes.Clases;


public class logIn : MonoBehaviour {

    public GameObject DamasClientManager;
    public InputField txfUsuario;
    public InputField txfPassword;
    public Image warning;
    public Text warningTxt;


    private void Awake() {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void iniciarSesion() {
        string user = this.txfUsuario.text;
        string pass = this.txfPassword.text;

        if (user.Equals("") || pass.Equals("")) {
            warning.gameObject.SetActive(true);
        } else {
            Usuario usuario = new Usuario(user, pass);
            if (usuario.IniciarSesion() == true) {
                UsuarioP.Usuario = usuario;
                SceneManager.LoadScene(1);
            } else {
                warningTxt.text = "DATOS INCORRECTOS";
                warning.gameObject.SetActive(true);
            }
        }
    }

    public void registrarse(){
        SceneManager.LoadScene(4);
    }
}
