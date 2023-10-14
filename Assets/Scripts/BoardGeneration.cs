using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGeneration : MonoBehaviour
{
    //float variables to indicate x and y when placing tiles
    public float x,y;
    //Object Variable matching with each type of tile to duplicate
    public GameObject MoveBackwardTile, MoveForwardTile, MinusTile, ItemTile, PlusMoney, TileShop, EndTile, StartTile;
    //Object variable to indicate board
    public GameObject Board;

    public PlayerMovement TileLand = new PlayerMovement();

    Quaternion Rotation;
    // Start is called before the first frame update
    void Start()
    {
        //Iinitializes starting point for tile generation
        x = ((float)(-9) / 2);
        y = ((float)(-9) / 2);

        //initializes array with 100 cells, each containing a number indicating what type of tile it is (default, shop etc.)
        int[] Tile = new int[100];
        

        //loop to generate the board with different tiles and guarentees shop at every 20 spaces
        for (int i = 0; i < 99; i++)
        {
            //randomizes a number from 0-99
            int chance = UnityEngine.Random.Range(0, 99);
            Tile[i] = chance;
            // Guarenteed End Tile at 100
            if (i == 90)
            {
                Instantiate(EndTile, new Vector3(x, y), Rotation);
                 
            }
            //Guarenteed Start Tile at 1
            if (i == 0)
            {
                Instantiate(StartTile, new Vector3(x, y), Rotation);
                TileLand.SetTileType(i, 2);
                Debug.Log("Success");
            }
            // if number is from 0 - 9 generates Tile 1 (Move Back) 10% chance
            if (Tile[i] >= 0 && Tile[i] <= 10)
            {
                Instantiate(MoveBackwardTile, new Vector2(x, y), Rotation);
                TileLand.SetTileType(i, 3);
            }
            // if number is from 11 - 21 generates Tile 2 (Move Forward) 10% chance
            if (Tile[i] >= 11 && Tile[i] <= 21)
            {
                Instantiate(MoveForwardTile, new Vector2(x, y), Rotation);
                TileLand.SetTileType(i, 4);
            }
            // if number is from 22 - 42 generates Tile 3 (Lose Money) 20 % chance
            if (Tile[i] >= 22 && Tile[i] <= 42)
            {
                Instantiate(MinusTile, new Vector2(x, y), Rotation);
                TileLand.SetTileType(i, 5);
            }
            //if number is from 43 - 63 generates Tile 4 (Random Item) 20% chance
            if (Tile[i] >= 43 && Tile[i] <= 63)
            {
                Instantiate(ItemTile, new Vector2(x, y), Rotation);
                TileLand.SetTileType(i, 6);
            }
            //if number is from 63 - 103 generates Tile 5 (Gain Money) 40% chance
            if (Tile[i] >= 63 && Tile[i] <= 103)
            {
                Instantiate(PlusMoney, new Vector2(x, y), Rotation);
                TileLand.SetTileType(i, 7);
            }

            //increases x by 1 to move cursor one left
            x += 1;

            // parameter to reset x of cursor coordinate if it goes out of board and also goes up one
            if (x > 5)
            {
                x = ((float)(-9) / 2);
                y++;
            }
            // Guarenteed shop placement at 20,40,60,80
            if (i == 18 || i == 38 || i == 58 || i == 78 || i == 98)
                {
                Instantiate(TileShop, new Vector3(x,y), Rotation);
                }

            TileLand.SetTileType(10, 1);
            TileLand.SetTileType(30, 1);
            TileLand.SetTileType(50, 1);
            TileLand.SetTileType(70, 1);
            TileLand.SetTileType(90, 1);
            TileLand.SetTileType(99, 1);
        }
       

    }

}
