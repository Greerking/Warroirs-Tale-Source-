using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject player1;
    private GameObject acrive_player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf == true)
        {
            acrive_player = player;
        }
        else
        {
            acrive_player = player1;
        }

        transform.position = new Vector3(acrive_player.transform.position.x + offset.x, acrive_player.transform.position.y + offset.y, offset.z); 
        

    }
}
