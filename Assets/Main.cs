using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject player1;
    private GameObject acrive_player;
    public Image[] hearts;
    public Sprite isLife, nonLife;
    private int player_hp;


   public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Start()
    {
        if (load_level.charIndex == 1)
        {
            player.SetActive(true);
        }
        else
            player1.SetActive(true);

        if (player.activeSelf == true)
        {
            acrive_player = player;
            player_hp = acrive_player.GetComponent<CharacterControl>().GetLife();
        }
        else
        {
            acrive_player = player1;
            player_hp = acrive_player.GetComponent<CharacterControl>().GetLife();
        }

    }

    public void Update()
    {


        for (int i = 0; i < hearts.Length; i++)
        {      
            if (acrive_player.GetComponent<CharacterControl>().GetLife() > i)
            {
                hearts[i].sprite = isLife;
            }
            else
                hearts[i].sprite = nonLife;
        }

    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        //acrive_player.SetActive(false);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        //acrive_player.SetActive(true);
    }

}
