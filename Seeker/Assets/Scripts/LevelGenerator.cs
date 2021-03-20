using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{

    public Vector3Int tilemapSize;
    public Tilemap fluidLevel;
    public RuleTile fluidTile;
    public Tilemap groundLevel;
    public RuleTile groundTile;
    public Tilemap wallLevel;
    public RuleTile wallTile;

    private int totalWidth;
    private int totalHeight;
    private int totalArea;

    public void Start(){
        generateLevel();
    }

    public void generateLevel(){

        totalWidth = tilemapSize.x;
        totalHeight = tilemapSize.y;
        totalArea = totalWidth * totalHeight;

        int roomArea = 0;

        //Generate randomly sized fluid within a range
        while (roomArea < totalArea / 4)
        {

            int roomWidth = Random.Range(8, totalWidth / 8);
            int roomHeight = Random.Range(8, totalHeight / 8);

            roomArea += roomWidth * roomHeight;

            int roomStartX = Random.Range(1, (totalWidth - (roomWidth + 1)));
            int roomStartY = Random.Range(1, (totalHeight - (roomHeight + 1)));

            int x = roomStartX;
            int y = roomStartY;
            for (int i = 0; i < roomWidth; i++)
            {

                for (int j = 0; j <= roomHeight; j++)
                {

                    fluidLevel.SetTile(new Vector3Int(x, y, 0), fluidTile);
                    y++;

                }
                x++;
                y = roomStartY;
            }
        }

        roomArea = 0;

        //Generate randomly sized rooms within a range
        while (roomArea <  totalArea/2 ){

            int roomWidth = Random.Range(12, totalWidth)/ 4;
            int roomHeight = Random.Range(12, totalHeight)/ 4;

            roomArea += roomWidth * roomHeight;

            //Generate a random starting postion to add the room on the map
            int roomStartX = Random.Range(1, (totalWidth - (roomWidth + 1)) );
            int roomStartY = Random.Range(1, (totalHeight - (roomHeight + 1)) );

            int x = roomStartX;
            int y = roomStartY;
            for(int i = 0; i < roomWidth; i++){

                for (int j = 0; j <= roomHeight; j++){

                    if (!fluidLevel.HasTile(new Vector3Int(x, y, 0))) {
                        groundLevel.SetTile(new Vector3Int(x, y, 0), groundTile);
                        y++;
                    }
                }
                x++;
                y = roomStartY;
             }

        }
       
        for(int i = 0; i < totalWidth; i++){

            for(int j = 0; j < totalHeight; j++){

                if(!fluidLevel.HasTile(new Vector3Int(i, j, 0)) && !groundLevel.HasTile(new Vector3Int(i, j, 0)))
                {
                    wallLevel.SetTile(new Vector3Int(i, j, 0), wallTile);
                }

            }

        }

    }

    public void clearMap(){

        fluidLevel.ClearAllTiles();
        groundLevel.ClearAllTiles();
        wallLevel.ClearAllTiles();

    }

}