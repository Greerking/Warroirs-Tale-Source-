using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Golem_sctipt : MonoBehaviour
{
    public Transform groundDetect;
    public Transform playerDetect;
    public Transform playerDetectFar;
    public Transform bombPoint;
    public Animator animator;
    public CapsuleCollider2D capsuleCollider;
    public GameObject weaponHitBox;
    public GameObject bomb;
    public bool moveRight = true;
    public bool isAlive;
    private bool notAttacking;
    public float speed;
    public float timeToBomb = 5f;
    int curHp;
    int maxHp = 20;
    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
        isAlive = true;
        notAttacking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && notAttacking)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 0.1f);

        if (groundInfo.collider == false)
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetect.position, Vector2.right, 0.08f);

        if (playerInfo.collider == true)
        {
            attack();
        }

        RaycastHit2D playerInfoFar = Physics2D.Raycast(playerDetectFar.position, Vector2.right, 5f);
        

        if (playerInfoFar.collider == true && isAlive)
        {
            animator.SetBool("seePlayerFar", true);
            rangeAttack();
        }

        else
        {
            animator.SetBool("seePlayerFar", false);
            
            
        }



    }
    public void ChangeHp(int deltaHp)
    {
        curHp += deltaHp;
        animator.SetInteger("Hp", curHp);
        print(curHp);
        if (curHp <= 0)
        {
            animator.SetBool("Alive", false);
            capsuleCollider.enabled = false;
            isAlive = false;

            Invoke("OnFail", 1.5f);
        }

    }


    private void rangeAttack()
    {
        timeToBomb -= Time.deltaTime;
        if (timeToBomb < 0.0f) 
        {
            Instantiate(bomb, bombPoint.transform.position, transform.rotation);
            timeToBomb = 3f;
        }
            
        
        
    }


    private void OnFail()
    {
        animator.enabled = false;
    }

    private void attack()
    {
        animator.SetBool("Alive", false);
        animator.SetBool("seePlayer", true);
        notAttacking = false;

    }

    private void stopAttack()
    {
        animator.SetBool("seePlayer", false);
        animator.SetBool("Alive", true);
        notAttacking = true;
    }

    private void weaponActive()
    {
        weaponHitBox.SetActive(true);
    }

    private void weaponNotActive()
    {
        weaponHitBox.SetActive(false);
    }
}
