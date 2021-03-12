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

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (GameObject infoEdge in dice_1)
        {
            infoEdge.GetComponent<SpriteRenderer>().sprite = dices[0].getEdgeByIndex(i).getSprite();
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_2)
        {
            infoEdge.GetComponent<SpriteRenderer>().sprite = dices[1].getEdgeByIndex(i).getSprite();
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_3)
        {
            infoEdge.GetComponent<SpriteRenderer>().sprite = dices[2].getEdgeByIndex(i).getSprite();
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_4)
        {
            infoEdge.GetComponent<SpriteRenderer>().sprite = dices[3].getEdgeByIndex(i).getSprite();
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_5)
        {
            infoEdge.GetComponent<SpriteRenderer>().sprite = dices[4].getEdgeByIndex(i).getSprite();
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_6)
        {
            infoEdge.GetComponent<SpriteRenderer>().sprite = dices[5].getEdgeByIndex(i).getSprite();
            i++;
        }
    }
}
