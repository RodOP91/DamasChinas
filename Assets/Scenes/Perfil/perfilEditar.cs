using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scenes.Clases;

public class perfilEditar : MonoBehaviour {

    public InputField Nick;
    public InputField Nombre;
    public InputField Correo;
    public Button Editar;
    public Button Cancelar;
    public Button Guardar;

    // Use this for initialization
    void Start () {
        Cancelar.gameObject.SetActive(false);
        Guardar.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EditarCampos() {
        Nick.interactable = true;
        Nombre.interactable = true;
        Correo.interactable = true;
        Editar.gameObject.SetActive(false);
        Cancelar.gameObject.SetActive(true);
        Guardar.gameObject.SetActive(true);
    }
    public void CancelarEdicion() {
        Nick.interactable = false;
        Nombre.interactable = false;
        Correo.interactable = false;
        Editar.gameObject.SetActive(true);
        Cancelar.gameObject.SetActive(false);
        Guardar.gameObject.SetActive(false);
    }
    public void GuardarEdicion()
    {
        string nick = Nick.text;
        string nombre = Nombre.text;
        string correo = Correo.text;
        Usuario user = new Usuario(UsuarioP.Usuario.getId(), nick,nombre,correo);
        bool flag = user.EditarUsuario();

        if (flag == true)
        {
            Nick.interactable = false;
            Nombre.interactable = false;
            Correo.interactable = false;
            Editar.gameObject.SetActive(true);
            Cancelar.gameObject.SetActive(false);
            Guardar.gameObject.SetActive(false);
        }
        else
        {

        }
    }
}
