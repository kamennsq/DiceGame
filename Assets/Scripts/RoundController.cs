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

    private int tempHealth;

    private int tempMonsterHealth;

    private int rerollAmount;
    // Start is called before the first frame update
    void Start()
    {
        tempHealth = 100;
        tempMonsterHealth = 20;
        rerollAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void throwTheDice()
    {
        throwDiceEvent.Raise();
        GameObject.Find("CountButton").GetComponent<Button>().interactable = true;
        GameObject.Find("RerollButton").GetComponent<Button>().interactable = true;
        GameObject.Find("RollButton").GetComponent<Button>().interactable = false;
    }

    public void rerollTheDice()
    {
        if (rerollAmount > 0)
        {
            rerollDiceEvent.Raise();
            rerollAmount -= 1;
        }
        if (rerollAmount <= 0)
        {
            rerollAmount = 0;
            GameObject.Find("RerollButton").GetComponent<Button>().interactable = false;
        }
    }

    public void calculateValues()
    {
        int tempHealthM = 0;
        int tempDamageM = 0;
        int tempDefenseM = 0;
        int tempDefenseP = 0;
        int tempHealthP = 0;
        int tempDamageP = 0;
        bool monsterIgnoresDefense = false;
        foreach (DiceController dice in monsterDices)
        {
            if (dice.isSpecial())
            {
                monsterIgnoresDefense = dice.getSpecialCurrentEdge().isIgnoreEnemyDefense();
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

                }
                else
                {
                    tempHealthP += dice.getCurrentEdge().getHeal();
                    tempDamageP += dice.getCurrentEdge().getDamage();
                    tempDefenseP += dice.getCurrentEdge().getDefense();
                }
            }
        }

        if (tempDefenseM - tempDamageP < 0)
        {
            tempMonsterHealth += (tempDefenseM - tempDamageP) + tempHealthM;
        }
        else
        {
            tempMonsterHealth += tempHealthM;
        }

        if (tempMonsterHealth > 20)
        {
            tempMonsterHealth = 20;
        }

        if (monsterIgnoresDefense)
        {
            tempDefenseP = 0;
        }
        if (tempDefenseP - tempDamageM < 0)
        {
            tempHealth += (tempDefenseP - tempDamageM) + tempHealthP;
        }
        else
        {
            tempHealth += tempHealthP;
        }

        if (tempHealth > 100)
        {
            tempHealth = 100;
        }

        monsterHealthLabel.text = "Health: " + tempMonsterHealth;
        heroHealthLabel.text = "Health: " + tempHealth;
        rerollAmount = 1;
        GameObject.Find("CountButton").GetComponent<Button>().interactable = false;
        GameObject.Find("RerollButton").GetComponent<Button>().interactable = false;
        GameObject.Find("RollButton").GetComponent<Button>().interactable = true;
        
        foreach (DiceController dice in playerDices)
        {
            dice.returnToStartPosition();
            dice.unblockDice();
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
}
