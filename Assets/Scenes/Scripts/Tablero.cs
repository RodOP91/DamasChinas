using UnityEngine;
using System.Collections.Generic;
public class Tablero : MonoBehaviour {
    //Casilla y pieza azules
    public GameObject BlueHexPrefab;
    public GameObject BluePiecePrefab;

    //Casilla y pieza amarillas
    public GameObject YellowHexPrefab;
    public GameObject YellowPiecePrefab;

    //Casilla y pieza verdes
    public GameObject GreenHexPrefab;
    public GameObject GreenPiecePrefab;

    //Casilla y pieza rojas
    public GameObject RedHexPrefab;
    public GameObject RedPiecePrefab;

    //Casilla y pieza naranjas
    public GameObject OrangeHexPrefab;
    public GameObject OrangePiecePrefab;

    //Casilla y pieza moradas
    public GameObject PurpleHexPrefab;
    public GameObject PurplePiecePrefab;

    //Casilla neutral del tablero
    public GameObject WhiteHexPrefab;

    private List<Pieza> jugador1, jugador2, jugador3, jugador4, jugador5, jugador6;
    private List<Pieza> piezas_desordenadas = new List<Pieza>();
    public static List<Casilla> tablero = new List<Casilla>();

    private Vector3 mouseOver= new Vector3(0,0,0);
    private Vector3 inicioArrastre = new Vector3(0,0,0);
    private Vector3 finArrastre= new Vector3(0,0,0);

    RaycastHit hitInfo = new RaycastHit();
    GameObject pieza_seleccionada;
    GameObject casilla_seleccionada;
    int pza_sel_x;
    int pza_sel_y;
    

    public static int gridHeight = 4;
    public static int gridWidth = 4;

    float hexWidth= 1.73205f;
    float hexHeight= 2.0f;

    public float gap = 0.0f;

    Vector3 startPos= new Vector3(0, 0, 0);

    private void Start()
    {
        addGap();
        GenerarTablero();
        //Debug.Log("hay " + piezas_desordenadas.Count);
        OrdenarPiezas();
        
    }

    private void Update()
    {
        /*UpdateMouseOver();

        //Debug.Log(mouseOver);
        int x = (int)mouseOver.x;
        int y = (int)mouseOver.z;*/
        if (Input.GetMouseButtonDown(0))
        { 
            SeleccionarObjeto();  
        }

        if(pieza_seleccionada!=null && casilla_seleccionada != null)
        {
            MoverPieza();
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            MoverPieza((int)inicioArrastre.x, (int)inicioArrastre.y, x, y);
        }*/

        
    }

    private void SeleccionarObjeto()
    {
        GameObject temp = GameObject.Find(ApuntarAObjeto.objetoSeleccionado);
        if (temp.tag.Equals("casilla"))
        {
            casilla_seleccionada = temp;
        }
        if (temp.tag.Equals("player"))
        {
            pieza_seleccionada = temp;
        }
    }
            
    
    
    private void MoverPieza()
    {
        if (pieza_seleccionada.gameObject.GetComponent<Pieza>()
            .movimientoValido(pieza_seleccionada, casilla_seleccionada))
        {
            pieza_seleccionada.GetComponentInParent<Casilla>().ponlePieza(false);
            pieza_seleccionada.transform.position = calcPiecePos(casilla_seleccionada.transform.gameObject.GetComponent<Casilla>().getCoordX(),
                casilla_seleccionada.transform.gameObject.GetComponent<Casilla>().getCoordY());
            pieza_seleccionada.transform.gameObject.GetComponent<Pieza>().actualizarDatos(casilla_seleccionada);

            casilla_seleccionada.transform.gameObject.GetComponent<Casilla>().ponlePieza(true);
            

            pieza_seleccionada = null;
            casilla_seleccionada = null;
        }
        else
        {
            Debug.Log("Movimiento invalido");
        }
        
    }
    
    //Método que agrega un espacio entre las casillas hexagonales
    void addGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;

    }
    //Método para calcular la posición de las casillas.
    Vector3 calcHexPos(int q, int r)
    {
        float x = (hexHeight/2) * Mathf.Sqrt(3.0f) * (q + r / 2.0f);
        float z = (hexHeight/2)* 3.0f / 2.0f * r;
        return new Vector3(x, 0, z);
    }
    //Método para calcular la posición de las piezas.
    Vector3 calcPiecePos(int q, int r)
    {
        float x = (hexHeight/2) * Mathf.Sqrt(3.0f) * (q + r / 2.0f);
        float z = (hexHeight/2)* 3.0f / 2.0f * r;
        return new Vector3(x, 0.4f, z);
    }


    /*Sección relativa a la generación física del tablero y sus piezas. 
     * Se asignan y ordenan las coordenadas de las piezas*/

    /*Método para generar las estrella con sus 6 picos. Cada uno de los picos corresponderá a un jugador.*/
    void GenerarTablero()
    {
        Debug.Log("Generando figura hexagonal central...");

        
        int mapSize = Mathf.Max(gridWidth, gridHeight);
        
        for (int q = -mapSize-4; q <= mapSize+4; q++)
        {
            int r1 = Mathf.Max(-mapSize, -q - mapSize);
            int r2 = Mathf.Min(mapSize, -q + mapSize);
            for (int r = r1; r <= r2; r++)
            {
                if(q < -4)
                {
                    GameObject hexP2 = Instantiate(YellowHexPrefab) as GameObject;
                    hexP2.transform.position = calcHexPos(q, r);
                    hexP2.transform.SetParent(this.transform);
                    hexP2.name = "Hex_" + q + "|" + r;
                    Casilla c = hexP2.GetComponent<Casilla>();
                    c.setXY(q, r);            
                    c.setTipoCasilla(2);
                    c.ponlePieza(true);
                    tablero.Add(hexP2.GetComponent<Casilla>());
                    

                    GameObject pzP2 = Instantiate(YellowPiecePrefab) as GameObject;
                    pzP2.transform.SetParent(hexP2.transform);
                    pzP2.transform.position= calcPiecePos(q, r);
                    pzP2.name = "Pieza " + q + "|" + r;
                    Pieza p = pzP2.GetComponent<Pieza>();
                    p.setXY(q, r);
                    p.setPlayer(2);
                    piezas_desordenadas.Add(p);

                }
                if(q > 4)
                {
                    GameObject hexP3 = Instantiate(RedHexPrefab) as GameObject;
                    hexP3.transform.position = calcHexPos(q, r);
                    hexP3.transform.SetParent(this.transform);
                    hexP3.name = "Hex_" + q + "|" + r;
                    Casilla c = hexP3.GetComponent<Casilla>();
                    c.setXY(q, r);
                    c.setTipoCasilla(3);
                    c.ponlePieza(true);
                    tablero.Add(hexP3.GetComponent<Casilla>());

                    GameObject pzP3 = Instantiate(RedPiecePrefab) as GameObject;
                    pzP3.transform.SetParent(hexP3.transform);
                    pzP3.transform.position = calcPiecePos(q, r);
                    pzP3.name = "Pieza " + q + "|" + r;
                    Pieza p = pzP3.GetComponent<Pieza>();
                    p.setXY(q, r);
                    p.setPlayer(3);
                    piezas_desordenadas.Add(p);
                }
                if(q>-5 && q<5)
                {
                    GameObject hexdefault = Instantiate(WhiteHexPrefab) as GameObject;
                    hexdefault.transform.position = calcHexPos(q, r);
                    hexdefault.transform.SetParent(this.transform);
                    hexdefault.name = "Hex_" + q + "|" + r;
                    Casilla c = hexdefault.GetComponent<Casilla>();
                    c.setXY(q, r);
                    c.setTipoCasilla(0);
                    tablero.Add(hexdefault.GetComponent<Casilla>());
                }
                
                if(q==-4 && r == 0)
                {
                    Debug.Log(mapSize);
                    int aux= -1;
                    
                    for (int a=q; a < 0; a++)
                    {
                        int b = 0 + aux;
                        while (b >= -4)
                        {
                            int x = a;
                            int y = b;

                            GameObject hexP6 = Instantiate(PurpleHexPrefab) as GameObject;
                            hexP6.transform.position = calcHexPos(x, y);
                            hexP6.transform.SetParent(this.transform);
                            hexP6.name = "Hex_" + x + "|" + y;
                            Casilla c = hexP6.GetComponent<Casilla>();
                            c.setXY(x, y);
                            c.setTipoCasilla(6);
                            c.ponlePieza(true);
                            tablero.Add(hexP6.GetComponent<Casilla>());

                            b--;

                            GameObject pzP6 = Instantiate(PurplePiecePrefab) as GameObject;
                            pzP6.transform.SetParent(hexP6.transform);
                            pzP6.transform.position = calcPiecePos(x, y);
                            pzP6.name = "Pieza " + x + "|" + y;
                            Pieza p = pzP6.GetComponent<Pieza>();
                            p.setXY(x, y);
                            p.setPlayer(6);
                            piezas_desordenadas.Add(p);

                            if (b == -4)
                            {
                                aux--;
                            }
                        }
                    }
                }

                if (q == 4 && r == 0)
                {
                    Debug.Log(mapSize);
                    int aux = 1;

                    for (int a = q; a > 0; a--)
                    {
                        int b = 0 + aux;
                        while (b <= 4)
                        {
                            int x = a;
                            int y = b;

                            GameObject hexP4 = Instantiate(GreenHexPrefab) as GameObject;
                            hexP4.transform.position = calcHexPos(x, y);
                            hexP4.transform.SetParent(this.transform);
                            hexP4.name = "Hex_" + x + "|" + y;
                            Casilla c = hexP4.GetComponent<Casilla>();
                            c.setXY(x, y);
                            c.setTipoCasilla(4);
                            c.ponlePieza(true);
                            tablero.Add(hexP4.GetComponent<Casilla>());

                            GameObject pzP4 = Instantiate(GreenPiecePrefab) as GameObject;
                            pzP4.transform.SetParent(hexP4.transform);
                            pzP4.transform.position = calcPiecePos(x, y);
                            pzP4.name = "Pieza " + x + "|" + y;
                            Pieza p = pzP4.GetComponent<Pieza>();
                            p.setXY(x, y);
                            p.setPlayer(4);
                            piezas_desordenadas.Add(p);

                            b++;
                            if (b == 4)
                            {
                                aux++;
                            }
                        }
                    }
                }
                
                if (q == 4 && r == -4)
                {
                    Debug.Log(mapSize);
                    int aux = -8;
                    
                    for (int a = q; a > 0; a--)
                    {
                        int b = -5;
                        
                        while (b >= aux)
                        {
                            int x = a;
                            int y = b;

                            GameObject hexP1 = Instantiate(BlueHexPrefab) as GameObject;
                            hexP1.transform.position = calcHexPos(x, y);
                            hexP1.transform.SetParent(this.transform);
                            hexP1.name = "Hex_" + x + "|" + y;
                            Casilla c = hexP1.GetComponent<Casilla>();
                            c.setXY(x, y);
                            c.setTipoCasilla(1);
                            c.ponlePieza(true);
                            tablero.Add(hexP1.GetComponent<Casilla>());

                            GameObject pzP1 = Instantiate(BluePiecePrefab) as GameObject;
                            pzP1.transform.SetParent(hexP1.transform);
                            pzP1.transform.position = calcPiecePos(x, y);
                            pzP1.name = "Pieza " + x + "|" + y;
                            Pieza p = pzP1.GetComponent<Pieza>();
                            p.setXY(x, y);
                            p.setPlayer(1);
                            piezas_desordenadas.Add(p);
                            b--;
                            if (b < aux)
                            {
                                aux++;
                            }
                        }
                    }
                }

                if (q == -4 && r == 4)
                {
                    Debug.Log(mapSize);
                    int aux = 8;

                    for (int a = q; a < 0; a++)
                    {
                        int b = 5;
                        while (b <= aux)
                        {
                            int x = a;
                            int y = b;

                            GameObject hexP5 = Instantiate(OrangeHexPrefab) as GameObject;
                            hexP5.transform.position = calcHexPos(x, y);
                            hexP5.transform.SetParent(this.transform);
                            hexP5.name = "Hex_" + x + "|" + y;
                            Casilla c = hexP5.GetComponent<Casilla>();
                            c.setXY(x, y);
                            c.setTipoCasilla(5);
                            c.ponlePieza(true);
                            tablero.Add(hexP5.GetComponent<Casilla>());

                            GameObject pzP5 = Instantiate(OrangePiecePrefab) as GameObject;
                            pzP5.transform.SetParent(hexP5.transform);
                            pzP5.transform.position = calcPiecePos(x, y);
                            pzP5.name = "Pieza " + x + "|" + y;
                            Pieza p = pzP5.GetComponent<Pieza>();
                            p.setXY(x, y);
                            p.setPlayer(5);
                            piezas_desordenadas.Add(p);

                            b++;
                            if (b > aux)
                            {
                                aux--;
                            }
                        }
                    }
                }

            }
        }
    }
/*Método que inserta a las piezas de cada jugador en listas por separado.*/
    public void OrdenarPiezas()
    {
        jugador1 = piezas_desordenadas.FindAll(p => p.getPlayer().Equals(1));
        jugador2 = piezas_desordenadas.FindAll(p => p.getPlayer().Equals(2));
        jugador3 = piezas_desordenadas.FindAll(p => p.getPlayer().Equals(3));
        jugador4 = piezas_desordenadas.FindAll(p => p.getPlayer().Equals(4));
        jugador5 = piezas_desordenadas.FindAll(p => p.getPlayer().Equals(5));
        jugador6 = piezas_desordenadas.FindAll(p => p.getPlayer().Equals(6));

        /*for (int x = 0; x < 6; x++)
        {
            for(int y=0; y < 10; y++)
            {
                Debug.Log(piezas_ordenadas[x, y].transform.gameObject.GetComponent<Pieza>().getCoordX() + ", "
                + piezas_ordenadas[x, y].transform.gameObject.GetComponent<Pieza>().getCoordY());
            }
            
        }*/
    }
}
