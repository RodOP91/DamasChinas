using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class salir : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Atras(int ventana) {
        if (ventana == 1) {
            SceneManager.LoadScene(0);
        }
        if (ventana == 2)
        {
            SceneManager.LoadScene(1);
        }
        if (ventana == 3)
        {
            SceneManager.LoadScene(1);
        }
        if (ventana == 4)
        {
            SceneManager.LoadScene(0);
        }
        if (ventana == 5)
        {
            SceneManager.LoadScene(1);
        }
    }
}
