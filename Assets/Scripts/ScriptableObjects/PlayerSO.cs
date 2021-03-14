using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player SO", menuName = "Player SO", order = 55)]
public class PlayerSO : ScriptableObject
{
    public short side;
    public GameObject monster;
    public DiceSO[] dices;
    public int health;
}
