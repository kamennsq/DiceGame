using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeButtons : MonoBehaviour
{
    public GameObject[] lv1;
    public GameObject[] lv2;
    public GameObject[] lv3;
    public GameObject[] boss;
    //public short side=0;
    public HeroSO heroSO;
    public GameObject blocking;
    public Vector2[] positions = new Vector2[4];
    
    // Start is called before the first frame update
    void Start()
    {
        for(short i=0;i<4;i++){
            if(heroSO.side==i) {
                Instantiate(blocking, new Vector3(positions[i][0],positions[i][1],0) + transform.position, new Quaternion(), transform);
            } else {
                GameObject o = null;
                if(heroSO.lvl==1)
                    o = Instantiate(lv1[Random.Range(0,lv1.Length)], new Vector3(positions[i][0],positions[i][1],0) + transform.position, new Quaternion(), transform);
                if(heroSO.lvl==2)
                    o = Instantiate(lv2[Random.Range(0,lv2.Length)], new Vector3(positions[i][0],positions[i][1],0) + transform.position, new Quaternion(), transform);
                if(heroSO.lvl==3)
                    o = Instantiate(lv3[Random.Range(0,lv3.Length)], new Vector3(positions[i][0],positions[i][1],0) + transform.position, new Quaternion(), transform);
                //if(heroSO.lvl==4)
                //    var o = Instantiate(boss[Random.Range(0,boss.Length-1)], new Vector3(positions[i][0],positions[i][1],0) + transform.position, new Quaternion(), transform);
                else continue;
                short s=0;
                if(i==0) s=2;
                if(i==1) s=3;
                if(i==2) s=0;
                if(i==3) s=1;
                o.GetComponent<LoadLevel>().side=s;
                o.GetComponent<LoadLevel>().heroSO = heroSO;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
