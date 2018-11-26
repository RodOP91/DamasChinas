using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Resources;
using UnityEngine;

public class logInIdioma : MonoBehaviour {

    public InputField usuario;
    public InputField password;
    public Text registro;
    public Button ingresar;
    public Button invitado;

    public void español() {
        registro.text = default_Es_Mx.logIntxtRegistro;
    }

    public void ingles()
    {
        registro.text = Resource_En_Us.logIntxtRegistro;
    }
}
