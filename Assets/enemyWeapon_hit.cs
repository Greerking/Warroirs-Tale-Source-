using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeapon_hit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterControl>().ChangeHp(-1);
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.AddForce(transform.right * 10000f);
            print("Hit");


        }
    }

}
