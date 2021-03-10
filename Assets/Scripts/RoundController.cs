using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private GameEvent throwDiceEvent;

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
    // Start is called before the first frame update
    void Start()
    {
        tempHealth = 100;
        tempMonsterHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void throwTheDice()
    {
        throwDiceEvent.Raise();
    }

    public void calculateValues()
    {
        int tempHealthM = 0;
        int tempDamageM = 0;
        int tempDefenseM = 0;
        int tempDefenseP = 0;
        int tempHealthP = 0;
        int tempDamageP = 0;
        foreach (DiceController dice in monsterDices)
        {
            tempHealthM += dice.getCurrentEdge().getHeal();
            tempDamageM += dice.getCurrentEdge().getDamage();
            tempDefenseM += dice.getCurrentEdge().getDefense();
        }
        foreach (DiceController dice in playerDices)
        {
            if (dice.isChoosen())
            {
                tempHealthP += dice.getCurrentEdge().getHeal();
                tempDamageP += dice.getCurrentEdge().getDamage();
                tempDefenseP += dice.getCurrentEdge().getDefense();
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

        monsterHealthLabel.text = "Здоровье: " + tempMonsterHealth;
        heroHealthLabel.text = "Здоровье: " + tempHealth;
    }
}
