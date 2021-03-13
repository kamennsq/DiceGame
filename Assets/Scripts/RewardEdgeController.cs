using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardEdgeController : MonoBehaviour
{
    private EdgeSO rewardEdge;

    [SerializeField]
    private WinController controller;

    [SerializeField]
    private int index;

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
        gameObject.GetComponent<SpriteRenderer>().sprite = rewardEdge.getSprite();
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
}
