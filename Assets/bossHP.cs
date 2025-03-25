using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHP : MonoBehaviour
{
    public GameObject lastBoss;
    public Image[] hearts;
    public Sprite isLife, nonLife;
    private int boss_hp;
    // Start is called before the first frame update
    void Start()
    {
        boss_hp = lastBoss.GetComponent<Last_boss_script>().GetHp();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (lastBoss.GetComponent<Last_boss_script>().GetHp() > i)
            {
                hearts[i].sprite = isLife;
            }
            else
                hearts[i].sprite = nonLife;
        }
    }
}
