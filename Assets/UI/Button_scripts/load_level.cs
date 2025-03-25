using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_level : MonoBehaviour
{
    public GameObject player;
    public GameObject player1;
    private GameObject selected_player;
    public static int charIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf == true)
        {
            selected_player = player;
        }
        else
            selected_player = player1;


    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ConfirmCharChoice()
    {
        GameObject selectedCheck = selected_player.transform.GetChild(0).gameObject;
        selectedCheck.SetActive(true);
            
    }

    public void SelectChar()
    {
        if (player.activeSelf == true)
        {
            charIndex = 0;
        }
        else
            charIndex = 1;
    }

}
