using System.Collections;
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

    private int currentPlace;

    private EdgeSO currentEdge;

    private Vector3 startPosition;

    public Text capture;

    // Start is called before the first frame update
    void Start()
    {
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
        currentEdge = dice.getEdgeByIndex(Random.Range(0, 6));
        capture.text = "АТК " + currentEdge.getDamage() + "\nЗАЩ " + currentEdge.getDefense() + "\nХИЛ " + currentEdge.getHeal();
    }

    private void OnMouseDown()
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
    }

    public bool isChoosen()
    {
        return currentPlace > 0;
    }

    public EdgeSO getCurrentEdge()
    {
        return currentEdge;
    }
}
