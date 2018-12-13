using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntarAObjeto : MonoBehaviour {

    public static string objetoSeleccionado;
    public string objetoLocal;
    public RaycastHit elObjeto;
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out elObjeto, LayerMask.GetMask("Tablero")))
        {
            objetoSeleccionado = elObjeto.transform.gameObject.name;

            if (elObjeto.transform.tag.Equals("player"))
            {
                
                objetoLocal = "pieza: " + elObjeto.transform.gameObject.GetComponent<Pieza>().getCoordX()
                        + elObjeto.transform.gameObject.GetComponent<Pieza>().getCoordY();
                /*Debug.Log(elObjeto.transform.gameObject.tag);
                Debug.Log("Seleccionó una pieza " + elObjeto.transform.gameObject.GetComponent<Pieza>().getCoordX()
                    + "," + elObjeto.transform.gameObject.GetComponent<Pieza>().getCoordY());*/
            }
            if (elObjeto.transform.tag.Equals("casilla"))
            {
                
                objetoLocal = "casilla: " + elObjeto.transform.gameObject.GetComponent<Casilla>().getCoordX()
                        + elObjeto.transform.gameObject.GetComponent<Casilla>().getCoordY() + "Tiene pieza: " 
                        + elObjeto.transform.gameObject.GetComponent<Casilla>().tienePza();

               /*Debug.Log("Seleccionó una casilla");
                Debug.Log(elObjeto.transform.gameObject.GetComponent<Casilla>().getCoordX() + ","
                    + elObjeto.transform.gameObject.GetComponent<Casilla>().getCoordY() + " "
                    + elObjeto.transform.gameObject.GetComponent<Casilla>().tienePza());*/
            }
                
                    

        }

    }
}
