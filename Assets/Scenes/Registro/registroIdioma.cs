using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class registroIdioma : MonoBehaviour {

    public Text Nombre;
    public Text Pass;
    public Text Pass2;
    public Text Email;
    public Text Registrar;
    public Text Salir;

    private static string[] idiomaEspañol = { "Nombre Completo", "Contraseña", "Repetir Contraseña", "Correo Electronico", "REGISTRAR","SALIR" };
    private static string[] idiomaIngles = { "Full Name", "Password", "Repit Password", "E-Mail", "REGISTER", "EXIT" };

    // Use this for initialization
    void Start () {
        if (idioma.idiomaSeleccionado == 1)
        {
            traducirEspañol();
        }
        if (idioma.idiomaSeleccionado == 2)
        {
            traducirIngles();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void traducirEspañol()
    {
        Nombre.text = idiomaEspañol[0];
        Pass.text = idiomaEspañol[1];
        Pass2.text = idiomaEspañol[2];
        Email.text = idiomaEspañol[3];
        Registrar.text = idiomaEspañol[4];
        Salir.text = idiomaEspañol[5];
}

    public void traducirIngles()
    {
        Nombre.text = idiomaIngles[0];
        Pass.text = idiomaIngles[1];
        Pass2.text = idiomaIngles[2];
        Email.text = idiomaIngles[3];
        Registrar.text = idiomaIngles[4];
        Salir.text = idiomaIngles[5];
    }
}
