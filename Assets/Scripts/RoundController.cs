using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private GameEvent throwDiceEvent;

    [SerializeField]
    private GameEvent rerollDiceEvent;

    [SerializeField]
    private DiceController[] playerDices;

    [SerializeField]
    private DiceController[] monsterDices;

    [SerializeField]
    private Text heroHealthLabel;

    [SerializeField]
    private Text monsterHealthLabel;

    [SerializeField]
    private string monsterColor;

    [SerializeField]
    private string winColor;

    [SerializeField]
    private GameObject[] objectsToHide;

    [SerializeField]
    private GameObject[] objectsToShow;

    private int tempHealth;

    private int tempMonsterHealth;

    private int rerollAmount;
    private int tempRerollAmount;

    private int tempHealthM = 0;
    private int tempDamageM = 0;
    private int tempDefenseM = 0;
    public int tempDefenseP = 0;
    private int tempHealthP = 0;
    private int tempDamageP = 0;
    private int tempDamageMultiplier = 1;
    private int tempDefenseMultiplier = 1;
    private int nextRoundDamage = 0;
    private bool monsterIgnoresDefense = false;
    private bool playerIgnoresDefense = false;
    private bool needToStunEnemy = false;

    private bool isGreen1Applied = false;
    private bool isGreen10Applied = false;
    private bool isGreen12Applied = false;
    private bool isBlue12Applied = false;
    private bool isGold7Applied = false;
    private bool isGold8Applied = false;
    private bool isGold12Applied = false;
    private bool isGold11Applied = false;

    private int increaseMaxHealthBy = 0;
    private bool keepDefenseAfterRound = false;
    private bool ignoreAllDefense = false;

    [SerializeField]
    private GameEvent showThirdPlace;

    private bool isFirstRoll;

    [SerializeField]
    private MonsterSO[] monsters;

    private GameObject currentMonster;

    [SerializeField]
    private HeroSO hero;

    // Start is called before the first frame update
    void Start()
    { 
        foreach (MonsterSO monster in monsters)
        {
            if (monster.isThisChosen())
            {
                tempMonsterHealth = monster.getHealth();
                monsterDices[0].setDice(monster.getDiceByIndex(0));
                monsterDices[1].setDice(monster.getDiceByIndex(1));
                monsterColor = monster.getColor();
                currentMonster = Instantiate(monster.getPrefab());
                break;
            }
        }
        tempHealth = hero.getCurrentHealth();
        rerollAmount = 1;
        tempRerollAmount = rerollAmount;
        winColor = monsterColor;
        isFirstRoll = true;
        monsterHealthLabel.text = "Health: " + tempMonsterHealth;
        heroHealthLabel.text = "Health: " + tempHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void throwTheDice()
    {
        throwDiceEvent.Raise();
        GameObject.Find("CountButton").GetComponent<Button>().interactable = true;
        //GameObject.Find("RerollButton").GetComponent<Button>().interactable = true;
        //GameObject.Find("RollButton").GetComponent<Button>().interactable = false;
    }

    public void rerollTheDice()
    {
        if (isFirstRoll)
        {
            isFirstRoll = false;
            throwTheDice();
        }
        else
        {
            if (tempRerollAmount > 0)
            {
                rerollDiceEvent.Raise();
                tempRerollAmount -= 1;
            }
            if (tempRerollAmount <= 0)
            {
                tempRerollAmount = 0;
                //GameObject.Find("RerollButton").GetComponent<Button>().interactable = false;
            }
        }     
    }

    public void calculateValues()
    {
        if (nextRoundDamage > 0)
        {
            tempDamageP += nextRoundDamage;
            nextRoundDamage = 0;
        }
        foreach (DiceController dice in monsterDices)
        {
            if (dice.isSpecial())
            {
                if (!ignoreAllDefense) monsterIgnoresDefense = dice.getSpecialCurrentEdge().isIgnoreEnemyDefense();
                tempHealthM += dice.getSpecialCurrentEdge().getHeal();
                tempDamageM += dice.getSpecialCurrentEdge().getDamage();
                tempDefenseM += dice.getSpecialCurrentEdge().getDefense();
            }
            else
            {
                tempHealthM += dice.getCurrentEdge().getHeal();
                tempDamageM += dice.getCurrentEdge().getDamage();
                tempDefenseM += dice.getCurrentEdge().getDefense();
            }
        }
        foreach (DiceController dice in playerDices)
        {
            if (dice.isChoosen())
            {
                if (dice.isSpecial())
                {
                    if (!ignoreAllDefense) playerIgnoresDefense = dice.getSpecialCurrentEdge().isIgnoreEnemyDefense();
                    tempDefenseMultiplier = dice.getSpecialCurrentEdge().getDefenseMultiplier();
                    tempDamageMultiplier = dice.getSpecialCurrentEdge().getDamageMultiplier();
                    switch (monsterColor)
                    {
                        case "Red": tempDamageP += dice.getSpecialCurrentEdge().getExtraDamageToRed(); break;
                        case "Blue": tempDamageP += dice.getSpecialCurrentEdge().getExtraDamageToBlue(); break;
                        case "Green": tempDamageP += dice.getSpecialCurrentEdge().getExtraDamageToGreen(); break;
                        case "Gold": tempDamageP += dice.getSpecialCurrentEdge().getExtraDamageToGold(); break;
                    }
                    if (dice.getSpecialCurrentEdge().isRandomValues() && !dice.getSpecialCurrentEdge().isPassiveEdge())
                    {
                        tempHealthP += Random.Range(dice.getSpecialCurrentEdge().getRandomHealMin(), dice.getSpecialCurrentEdge().getRandomHealMax() + 1);
                        tempDamageP += Random.Range(dice.getSpecialCurrentEdge().getRandomDamageMin(), dice.getSpecialCurrentEdge().getRandomDamageMax() + 1);
                        tempDefenseP += Random.Range(dice.getSpecialCurrentEdge().getRandomDefenseMin(), dice.getSpecialCurrentEdge().getRandomDefenseMax() + 1);
                    }
                    nextRoundDamage = dice.getSpecialCurrentEdge().getNextRoundDamage();
                    tempHealthP += dice.getSpecialCurrentEdge().getHeal();
                    tempDamageP += dice.getSpecialCurrentEdge().getDamage();
                    tempDefenseP += dice.getSpecialCurrentEdge().getDefense();
                    tempHealthM += dice.getSpecialCurrentEdge().getEnemyHeal();
                    tempDamageM += dice.getSpecialCurrentEdge().getEnemyDamage();
                    tempDefenseM += dice.getSpecialCurrentEdge().getEnemyDefense();
                    needToStunEnemy = dice.getSpecialCurrentEdge().needToStun();
                    if (dice.getSpecialCurrentEdge().isOneTimeBonus())
                    {
                        switch (dice.getSpecialCurrentEdge().getSkillName())
                        {
                            case "green_1": if (!isGreen1Applied) skillGreen_1(); break;
                            case "green_10": if (!isGreen10Applied) skillGreen_10(); break;
                            case "blue_12": if (!isBlue12Applied) skillBlue_12(); break;
                            case "gold_7": if (!isGold7Applied) skillGold_7(); break;
                            case "gold_8": if (!isGold8Applied) skillGold_8(); break;
                            case "gold_12": if (!isGold12Applied) setNewRerollAmount(); break;
                            case "gold_11": if (!isGold11Applied) skillGold_11(); break;
                            case "gold_3": tempHealth = (int)(tempHealth * 0.3f); endBattle(false); break;
                            case "green_12": if (!isGreen12Applied) skillGreen_12(); break;
                        }
                    }
                }
                else
                {
                    tempHealthP += dice.getCurrentEdge().getHeal();
                    tempDamageP += dice.getCurrentEdge().getDamage();
                    tempDefenseP += dice.getCurrentEdge().getDefense();
                }
            }
        }
        if (!needToStunEnemy)
        {
            tempMonsterHealth += tempHealthM;
        }
        
        if (tempMonsterHealth > 20)
        {
            tempMonsterHealth = 20;
        }

        if (playerIgnoresDefense)
        {
            tempDefenseM = 0;
        }
        if (tempDefenseM - tempDamageP * tempDamageMultiplier < 0)
        {
            if (tempDefenseM < 0) tempDefenseM = 0;
            tempMonsterHealth += (tempDefenseM - tempDamageP * tempDamageMultiplier);
        }

        tempHealth += tempHealthP;
        if (tempHealth > hero.getMaxHealth())
        {
            tempHealth = hero.getMaxHealth();
        }

        if (monsterIgnoresDefense && !needToStunEnemy)
        {
            tempDefenseP = 0;
        }
        if (tempDefenseP * tempDefenseMultiplier - tempDamageM < 0 && !needToStunEnemy)
        {
            if (tempDefenseP < 0) tempDefenseM = 0;
            tempHealth += (tempDefenseP * tempDefenseMultiplier - tempDamageM);
        }
        else
        {
            tempDefenseP *= tempDefenseMultiplier;
            tempDefenseP -= tempDamageM;
        }

        monsterHealthLabel.text = "Health: " + tempMonsterHealth;
        heroHealthLabel.text = "Health: " + tempHealth;
        tempRerollAmount = rerollAmount;
        GameObject.Find("CountButton").GetComponent<Button>().interactable = false;
        //GameObject.Find("RerollButton").GetComponent<Button>().interactable = false;
        //GameObject.Find("RollButton").GetComponent<Button>().interactable = true;
        
        foreach (DiceController dice in playerDices)
        {
            dice.returnToStartPosition();
            dice.unblockDice();
        }

        setParametersAsDefault();
        if (tempMonsterHealth <= 0)
        {
            endBattle(true);
        }
        if (tempHealth <= 0)
        {
            endBattle(false);
        }
    }

    public void blockDices(int index)
    {
        switch (index)
        {
            case 1: playerDices[Random.Range(0, 4)].blockDice(); break;
            case 2: blockDices_2(); break;
            case 3: blockDices_3(); break;
        }
    }

    private void setNewRerollAmount()
    {
        isGold12Applied = true;
        rerollAmount++;
    }

    private void increaseTempRerollAmount(int amount)
    {
        tempRerollAmount += amount;
        /*if (!GameObject.Find("RerollButton").GetComponent<Button>().interactable)
        {
            GameObject.Find("RerollButton").GetComponent<Button>().interactable = true;
        }*/
    }

    private void setParametersAsDefault()
    {
        tempHealthM = 0;
        tempDamageM = 0;
        tempDefenseM = 0;
        if (!keepDefenseAfterRound) tempDefenseP = 0;
        tempHealthP = 0;
        tempDamageP = 0;
        tempDamageMultiplier = 1;
        tempDefenseMultiplier = 1;
        if (!ignoreAllDefense) monsterIgnoresDefense = false;
        if (!ignoreAllDefense) playerIgnoresDefense = false;
        needToStunEnemy = false;
        isFirstRoll = true;
}

    public void applyPassiveModificator(string parameter, int value)
    {
        switch (parameter)
        {
            case "DMG": tempDamageP += value; break;
            case "DEF": tempDefenseP += value; break;
            case "HEAL": tempHealthP += value; break;
            case "Reroll": increaseTempRerollAmount(value); break;
        }
        if (tempDefenseP < 0)
        {
            tempDefenseP = 0;
        }
    }

    private void blockDices_2()
    {
        int index_1 = Random.Range(0,4);
        int index_2 = Random.Range(0, 4);
        if (index_2 == index_1)
        {
            do
            {
                index_2 = Random.Range(0, 4);
            }
            while (index_1 == index_2);
        }
        playerDices[index_1].blockDice();
        playerDices[index_2].blockDice();
    }

    private void blockDices_3()
    {
        int index_1 = Random.Range(0, 4);
        int index_2 = Random.Range(0, 4);
        int index_3 = Random.Range(0, 4);
        if (index_2 == index_1)
        {
            do
            {
                index_2 = Random.Range(0, 4);
            }
            while (index_1 == index_2);
        }
        if (index_3 == index_1 || index_3 == index_2)
        {
            do
            {
                index_3 = Random.Range(0, 4);
            }
            while (index_3 == index_1 || index_3 == index_2);
        }
        playerDices[index_1].blockDice();
        playerDices[index_2].blockDice();
    }

    private void skillGreen_1()
    {
        isGreen1Applied = true;
        increaseMaxHealthBy = 8;
    }

    private void skillGreen_12()
    {
        isGreen1Applied = true;
        increaseMaxHealthBy = 2;
    }

    private void skillGreen_10()
    {
        isGreen10Applied = true;
        showThirdPlace.Raise();
    }

    private void skillBlue_12()
    {
        isBlue12Applied = true;
        keepDefenseAfterRound = true;
    }

    private void skillGold_7()
    {
        isGold7Applied = true;
        playerIgnoresDefense = true;
        monsterIgnoresDefense = true;
    }

    private void skillGold_8()
    {
        isGold8Applied = true;
        increaseMaxHealthBy = 1;
    }

    private void skillGold_11()
    {
        isGold11Applied = true;
        tempHealth = 10;
        tempMonsterHealth = 10;
    }

    public void endBattle(bool win)
    {
        if (win)
        {
            foreach (GameObject curObj in objectsToHide)
            {
                curObj.SetActive(false);
            }
            foreach (GameObject curObj in objectsToShow)
            {
                curObj.SetActive(true);
            }
            Destroy(currentMonster);
            gameObject.GetComponent<WinController>().startRewarding(winColor);
            hero.setCurrentHealth(tempHealth);
            hero.setMaxHealth(hero.getMaxHealth() + increaseMaxHealthBy);
        }
        else
        {
            hero.setCurrentHealth(tempHealth);
            hero.setMaxHealth(hero.getMaxHealth() + increaseMaxHealthBy);
            Destroy(currentMonster);
        }
    }
}
