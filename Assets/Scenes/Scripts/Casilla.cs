using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour {
    //Coordenadas de la casilla
    private  int casillaX;
    private int casillaY;
    private int[] xy;
    //Tipo de casilla: neutral o de un jugador.
    private int tipo_casilla;
    //Indicador de que es casilla.
    private static int tipo = 0;
    //Indicador para saber si tiene pieza o no.
    private bool tiene_pza;
    
    public Casilla(int casillaX, int casillaY, int tipo_casilla, bool tiene_pza)
    {
        this.casillaX = casillaX;
        this.casillaY = casillaY;
        this.tipo_casilla = tipo_casilla;
        this.tiene_pza = tiene_pza;
    }
    //Setters
    private void setCasillaX(int casillaX)
    {
        this.casillaX = casillaX;

    }
    private void setCasillaY(int casillaY)
    {
        this.casillaY = casillaY;

    }

    public void setXY(int x, int y)
    {
        this.xy = new int[] { x, y };

        setCasillaX(x);
        setCasillaY(y);
    }
    public void setTipoCasilla(int tipo_casilla)
    {
        this.tipo_casilla = tipo_casilla;
    }
    public void ponlePieza(bool tiene_pza)
    {
        this.tiene_pza = tiene_pza;
    }

    //Getters
    public int getCoordX()
    {
        return this.casillaX;
    }
    public int getCoordY()
    {
        return this.casillaY;
    }
    public int[] getXY()
    {
        return this.xy;
    }
    public int getTipoCasilla()
    {
        return this.tipo_casilla;
    }
    public int getTipo()
    {
        return tipo;
    }
    public bool tienePza()
    {
        return this.tiene_pza;
    }
}
