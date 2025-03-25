using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterControl>().ChangeHp(-1);
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.AddForce(transform.up * 100f, ForceMode2D.Impulse);
            
        }
    }




}
