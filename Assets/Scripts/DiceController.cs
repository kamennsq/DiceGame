﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{

    [SerializeField]
    private DiceSO dice;

    [SerializeField]
    private PlaceController place_1;

    [SerializeField]
    private PlaceController place_2;

    [SerializeField]
    private RoundController roundController;

    private int currentPlace;

    private EdgeSO currentEdge;

    private SpecialEdgeSO currentSpecialEdge;

    private Vector3 startPosition;

    private bool isBlocked;

    public Text capture;

    // Start is called before the first frame update
    void Start()
    {
        isBlocked = false;
        currentPlace = 0;
        startPosition = gameObject.transform.position;
        capture.gameObject.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomizeEdge()
    {
        int index = Random.Range(0, 6);
        if (dice.getEdgeByIndex(index).isEdgeSpecial())
        {
            currentSpecialEdge = (SpecialEdgeSO)dice.getEdgeByIndex(index);
            capture.text = currentSpecialEdge.getDescription();
            if (currentSpecialEdge.getNumberOfBlockedDices() > 0)
            {
                roundController.blockDices(currentSpecialEdge.getNumberOfBlockedDices());
            }
            currentEdge = null;
        }
        else
        {
            currentEdge = dice.getEdgeByIndex(index);
            capture.text = "DMG " + currentEdge.getDamage() + "\nDEF " + currentEdge.getDefense() + "\nHEAL " + currentEdge.getHeal();
            currentSpecialEdge = null;
        }
    }

    public void tryToReroll()
    {
        if (!isChoosen())
        {
            randomizeEdge();
        }
    }

    private void OnMouseDown()
    {
        if (!isBlocked)
        {
            if (currentPlace == 0)
            {
                if (place_1.isPlaceEmpty())
                {
                    place_1.changeIsEmptyState();
                    currentPlace = 1;
                    gameObject.transform.position = new Vector3(place_1.gameObject.transform.position.x, place_1.gameObject.transform.position.y, startPosition.z);
                    capture.gameObject.transform.position = gameObject.transform.position;
                }
                else if (place_2.isPlaceEmpty())
                {
                    place_2.changeIsEmptyState();
                    currentPlace = 2;
                    gameObject.transform.position = new Vector3(place_2.gameObject.transform.position.x, place_2.gameObject.transform.position.y, startPosition.z);
                    capture.gameObject.transform.position = gameObject.transform.position;
                }
            }
            else
            {
                returnToStartPosition();
            }
        }
    }

    public bool isChoosen()
    {
        return currentPlace > 0;
    }

    public bool isSpecial()
    {
        return currentSpecialEdge != null;
    }

    public EdgeSO getCurrentEdge()
    {
        return currentEdge;
    }

    public SpecialEdgeSO getSpecialCurrentEdge()
    {
        return currentSpecialEdge;
    }

    public void returnToStartPosition()
    {
        if (currentPlace == 1)
        {
            place_1.changeIsEmptyState();
            currentPlace = 0;
            gameObject.transform.position = startPosition;
            capture.gameObject.transform.position = gameObject.transform.position;
        }
        else
        {
            place_2.changeIsEmptyState();
            currentPlace = 0;
            gameObject.transform.position = startPosition;
            capture.gameObject.transform.position = gameObject.transform.position;
        }
    }

    public void blockDice()
    {
        isBlocked = true;
        if (isChoosen())
        {
            returnToStartPosition();
        }
    }

    public void unblockDice()
    {
        isBlocked = false;
    }

    public bool isDiceBlocked()
    {
        return isBlocked;
    }
}
