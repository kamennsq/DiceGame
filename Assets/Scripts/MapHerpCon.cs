using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapHerpCon : MonoBehaviour
{
    public NewControls input;
    public Tilemap tilemap;
    public Vector3Int pos = new Vector3Int(0,0,0);
    public TileBase undpt;
    public Tile way;
    public int tilesize = 3;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //pos += new Vector3Int((int)(0));
        transform.position = pos;
        undpt = tilemap.GetTile(pos);
        TileBase adjt;
        adjt = tilemap.GetTile(pos+ new Vector3Int(1,0,0));
        if(adjt != null) {
            //print(adjt);
        }
    }
}
