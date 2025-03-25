using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_boss_script : MonoBehaviour
{
    public GameObject activePlayer;
    public GameObject playerDetection;
    public GameObject weapon;
    public Animator animator;
    public Rigidbody2D rb;
    public bool isAlive;
    private int curHp = 20;
    
    private float speed;
    private Vector3 currentPos;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        BossMove();
        RaycastHit2D playerDetect = Physics2D.Raycast(playerDetection.transform.position, Vector2.right, 0.1f);
        if (playerDetect.collider == true)
        {
            animator.SetBool("seePlayer", true);
        }
        
            
    }


    private void BossMove()
    {
        currentPos = new Vector3(activePlayer.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
        if (gameObject.transform.position.x - activePlayer.transform.position.x > 0 && curHp !=0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void ChangeHp(int deltaHp)
    {
        curHp += deltaHp;
        animator.SetInteger("Hp", curHp);
        print(curHp);
        if (curHp <= 0)
        {   
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            isAlive = false;

            Invoke("OnFail", 2.5f);
        }

    }
    public int GetHp()
    {
        return curHp;
    }
    private void OnFail()
    {
        animator.enabled = false;
        speed = 0f;
    }
    private void stopAttack()
    {
        animator.SetBool("seePlayer", false);
    }

    private void freeze()
    {
        speed = 0f;
    }

    private void unFreeze()
    {
        speed = 0.2f;
    }

    private void weaponActive()
    {
        weapon.SetActive(true);
    }
    private void weaponInactive()
    {
        weapon.SetActive(false);
    }
}
