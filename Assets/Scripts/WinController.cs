using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
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
    private GameObject[] rewards;

    [SerializeField]
    private DiceSO[] playerDices;

    [SerializeField]
    private EdgeSO[] redReward;

    [SerializeField]
    private EdgeSO[] blueReward;

    [SerializeField]
    private EdgeSO[] greenReward;

    [SerializeField]
    private EdgeSO[] goldReward;

    [SerializeField]
    private GameObject acceptButton;

    private int chosenReward = -1;

    private int chosenEdge = -1;

    public void startRewarding(string color)
    {
        int i = 0;
        foreach (GameObject infoEdge in dice_1)
        {
            //infoEdge.GetComponent<SpriteRenderer>().sprite = playerDices[0].getEdgeByIndex(i).getSprite();
            infoEdge.GetComponent<RewardEdgeController>().setEdge(playerDices[0].getEdgeByIndex(i));
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_2)
        {
            //infoEdge.GetComponent<SpriteRenderer>().sprite = playerDices[1].getEdgeByIndex(i).getSprite();
            infoEdge.GetComponent<RewardEdgeController>().setEdge(playerDices[1].getEdgeByIndex(i));
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_3)
        {
            //infoEdge.GetComponent<SpriteRenderer>().sprite = playerDices[2].getEdgeByIndex(i).getSprite();
            infoEdge.GetComponent<RewardEdgeController>().setEdge(playerDices[2].getEdgeByIndex(i));
            i++;
        }
        i = 0;

        foreach (GameObject infoEdge in dice_4)
        {
            //infoEdge.GetComponent<SpriteRenderer>().sprite = playerDices[3].getEdgeByIndex(i).getSprite();
            infoEdge.GetComponent<RewardEdgeController>().setEdge(playerDices[3].getEdgeByIndex(i));
            i++;
        }

        showReward(color);
    }

    private void showReward(string rewardColor)
    {
        int index_1;
        int index_2;
        int index_3;
        switch (rewardColor)
        {
            case "Red":
                index_1 = Random.Range(0, redReward.Length);
                index_2 = Random.Range(0, redReward.Length);
                index_3 = Random.Range(0, redReward.Length);
                if (index_2 == index_1)
                {
                    do
                    {
                        index_2 = Random.Range(0, redReward.Length);
                    }
                    while (index_1 == index_2);
                }
                if (index_3 == index_1 || index_3 == index_2)
                {
                    do
                    {
                        index_3 = Random.Range(0, redReward.Length);
                    }
                    while (index_3 == index_1 || index_3 == index_2);
                }
                rewards[0].GetComponent<RewardEdgeController>().setEdge(redReward[index_1]);
                rewards[1].GetComponent<RewardEdgeController>().setEdge(redReward[index_2]);
                rewards[2].GetComponent<RewardEdgeController>().setEdge(redReward[index_3]);
                break;
            case "Blue":
                index_1 = Random.Range(0, blueReward.Length);
                index_2 = Random.Range(0, blueReward.Length);
                index_3 = Random.Range(0, blueReward.Length);
                if (index_2 == index_1)
                {
                    do
                    {
                        index_2 = Random.Range(0, blueReward.Length);
                    }
                    while (index_1 == index_2);
                }
                if (index_3 == index_1 || index_3 == index_2)
                {
                    do
                    {
                        index_3 = Random.Range(0, blueReward.Length);
                    }
                    while (index_3 == index_1 || index_3 == index_2);
                }
                rewards[0].GetComponent<RewardEdgeController>().setEdge(blueReward[index_1]);
                rewards[1].GetComponent<RewardEdgeController>().setEdge(blueReward[index_2]);
                rewards[2].GetComponent<RewardEdgeController>().setEdge(blueReward[index_3]);
                break;
            case "Green":
                index_1 = Random.Range(0, greenReward.Length);
                index_2 = Random.Range(0, greenReward.Length);
                index_3 = Random.Range(0, greenReward.Length);
                if (index_2 == index_1)
                {
                    do
                    {
                        index_2 = Random.Range(0, greenReward.Length);
                    }
                    while (index_1 == index_2);
                }
                if (index_3 == index_1 || index_3 == index_2)
                {
                    do
                    {
                        index_3 = Random.Range(0, greenReward.Length);
                    }
                    while (index_3 == index_1 || index_3 == index_2);
                }
                rewards[0].GetComponent<RewardEdgeController>().setEdge(greenReward[index_1]);
                rewards[1].GetComponent<RewardEdgeController>().setEdge(greenReward[index_2]);
                rewards[2].GetComponent<RewardEdgeController>().setEdge(greenReward[index_3]);
                break;
            case "Gold":
                index_1 = Random.Range(0, goldReward.Length);
                index_2 = Random.Range(0, goldReward.Length);
                index_3 = Random.Range(0, goldReward.Length);
                if (index_2 == index_1)
                {
                    do
                    {
                        index_2 = Random.Range(0, goldReward.Length);
                    }
                    while (index_1 == index_2);
                }
                if (index_3 == index_1 || index_3 == index_2)
                {
                    do
                    {
                        index_3 = Random.Range(0, goldReward.Length);
                    }
                    while (index_3 == index_1 || index_3 == index_2);
                }
                rewards[0].GetComponent<RewardEdgeController>().setEdge(goldReward[index_1]);
                rewards[1].GetComponent<RewardEdgeController>().setEdge(goldReward[index_2]);
                rewards[2].GetComponent<RewardEdgeController>().setEdge(goldReward[index_3]);
                break;
        }
    }

    public void setChosenEdge(int index)
    {
        chosenEdge = index;
        if (chosenReward > -1)
        {
            acceptButton.GetComponent<Button>().interactable = true;
        }
    }

    public void setRewardEdge(int index)
    {
        chosenReward = index;
        foreach (GameObject reward in rewards)
        {
            reward.GetComponent<SpriteRenderer>().color = Color.grey;
        }
        rewards[index].GetComponent<SpriteRenderer>().color = Color.white;
        if (chosenEdge > -1)
        {
            acceptButton.GetComponent<Button>().interactable = true;
        }
    }

    public void getReward()
    {
        switch (chosenEdge)
        {
            case 0: playerDices[0].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 0); break;
            case 1: playerDices[0].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 1); break;
            case 2: playerDices[0].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 2); break;
            case 3: playerDices[0].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 3); break;
            case 4: playerDices[0].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 4); break;
            case 5: playerDices[0].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 5); break;
            case 6: playerDices[1].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 0); break;
            case 7: playerDices[1].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 1); break;
            case 8: playerDices[1].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 2); break;
            case 9: playerDices[1].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 3); break;
            case 10: playerDices[1].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 4); break;
            case 11: playerDices[1].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 5); break;
            case 12: playerDices[2].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 0); break;
            case 13: playerDices[2].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 1); break;
            case 14: playerDices[2].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 2); break;
            case 15: playerDices[2].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 3); break;
            case 16: playerDices[2].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 4); break;
            case 17: playerDices[2].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 5); break;
            case 18: playerDices[3].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 0); break;
            case 19: playerDices[3].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 1); break;
            case 20: playerDices[3].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 2); break;
            case 21: playerDices[3].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 3); break;
            case 22: playerDices[3].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 4); break;
            case 23: playerDices[3].replaceEdgeByIndex(rewards[chosenReward].GetComponent<RewardEdgeController>().getEdge(), 5); break;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
