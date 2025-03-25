using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_throw : MonoBehaviour
{
    float speed = 1f;
    float timeToDisable = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetDisabled());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bat_enemy")
        {
            collision.gameObject.GetComponent<batScript>().ChangeHp(-1);
        }

        Destroy(gameObject);


    }

    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(timeToDisable);
        gameObject.SetActive(false);
    }

}
