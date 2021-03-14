using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardEdgeController : MonoBehaviour
{
    private EdgeSO rewardEdge;

    [SerializeField]
    private WinController controller;

    [SerializeField]
    private int index;

    [SerializeField]
    private Text capture;

    [SerializeField]
    private GameObject tipObject;

    [SerializeField]
    private Text tipText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEdge(EdgeSO newEdge)
    {
        rewardEdge = newEdge;
        capture.gameObject.SetActive(true);
        capture.gameObject.transform.position = gameObject.transform.position;
        if (rewardEdge.getDescription().Equals(""))
        {
            capture.text = "DMG " + rewardEdge.getDamage() + "\nDEF " + rewardEdge.getDefense() + "\nHEAL " + rewardEdge.getHeal();
        }
        else 
        { 
            capture.text = rewardEdge.getDescription(); 
        }
        //gameObject.GetComponent<SpriteRenderer>().sprite = rewardEdge.getSprite();
    }

    private void OnMouseDown()
    {
        if (gameObject.transform.name.Contains("Win"))
        {
            controller.setRewardEdge(index);
        }
        else
        {
            controller.setChosenEdge(index);
        }
    }

    public EdgeSO getEdge()
    {
        return rewardEdge;
    }

    private void OnMouseEnter()
    {
        tipObject.SetActive(true);
        tipText.gameObject.SetActive(true);
        tipText.text = rewardEdge.getTipText();
    }

    private void OnMouseExit()
    {
        tipObject.SetActive(false);
        tipText.gameObject.SetActive(false);
    }
}
