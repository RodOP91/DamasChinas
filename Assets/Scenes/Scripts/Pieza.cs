using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza : MonoBehaviour {
    //Coordenadas de la pieza.
    private int x;
    private int y;
    //Jugador dueño de la pieza.
    private int player;
    //Indicador de que es pieza.
    private static int tipo = 1;

    public Pieza(int x, int y, int player)
    {
        this.x = x;
        this.y = y;
        this.player = player;
        
    }
    //Setters
    public void setCoordX(int x)
    {
        this.x = x;

    }
    public void setCoordY(int y)
    {
        this.y = y;

    }
    public void setPlayer(int player)
    {
        this.player = player;
    }
    //Getters
    public int getCoordX()
    {
        return this.x;
    }
    public int getCoordY()
    {
        return this.y;
    }
    public int getPlayer()
    {
        return this.player;
    }
    public int getTipo()
    {
        return tipo;
    }
}
