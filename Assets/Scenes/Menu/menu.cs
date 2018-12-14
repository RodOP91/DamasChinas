using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {

    public Text txtNick;

	// Use this for initialization
	void Start () {
        txtNick.text = UsuarioP.Usuario.getNick();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void abrirPerfil() {
        SceneManager.LoadScene(3);
    }

    public void nuevaPartida() {
        SceneManager.LoadScene(6);
    }

    public void Ranking()
    {
        SceneManager.LoadScene(4);
    }
}
