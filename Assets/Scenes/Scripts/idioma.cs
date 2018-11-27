using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class idioma : MonoBehaviour {

    public static int idiomaSeleccionado = 1;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void setIdiomaSelec(int idioma) {
        idiomaSeleccionado = idioma;
    }
}
