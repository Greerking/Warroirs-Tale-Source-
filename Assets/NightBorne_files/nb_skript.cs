using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nb_skript : MonoBehaviour
{
    public Transform groundDetect;
    public Transform playerDetect;
    public GameObject playerPosition;
    public GameObject playerPosition1;
    private Transform active_player_pos;
    public Animator animator;
    public CapsuleCollider2D capsuleCollider;
    public GameObject weaponHitBox;
    public bool moveRight = true;
    public bool isAlive;
    private bool notAttacking;
    public float speed;
    int curHp;
    int maxHp = 10;
    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
        isAlive = true;
        notAttacking = true;
        if (playerPosition.activeSelf == true)
        {
            active_player_pos = playerPosition.transform;
        }
        else
            active_player_pos = playerPosition1.transform;



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





    }
    public void ChangeHp(int deltaHp)
    {
        curHp += deltaHp;
        animator.SetInteger("Hp", curHp);
        if (active_player_pos.rotation.y == 0)        {
            gameObject.transform.position = new Vector3(active_player_pos.position.x - 0.3f, gameObject.transform.position.y);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(active_player_pos.position.x + 0.3f, gameObject.transform.position.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        print(curHp);

        if (curHp <= 0)
        {
            animator.SetBool("Alive", false);           
            capsuleCollider.enabled = false;
            isAlive = false;

            
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
