using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_hit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "skeleton_enemy")
        {
            collision.gameObject.GetComponent<SceletonScript>().ChangeHp(-1);
            

        }
        if (collision.gameObject.tag == "bat_enemy")
        {
            collision.gameObject.GetComponent<batScript>().ChangeHp(-1);
            

        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Golem_sctipt>().ChangeHp(-1);


        }       
        if (collision.gameObject.CompareTag("Boss1"))
        {
            collision.gameObject.GetComponent<nb_skript>().ChangeHp(-1);


        }
        if (collision.gameObject.CompareTag("Last_boss"))
        {
            collision.gameObject.GetComponent<Last_boss_script>().ChangeHp(-1);


        }

    }
}
