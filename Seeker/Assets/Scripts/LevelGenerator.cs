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
        //Generate randomly sized rooms within a range
        while (roomArea < (.66 * totalArea) ){

            int roomWidth = Random.Range(6, totalWidth)/ 2;
            int roomHeight = Random.Range(6, totalHeight)/ 2;

            roomArea += roomWidth * roomHeight;

            //Generate a random starting postion to add the room on the map
            int roomStartX = Random.Range(1, (totalWidth - (roomWidth + 1)) );
            int roomStartY = Random.Range(1, (totalHeight - (roomHeight + 1)) );

            int x = roomStartX;
            int y = roomStartY;
            for(int i = 0; i < roomWidth; i++){

                for (int j = 0; j <= roomHeight; j++){

                    groundLevel.SetTile(new Vector3Int(x, y, 0), groundTile);
                    y++;
                }
                x++;
                y = roomStartY;
             }

        }
    }

    public void clearMap(){

        fluidLevel.ClearAllTiles();
        groundLevel.ClearAllTiles();
        wallLevel.ClearAllTiles();

    }

}
