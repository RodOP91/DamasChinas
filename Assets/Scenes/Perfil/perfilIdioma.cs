using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perfilIdioma : MonoBehaviour {

    public Text Titulo;
    public Text Pjugadas;
    public Text PGanadas;
    public Text PorVictorias;
    public Text Puntos;
    public Text Editar;
    public Text Cancelar;
    public Text Guardar;
    public Text Salir;

    private static string[] idiomaEspañol = {"Estadisticas Personales", "Partidas Jugadas", "Partidas Ganadas", "Porcentaje de Victorias", "Puntos Totales", "EDITAR", "CANCELAR", "GUARDAR", "SALIR"};
    private static string[] idiomaIngles = {"Played Games", "Played Games", "Won Games", "Win Percentage", "Total Points", "EDIT","CANCEL", "SAVE", "EXIT"};

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
        Titulo.text = idiomaEspañol[0];
        Pjugadas.text = idiomaEspañol[1];
        PGanadas.text = idiomaEspañol[2];
        PorVictorias.text = idiomaEspañol[3];
        Puntos.text = idiomaEspañol[4];
        Editar.text = idiomaEspañol[5];
        Cancelar.text = idiomaEspañol[6];
        Guardar.text = idiomaEspañol[7];
        Salir.text = idiomaEspañol[8];
    }

    public void traducirIngles()
    {
        Titulo.text = idiomaIngles[0];
        Pjugadas.text = idiomaIngles[1];
        PGanadas.text = idiomaIngles[2];
        PorVictorias.text = idiomaIngles[3];
        Puntos.text = idiomaIngles[4];
        Editar.text = idiomaIngles[5];
        Cancelar.text = idiomaIngles[6];
        Guardar.text = idiomaIngles[7];
        Salir.text = idiomaIngles[8];
    }
}
