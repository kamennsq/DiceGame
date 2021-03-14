using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipEdgeController : MonoBehaviour
{
    private EdgeSO currentEdge;

    private SpecialEdgeSO currentSpecialEdge;

    [SerializeField]
    private GameObject tipObject;

    [SerializeField]
    private Text tipText;

    [SerializeField]
    private Text capture;

    // Start is called before the first frame update
    void Start()
    {
        capture.gameObject.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (currentEdge != null || currentSpecialEdge != null)
        {
            tipObject.SetActive(true);
            tipText.gameObject.SetActive(true);
            if (currentSpecialEdge != null)
            {
                tipText.text = currentSpecialEdge.getTipText();
            }
            else
            {
                tipText.text = currentEdge.getTipText();
            }
        }
    }

    private void OnMouseExit()
    {
        tipObject.SetActive(false);
        tipText.gameObject.SetActive(false);
    }

    public void setCurrentEdge(EdgeSO newEdge)
    {
        currentEdge = newEdge;
        capture.text = "DMG " + currentEdge.getDamage() + "\nDEF " + currentEdge.getDefense() + "\nHEAL " + currentEdge.getHeal();
    }

    public void setSpecialCurrentEdge(SpecialEdgeSO newEdge)
    {
        currentSpecialEdge = newEdge;
        capture.text = currentSpecialEdge.getDescription();
    }
}
