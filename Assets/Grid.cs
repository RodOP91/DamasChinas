using UnityEngine;

public class Grid : MonoBehaviour {
    public Transform hexPrefab;

    public int gridHeight = 17;
    public int gridWidth = 13;

    float hexWidth= 1.73205f;
    float hexHeight= 2.0f;

    public float gap = 0.0f;

    Vector3 startPos;

    private void Start()
    {
        addGap();
        calcStartPos();
        createGrid();
    }

    void addGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;

    }

    void calcStartPos()
    {
        float offset = 0;
        if(gridHeight / 2 % 2 != 0)
        {
            offset = hexWidth / 2;

        }

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, 0, z);
    }

    Vector3 calcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if(gridPos.y %2 != 0)
        {
            offset = hexWidth / 2;
        }

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z + gridPos.y * hexHeight * .75f;

        return new Vector3(x, 0, z);
    }

    void createGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = calcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hex_" + x + "|" + y; 
            }
        }
    }
}
