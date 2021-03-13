using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeButtons : MonoBehaviour
{
    public GameObject[] dragons;
    //public short side=0;
    public PlayerSO playerSO;
    public GameObject blocking;
    public Vector2[] positions = new Vector2[4];
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<4;i++){
            if(playerSO.side==i) {
                Instantiate(blocking, new Vector3(positions[i][0],positions[i][1],0) + transform.position, new Quaternion(), transform);
            } else {
                var o = Instantiate(dragons[Random.Range(0,dragons.Length-1)], new Vector3(positions[i][0],positions[i][1],0) + transform.position, new Quaternion(), transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
