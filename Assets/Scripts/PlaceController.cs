using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceController : MonoBehaviour
{
    private bool isEmpty;
    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isPlaceEmpty()
    {
        return isEmpty;
    }

    public void changeIsEmptyState()
    {
        isEmpty = !isEmpty;
    }
}
