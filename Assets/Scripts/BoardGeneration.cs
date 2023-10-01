using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGeneration : MonoBehaviour
{
    //float variables to indicate x and y when placing tiles
    public float x,y;
    //Object Variable matching with each type of tile to duplicate
    public GameObject Tile1, Tile2, Tile3, Tile4, Tile5, TileShop, EndTile;
    //Object variable to indicate board
    public GameObject Board;

    Quaternion Rotation;
    // Start is called before the first frame update
    void Start()
    {
        x = ((float)(-9) / 2);
        y = ((float)(-9) / 2);
        //initializes array wiht 100 cells, each containing a number indicating what type of tile it is (default, shop etc.)
        int[] Tile = new int[100];
        for (int i = 0; i <= 100; i++)
        {
            int chance = UnityEngine.Random.Range(0, 99);
            Tile[i] = chance;
            if (Tile[i] >= 0 && Tile[i] <= 9)
            {
                Instantiate(Tile1, new Vector2(x, y), Rotation);
            }
            if (Tile[i] >= 10 && Tile[i] <= 19)
            {
                Instantiate(Tile2, new Vector2(x, y), Rotation);
            }
            if (Tile[i] >= 20 && Tile[i] <= 39)
            {
                Instantiate(Tile3, new Vector2(x, y), Rotation);
            }
            if (Tile[i] >= 40 && Tile[i] <= 59)
            {
                Instantiate(Tile4, new Vector2(x, y), Rotation);
            }
            if (Tile[i] >= 60 && Tile[i] <= 99)
            {
                Instantiate(Tile5, new Vector2(x, y), Rotation);
            }
            Debug.Log(x);
            x += 1;
            if (x > 5)
            {
                x = ((float)(-9) / 2);
                y++;
            }
            if (i == 18 || i == 38 || i == 58 || i == 78 || i == 98)
                {
                Instantiate(TileShop, new Vector3(x,y), Rotation);
                }
            if (i == 100)
            {
                Instantiate(EndTile, new Vector3(x, y), Rotation);
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
