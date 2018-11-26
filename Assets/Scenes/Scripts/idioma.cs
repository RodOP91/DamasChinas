using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class idioma : MonoBehaviour {

    public static string idiomaSelec = "esp";

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
