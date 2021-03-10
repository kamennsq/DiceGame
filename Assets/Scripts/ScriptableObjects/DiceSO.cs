using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dice SO", menuName = "Dice SO", order = 52)]
public class DiceSO : ScriptableObject
{
    [SerializeField]
    private EdgeSO[] edges;

    public EdgeSO[] getEdges()
    {
        return edges;
    }

    public EdgeSO getEdgeByIndex(int index)
    {
        if (index >= 0 && index < 6)
        {
            return edges[index];
        }
        else
        {
            return edges[0];
        }
    }
}
