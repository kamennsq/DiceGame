using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadLevel : MonoBehaviour
{
    //public GameObject dragons;
    public short side;
    public HeroSO heroSO;
    public MonsterSO monsterSO;
    
    // Start is called before the first frame update
    void Awake()
    {
        var b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate() {LodeLevel();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LodeLevel()
    {
        SceneManager.LoadScene("FightScene");
        heroSO.side = side;
        monsterSO.fightThisMonster();
    }
}
