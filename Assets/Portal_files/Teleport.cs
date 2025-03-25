using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject player1;
    private GameObject acrive_player;
    public Transform teleportPoint;


    private void Start()
    {
        if (player.activeSelf == true)
        {
            acrive_player = player;
        }
        else
            acrive_player = player1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            acrive_player.transform.position = teleportPoint.position;
            
        }
    }
}
