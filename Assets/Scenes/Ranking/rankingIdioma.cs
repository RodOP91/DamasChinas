using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankingIdioma : MonoBehaviour {

    public Text Puntaje;
    public Text Ganadas;
    public Text Salir;

    private static string[] idiomaEspañol = { "PUNTAJE", "GANADAS", "SALIR" };
    private static string[] idiomaIngles = { "POINTS", "WON GAMES", "EXIT" };

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
        Puntaje.text = idiomaEspañol[0];
        Ganadas.text = idiomaEspañol[1];
        Salir.text = idiomaEspañol[2];
}

    public void traducirIngles()
    {
        Puntaje.text = idiomaIngles[0];
        Ganadas.text = idiomaIngles[1];
        Salir.text = idiomaIngles[2];
    }
}
