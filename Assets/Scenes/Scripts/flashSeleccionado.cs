using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashSeleccionado : MonoBehaviour {

    public GameObject objetoSeleccionado;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool mirandoAObjeto = false;
    public bool flasheando = true;
    public bool iniciarFlash = false;

	void Update () {
        
            if (mirandoAObjeto == true)
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);

            }
        
        

	}

    void OnMouseOver()
    {
        objetoSeleccionado = GameObject.Find(ApuntarAObjeto.objetoSeleccionado);
        mirandoAObjeto = true;
        if (flasheando == false)
        {
            iniciarFlash = true;
            StartCoroutine(FlashearObjeto());
        }
    }

    void OnMouseExit()
    {
        iniciarFlash = false;
        mirandoAObjeto = false;
        StopCoroutine(FlashearObjeto());
        if (objetoSeleccionado.gameObject.tag.Equals("player"))
        {
            if (objetoSeleccionado.GetComponent<Pieza>().getPlayer().Equals(1))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(1, 25, 130, 255);
            }
            if (objetoSeleccionado.GetComponent<Pieza>().getPlayer().Equals(2))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(164, 122, 8, 255);
            }
            if (objetoSeleccionado.GetComponent<Pieza>().getPlayer().Equals(3))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(159, 2, 0, 255);
            }
            if (objetoSeleccionado.GetComponent<Pieza>().getPlayer().Equals(4))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(11, 84, 11, 255);
            }
            if (objetoSeleccionado.GetComponent<Pieza>().getPlayer().Equals(5))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(190, 70, 0, 255);
            }
            if (objetoSeleccionado.GetComponent<Pieza>().getPlayer().Equals(6))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(90, 11, 101, 255);
            }
        }

        if (objetoSeleccionado.gameObject.tag.Equals("casilla"))
        {
            if (objetoSeleccionado.gameObject.GetComponent<Casilla>().getTipoCasilla().Equals(0))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color = new Color32(1, 1, 1, 1);
            }
            if (objetoSeleccionado.gameObject.GetComponent<Casilla>().getTipoCasilla().Equals(1))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(55, 92, 250, 255);
            }
            if (objetoSeleccionado.gameObject.GetComponent<Casilla>().getTipoCasilla().Equals(2))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(224, 207, 33, 255);
            }
            if (objetoSeleccionado.gameObject.GetComponent<Casilla>().getTipoCasilla().Equals(3))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(233, 38, 30, 255);
            }
            if (objetoSeleccionado.gameObject.GetComponent<Casilla>().getTipoCasilla().Equals(4))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(0, 178, 39, 255);
            }
            if (objetoSeleccionado.gameObject.GetComponent<Casilla>().getTipoCasilla().Equals(5))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(226, 103, 39, 255);
            }
            if (objetoSeleccionado.gameObject.GetComponent<Casilla>().getTipoCasilla().Equals(6))
            {
                objetoSeleccionado.GetComponent<Renderer>().material.color =
                    new Color32(159, 57, 248, 255);
            }

        }

    }

    IEnumerator FlashearObjeto()
    {
        while(mirandoAObjeto == true)
        {
            yield return new WaitForSeconds(0.07f);
            if (flasheando == true)
            {
                if(blueCol <= 30)
                {
                    flasheando = false;
                }
                else
                {
                    blueCol -= 25;
                    greenCol -= 1;
                }
            }
            if (flasheando==false) {

                if (blueCol >= 250)
                {
                    flasheando = true;
                }
                else
                {
                    blueCol +=25;
                    greenCol += 1;
                }
            }
            
        }
    }
}
