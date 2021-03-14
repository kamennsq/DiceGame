using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero SO", menuName = "Hero SO", order = 55)]
public class HeroSO : ScriptableObject
{
    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private DiceSO[] dices;

    [SerializeField]
    private int dragonKiller_1;

    [SerializeField]
    private int dragonKiller_2;

    [SerializeField]
    private int dragonKiller_3;

    [SerializeField]
    private int dragonKiller_boss;

    [SerializeField]
    private int redDragonKiller;

    [SerializeField]
    private int blueDragonKiller;

    [SerializeField]
    private int greenDragonKiller;
    
    public short side = 0;
    
    public int lvl = 1;

    public void setCurrentHealth(int health)
    {
        currentHealth = health;
    }

    public void setMaxHealth(int health)
    {
        maxHealth = health;
    }

    public void increaseDragonKiller_1()
    {
        dragonKiller_1++;
    }

    public void increaseDragonKiller_2()
    {
        dragonKiller_2++;
    }

    public void increaseDragonKiller_3()
    {
        dragonKiller_3++;
    }

    public void increaseDragonKiller_boss()
    {
        dragonKiller_boss++;
    }

    public void increaseRedDragonKiller()
    {
        redDragonKiller++;
    }

    public void increaseBlueDragonKiller()
    {
        blueDragonKiller++;
    }

    public void increaseGreenDragonKiller()
    {
        greenDragonKiller++;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getDragonKiller_1()
    {
        return dragonKiller_1;
    }

    public int getDragonKiller_2()
    {
        return dragonKiller_2;
    }

    public int getDragonKiller_3()
    {
        return dragonKiller_3;
    }

    public int getDragonKiller_boss()
    {
        return dragonKiller_boss;
    }

    public int getRedDragonKiller()
    {
        return redDragonKiller;
    }

    public int getBlueDragonKiller()
    {
        return blueDragonKiller;
    }

    public int getGreenDragonKiller()
    {
        return greenDragonKiller;
    }
}
