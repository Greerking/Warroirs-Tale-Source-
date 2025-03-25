using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_switch : MonoBehaviour
{
    public GameObject golemBoss;
    public bool bossDefeated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (golemBoss.GetComponent<Golem_sctipt>().isAlive == false) 
        {         
            bossDefeated = true;
        }
        
    }


}

