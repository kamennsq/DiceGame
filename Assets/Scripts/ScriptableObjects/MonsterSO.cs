using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster SO", menuName = "Monster SO", order = 51)]
public class MonsterSO : ScriptableObject
{
    [SerializeField]
    private int health;

    [SerializeField]
    private DiceSO[] dices;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private bool isChosen;

    [SerializeField]
    private string color;

    public int getHealth()
    {
        return health;
    }

    public GameObject getPrefab()
    {
        return prefab;
    }

    public DiceSO[] getDices()
    {
        return dices;
    }

    public DiceSO getDiceByIndex(int index)
    {
        if (index >= 0 && index < 2)
        {
            return dices[index];
        }
        else
        {
            return dices[0];
        }
    }

    public void fightThisMonster()
    {
        isChosen = true;
    }

    public void changeChoose()
    {
        isChosen = false;
    }

    public bool isThisChosen()
    {
        return isChosen;
    }

    public string getColor()
    {
        return color;
    }
}
