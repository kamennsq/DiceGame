using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapGen : MonoBehaviour
{
    //public Texture emptyButton;
    public int[] mapSize = new int[2]{10,10};
    
    //public TileSO[] tileTypes;
    //no idea why
    
    public Tile[] tile;
    public Tile[] tileTypes;
    public Sprite[] sprite;
    public Tilemap tilemap;
    
/*
    public struct Tile {
        Texture texture;
        List<Tile> ConnectedTiles;
        GameObject GO;
        public Tile(int j, int k) {
            texture
        }
    };
*/
    //public Tile[][] tiles;
    
    void Awake()
    {
        GenerateMap();
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenerateMap()
    {
        //tiles = new Tile[10][10];//[mapSize[0]][mapSize[1]];
       /* 
        for(int j=0; j<mapSize[0];j++) {
            for(int k=0; k<mapSize[1];k++) {
                tiles[j][k] = Instantiate
            }
        }
        */
        /*
        for(int j=0;j<mapSize[0];j++) {
            for(int k=0;k<mapSize[1];k++) {
                tilemap.SetTile(new Vector3Int(j,k,0), );//tileTypes[Random.Range(0,tileTypes.Length)]);
            }
        }
        */
        
    }

/*
    void OnGUI()
    {
        for(int j=0; j<mapSize[0];j++) {
            for(int k=0; k<mapSize[1];k++) {
                GUI.Button(new Rect(k*100,j*100,100,100),emptyButton);
            }
        }
    }
*/
}
