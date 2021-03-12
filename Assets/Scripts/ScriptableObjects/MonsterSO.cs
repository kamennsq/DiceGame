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
}
