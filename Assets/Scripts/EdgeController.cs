using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dice_1;

    [SerializeField]
    private GameObject[] dice_2;

    [SerializeField]
    private GameObject[] dice_3;

    [SerializeField]
    private GameObject[] dice_4;

    [SerializeField]
    private GameObject[] dice_5;

    [SerializeField]
    private GameObject[] dice_6;

    [SerializeField]
    private DiceSO[] dices;

    [SerializeField]
    private MonsterSO[] monsters;

    // Start is called before the first frame update
    void Start()
    {
        foreach (MonsterSO monster in monsters)
        {
            if (monster.isThisChosen())
            {
                dices[4] = monster.getDiceByIndex(0);
                dices[5] = monster.getDiceByIndex(1);
                break;
            }
        }
        int i = 0;
        foreach (GameObject infoEdge in dice_1)
        {
            if (dices[0].getEdgeByIndex(i).isEdgeSpecial())
            {
                infoEdge.GetComponent<TipEdgeController>().setSpecialCurrentEdge((SpecialEdgeSO)dices[0].getEdgeByIndex(i));
            }
            else
            {
                infoEdge.GetComponent<TipEdgeController>().setCurrentEdge(dices[0].getEdgeByIndex(i));
            }
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_2)
        {
            if (dices[1].getEdgeByIndex(i).isEdgeSpecial())
            {
                infoEdge.GetComponent<TipEdgeController>().setSpecialCurrentEdge((SpecialEdgeSO)dices[1].getEdgeByIndex(i));
            }
            else
            {
                infoEdge.GetComponent<TipEdgeController>().setCurrentEdge(dices[1].getEdgeByIndex(i));
            }
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_3)
        {
            if (dices[2].getEdgeByIndex(i).isEdgeSpecial())
            {
                infoEdge.GetComponent<TipEdgeController>().setSpecialCurrentEdge((SpecialEdgeSO)dices[2].getEdgeByIndex(i));
            }
            else
            {
                infoEdge.GetComponent<TipEdgeController>().setCurrentEdge(dices[2].getEdgeByIndex(i));
            }
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_4)
        {
            if (dices[3].getEdgeByIndex(i).isEdgeSpecial())
            {
                infoEdge.GetComponent<TipEdgeController>().setSpecialCurrentEdge((SpecialEdgeSO)dices[3].getEdgeByIndex(i));
            }
            else
            {
                infoEdge.GetComponent<TipEdgeController>().setCurrentEdge(dices[3].getEdgeByIndex(i));
            }
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_5)
        {
            if (dices[4].getEdgeByIndex(i).isEdgeSpecial())
            {
                infoEdge.GetComponent<TipEdgeController>().setSpecialCurrentEdge((SpecialEdgeSO)dices[4].getEdgeByIndex(i));
            }
            else
            {
                infoEdge.GetComponent<TipEdgeController>().setCurrentEdge(dices[4].getEdgeByIndex(i));
            }
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_6)
        {
            if (dices[5].getEdgeByIndex(i).isEdgeSpecial())
            {
                infoEdge.GetComponent<TipEdgeController>().setSpecialCurrentEdge((SpecialEdgeSO)dices[5].getEdgeByIndex(i));
            }
            else
            {
                infoEdge.GetComponent<TipEdgeController>().setCurrentEdge(dices[5].getEdgeByIndex(i));
            }
            i++;
        }
    }
}
