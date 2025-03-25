using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    float speed = 1f;
    float timeToDisable = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetDisabled());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterControl>().ChangeHp(-1);
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.AddForce(transform.up * 100f, ForceMode2D.Impulse);

        }
    }

    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(timeToDisable);
        gameObject.SetActive(false);
    }

}
