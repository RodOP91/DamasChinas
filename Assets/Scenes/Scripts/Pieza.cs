using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Pieza : MonoBehaviour {
    //Coordenadas de la pieza.
    private int x;
    private int y;
    private int[] xy = new int[2];
    private int pos_relativa=0;
    //Posiciones contiguas y de saltos posibles de la pieza
    private List<int[]> pos_contiguas;
    private List<int[]> pos_salto;
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
    private void setCoordX(int x)
    {
        this.x = x;

    }
    private void setCoordY(int y)
    {
        this.y = y;

    }
    public void setXY(int x, int y)
    {
        this.xy = new int[] {x,y };
        setCoordX(x);
        setCoordY(y);
        calcPosicionesContiguas();
        calcPosicionesDeSalto();
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

    /*Método para calcular las 6 posibles coordenadas de posiciones contiguas a partir de un origen x,y.
     * Las coordenadas, son relativas al tablero, no al mundo.
     */
    private void calcPosicionesContiguas()
    {
        pos_contiguas = new List<int[]>() {
        new int[]{ this.x, this.y+1},
        new int[] { this.x+1, this.y},
        new int[] { this.x+1, this.y-1},
        new int[] { this.x, this.y-1},
        new int[] { this.x-1, this.y},
        new int[] { this.x-1, this.y+1},
    };

        /*for (int x = 0; x < 6; x++)
        {
            int[] aux= pos_contiguas[x];
            for(int y=0; y < 2; y++)
            {
                Debug.Log(aux[0] + " " + aux[1]);
            }
        }*/
    }

    private void calcPosicionesDeSalto()
    {
        pos_salto = new List<int[]>() {
        new int[]{ this.x, this.y+2},
        new int[] { this.x+2, this.y},
        new int[] { this.x+2, this.y-2},
        new int[] { this.x, this.y-2},
        new int[] { this.x-2, this.y},
        new int[] { this.x-2, this.y+2},
    };

        /*for (int x = 0; x < 6; x++)
        {
            int[] aux= pos_contiguas[x];
            for(int y=0; y < 2; y++)
            {
                Debug.Log(aux[0] + " " + aux[1]);
            }
        }*/
    }


    /*Método para determinar si la casilla seleccionada es contigua en relación a la pieza.
     */
    public bool esContigua(Casilla casilla_destino)
    {
        int[] coord_provista = casilla_destino.getXY();
        int[] coord_destino = pos_contiguas.Find(l => l.SequenceEqual(coord_provista));
        pos_relativa = pos_contiguas.FindIndex(l => l.SequenceEqual(coord_provista));

        if (coord_destino != null)
        {
            if (coord_provista.SequenceEqual(coord_destino))
            {
                Debug.Log("Coordenada provista " + coord_provista[0] + ", " + coord_provista[1]);
                Debug.Log("Posible coordenada contigua " + coord_destino[0] + ", " + coord_destino[1]);
                Debug.Log("ATENCION" + (casilla_destino.getXY())[0] + " " + (casilla_destino.getXY())[1]);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
       
        
    }

    public bool esSalto(Casilla casilla_destino)
    {
        int[] coord_provista = casilla_destino.getXY();
        int[] coord_destino = pos_salto.Find(l => l.SequenceEqual(coord_provista));
        pos_relativa = pos_salto.FindIndex(l => l.SequenceEqual(coord_provista));

        if (coord_destino != null)
        {
            if (coord_provista.SequenceEqual(coord_destino))
            {
                Debug.Log("Coordenada provista " + coord_provista[0] + ", " + coord_provista[1]);
                Debug.Log("Posible coordenada contigua " + coord_destino[0] + ", " + coord_destino[1]);
                Debug.Log("ATENCION" + (casilla_destino.getXY())[0] + " " + (casilla_destino.getXY())[1]);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }

    public int pedirPosicionOpuesta(int pos_relativa)
    {
        if (pos_relativa <= 2)
        {
            return pos_relativa + 3;
        }
        else
        {
            return pos_relativa - 3;
        }
    }

    public void actualizarDatos(GameObject casilla_destino)
    {
        this.setXY(casilla_destino.gameObject.GetComponent<Casilla>().getCoordX(), casilla_destino.gameObject.GetComponent<Casilla>().getCoordY());
        this.transform.SetParent(casilla_destino.transform);
    }

    /*Método para determinar si la casilla opuesta a la primera pieza está vacía o no.*/
    
    public bool movimientoValido(GameObject pza, GameObject cas)
    {
        int aux;
        Pieza pza_aux = pza.transform.gameObject.GetComponent<Pieza>();
        Casilla cas_aux =cas.transform.gameObject.GetComponent<Casilla>();
        //Debug.Log("ATENCION");
        
        if (esContigua(cas_aux))
        {
            if (cas_aux.tienePza())
            {
                return false;
                /*Pieza pza_contigua = cas.GetComponentInChildren<Pieza>();
                aux = pza_contigua.pos_contiguas[pos_relativa];
                if ((Tablero.tablero.Find(casilla => casilla.getXY().Equals(aux))).tienePza())
                {
                    return false;
                }
                else
                {
                    Debug.Log("ATENCION" + esContigua(cas_aux) + " " + esSalto(cas_aux));
                    return true;
                    
                }*/
            }
            else
            {
                Debug.Log("ATENCION" + esContigua(cas_aux) + " " + esSalto(cas_aux));
                return true;
                
            }
        }
        else
        {
            if (esSalto(cas_aux))
            {
                aux = pos_salto.FindIndex(l => l.SequenceEqual(cas_aux.getXY()));
                Casilla cas_contigua = Tablero.tablero.Find(casilla => casilla.getXY().SequenceEqual(pos_contiguas[aux]));
                
                //Debug.Log("Auxiliar : " + aux + "posible salto: " + (pos_salto[aux])[0] + (pos_salto[aux])[1] + "coord provista: " + (cas_aux.getXY())[0] + (cas_aux.getXY())[1]);
                if(cas_contigua.tienePza() && cas_aux.tienePza() == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //Debug.Log("ATENCION" + esContigua(cas_aux) + " " + esSalto(cas_aux));
            return false;
        }
    }
}
