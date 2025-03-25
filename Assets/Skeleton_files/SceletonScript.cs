using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SceletonScript : MonoBehaviour
{
    public float speed;
    public GameObject weaponHitBox;
    public CapsuleCollider2D skeleCapsuleCollider;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool moveRight = true;
    public Transform groundDetect;
    public Transform playerDetect;
    
    int curHp;
    int maxHp = 0;
    private bool isAlive;
    private bool notAttacking;
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

        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetect.position, Vector2.right, 0.05f);

        if (playerInfo.collider == true)
        {
            attack();
        }

        else
        {
            stopAttack();
            weaponNotActive();
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
            skeleCapsuleCollider.enabled = false;
            isAlive = false;

            Invoke("OnFail", 1.3f);
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
