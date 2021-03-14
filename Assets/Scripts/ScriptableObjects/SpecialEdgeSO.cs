using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpecialEdge SO", menuName = "SpecialEgde SO", order = 54)]
public class SpecialEdgeSO : EdgeSO
{
    /*[SerializeField]
    private string description;*/

    [SerializeField]
    private bool ignoreEnemyDefense;

    [SerializeField]
    private int numberOfBlockedDices;

    [SerializeField]
    private int extraDamageToRed;

    [SerializeField]
    private int extraDamageToBlue;

    [SerializeField]
    private int extraDamageToGreen;

    [SerializeField]
    private int extraDamageToGold;

    [SerializeField]
    private int damageMultiplier;

    [SerializeField]
    private int defenseMultiplier;

    [SerializeField]
    private int nextRoundDamageModificator;

    [SerializeField]
    private bool isRandom;

    [SerializeField]
    private int randomDamageMin;

    [SerializeField]
    private int randomDamageMax;

    [SerializeField]
    private int randomHealMin;

    [SerializeField]
    private int randomHealMax;

    [SerializeField]
    private int randomDefenseMin;

    [SerializeField]
    private int randomDefenseMax;

    [SerializeField]
    private bool isPassive;

    [SerializeField]
    private int passiveDefense;

    [SerializeField]
    private int passiveHeal;

    [SerializeField]
    private int passiveDamage;

    [SerializeField]
    private int extraRerolls;

    [SerializeField]
    private bool isOneTime;

    [SerializeField]
    private bool isBuff;

    [SerializeField]
    private int enemyDefense;

    [SerializeField]
    private int enemyDamage;

    [SerializeField]
    private int enemyHeal;

    [SerializeField]
    private bool stunEnemy;

    [SerializeField]
    private string skillName;

    public int getExtraDamageToRed()
    {
        return extraDamageToRed;
    }

    public int getExtraDamageToBlue()
    {
        return extraDamageToBlue;
    }

    public int getExtraDamageToGreen()
    {
        return extraDamageToGreen;
    }

    public int getExtraDamageToGold()
    {
        return extraDamageToGold;
    }

    /*public string getDescription()
    {
        return description;
    }*/

    public bool isIgnoreEnemyDefense()
    {
        return ignoreEnemyDefense;
    }

    public int getNumberOfBlockedDices()
    {
        return numberOfBlockedDices;
    }

    public int getDamageMultiplier()
    {
        return damageMultiplier;
    }

    public int getDefenseMultiplier()
    {
        return defenseMultiplier;
    }

    public bool isRandomValues()
    {
        return isRandom;
    }

    public int getRandomDamageMin()
    {
        return randomDamageMin;
    }

    public int getRandomDamageMax()
    {
        return randomDamageMax;
    }

    public int getRandomHealMin()
    {
        return randomHealMin;
    }

    public int getRandomHealMax()
    {
        return randomHealMax;
    }

    public int getRandomDefenseMin()
    {
        return randomDefenseMin;
    }

    public int getRandomDefenseMax()
    {
        return randomDefenseMax;
    }

    public bool isPassiveEdge()
    {
        return isPassive;
    }

    public int getPassiveDefense()
    {
        return passiveDefense;
    }

    public int getPassiveDamage()
    {
        return passiveDamage;
    }

    public int getPassiveHeal()
    {
        return passiveHeal;
    }

    public int getExtraRerolls()
    {
        return extraRerolls;
    }

    public bool isOneTimeBonus()
    {
        return isOneTime;
    }

    public bool isDoingBuff()
    {
        return isBuff;
    }

    public int getEnemyDamage()
    {
        return enemyDamage;
    }

    public int getEnemyDefense()
    {
        return enemyDefense;
    }

    public int getEnemyHeal()
    {
        return enemyHeal;
    }

    public bool needToStun()
    {
        return stunEnemy;
    }

    public int getNextRoundDamage()
    {
        return nextRoundDamageModificator;
    }

    public string getSkillName()
    {
        return skillName;
    }
}
