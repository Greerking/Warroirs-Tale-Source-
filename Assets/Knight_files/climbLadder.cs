using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbLadder : MonoBehaviour
{
    private float vertical;
    private float speed = 2f;
    private bool isNearLadder;
    private bool isClinmbing;

    [SerializeField] private Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isNearLadder && Mathf.Abs(vertical) > 0f)
        {
            isClinmbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClinmbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector3(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isNearLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isNearLadder = false;
            isClinmbing = false;
        }

    }

}
