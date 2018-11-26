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

    // Use this for initialization
    void Start () {
        Usuario usuario = new Usuario();
        usuario.VerPerfil();

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
