using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile SO", menuName = "Tile SO", order = 54)]
public class TileSO : ScriptableObject
{
    [SerializeField]
    private Texture texture;
    
    [SerializeField]
    private List<GameObject> ObjectOnTile;
    
    [SerializeField]
    private List<TileSO> ConnectedTiles;

    public void connectTile(TileSO tile)
    {
        ConnectedTiles.Add(tile);
    } 

    public void disconnectTile(TileSO tile)
    {
        ConnectedTiles.Remove(tile);
    } 
}
