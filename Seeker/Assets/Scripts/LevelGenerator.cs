using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{

    private Vector3Int tilemapSize;
    private Tilemap fluidLevel;
    private Tile fluidTile;
    private Tilemap groundLevel;
    private Tile groundTile;
    private Tilemap wallLevel;
    private Tile wallTile;

    int width;
    int height;

    public void generateLevel(){



    }

    public void clearMap(){

        fluidLevel.ClearAllTiles();
        groundLevel.ClearAllTiles();
        wallLevel.ClearAllTiles();

    }

}
