using UnityEngine;
using System;
public class Grid : MonoBehaviour {
    public Transform BlueHexPrefab;
    public Transform YellowHexPrefab;
    public Transform GreenHexPrefab;
    public Transform RedHexPrefab;
    public Transform OrangeHexPrefab;
    public Transform PurpleHexPrefab;
    public Transform WhiteHexPrefab;
    

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
    }

    void addGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;

    }

    Vector3 calcWorldPos(int q, int r)
    {
        float x = (hexHeight/2) * Mathf.Sqrt(3.0f) * (q + r / 2.0f);
        float z = (hexHeight/2)* 3.0f / 2.0f * r;
        return new Vector3(x, 0, z);
    }

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
                    Transform hexP6 = Instantiate(YellowHexPrefab) as Transform;
                    hexP6.position = calcWorldPos(q, r);
                    hexP6.parent = this.transform;
                    hexP6.name = "Hex_" + q + "|" + r;
                }
                if(q > 4)
                {
                    Transform hexP3 = Instantiate(RedHexPrefab) as Transform;
                    hexP3.position = calcWorldPos(q, r);
                    hexP3.parent = this.transform;
                    hexP3.name = "Hex_" + q + "|" + r; 
                }
                if(q>-5 && q<5)
                {
                    Transform hexdefault = Instantiate(WhiteHexPrefab) as Transform;
                    hexdefault.position = calcWorldPos(q, r);
                    hexdefault.parent = this.transform;
                    hexdefault.name = "Hex_" + q + "|" + r;
                }
                if(q==-4 && r == 0)
                {
                    
                    Debug.Log(mapSize);
                    for (int a=q; a <= 0; a++)
                    { 
                        for (int b=r; b <= 0+a; b--) 
                        {
                            Transform hexP5 = Instantiate(PurpleHexPrefab) as Transform;
                            hexP5.position = calcWorldPos(a, b);
                            hexP5.parent = this.transform;
                            hexP5.name = "Hex_" + a + "|" + b;
                        }
                    }
                }

                
             
            }
        }
    }
}
