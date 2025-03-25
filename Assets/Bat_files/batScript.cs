using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batScript : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 0.5f;
    public float waitTime = 3f;
    bool canMove = true;
    public CapsuleCollider2D batCollider;
    public bool moveLeft = true;
    public Animator animator;
    private bool isAlive = true;
    int curHp;
    int maxHp = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, point1.position.z);
        curHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && isAlive)
        transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);

        if (transform.position == point1.position)
        {
            
            Transform temp = point1;
            point1 = point2;
            point2 = temp;
            canMove = false;
            StartCoroutine(Waiting());
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
            }

        }

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

    public void ChangeHp(int deltaHp)
    {
        curHp += deltaHp;
        animator.SetInteger("Hp", curHp);
        print(curHp);
        if (curHp <= 0)
        {      
            batCollider.enabled = false;
            isAlive = false;

            Invoke("OnFail", 0.8f);
        }

    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
    }

    private void OnFail()
    {
        animator.enabled = false;
        
    }
     private void BatDisable()
    {
        gameObject.SetActive(false);
    }


}
