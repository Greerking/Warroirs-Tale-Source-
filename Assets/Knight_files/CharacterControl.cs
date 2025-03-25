using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject attackHitBox;
    public GameObject player;
    public CapsuleCollider2D capsuleCollider;
    public Transform swordPoint;
    public GameObject swordThrow;
    public float speed;
    public float jumpHeight;
    private float move;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    int curHp;
    int maxHp = 3;
    bool isHit = false;
    public Main main;
    private bool isInvincible = false;
    public bool hasKey = false;


    [SerializeField] private float invincibilityDurationSeconds;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");    
        animator.SetFloat("Speed", Mathf.Abs(move));
        Spin();
        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            if (isGrounded() == false)
            {
                animator.SetBool("Jumping", true);
            }
        }
        if (isGrounded() == true)
        {
            animator.SetBool("Jumping", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Attack", true);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(swordThrow, swordPoint.transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.mass = 500;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            rb.mass = 20;
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        

    }
    void Spin()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    
    private bool isGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        {

            return true;
        }
        else
        {
            animator.SetBool("Jumping", true);
            return false;
        }
    }

    public void ChangeHp(int deltaHp)
    {
        if (isInvincible == true)
            deltaHp = 0;
        else { 
            curHp += deltaHp;
            StartCoroutine(BecomeTemporarilyInvincible());
            animator.SetInteger("Hp", curHp);
            StopCoroutine(BecomeTemporarilyInvincible());

            if (deltaHp < 0)
            {
            
                StopCoroutine(OnHit());
                isHit = true;
                StartCoroutine(OnHit());
            

            }
            //print(curHp);
            if (curHp <= 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                capsuleCollider.enabled = false;
                Invoke("OnFail", 1f);
                Invoke("ResetLevel", 2f);
            }
        }
    }

    IEnumerator OnHit()
    {
        if (isHit)
            spriteRenderer.color = new Color(1f, spriteRenderer.color.g - 0.04f, spriteRenderer.color.b - 0.04f);
        else
            spriteRenderer.color = new Color(1f, spriteRenderer.color.g + 0.02f, spriteRenderer.color.b + 0.02f);
        if (spriteRenderer.color.g == 1f)
            StopCoroutine(OnHit());
        if (spriteRenderer.color.g <= 0)
            isHit = false;
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(OnHit());
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        //print("Player turned invincible!");
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDurationSeconds);

        //print("Player is no longer invincible!");
        ScaleModelTo(Vector3.one);
        isInvincible = false;
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            hasKey = true;
        }
    }



    private void ScaleModelTo(Vector2 scale)
    {
        player.transform.localScale = scale;
    }


    private void ResetLevel()
    {
        main.GetComponent<Main>().RestartLevel();
    }

    private void OnFail()
    {
        animator.enabled = false;
    }

    private void attackHitBoxActive()
    {
        attackHitBox.SetActive(true);
    }

    private void attackHitBoxInactive()
    {
        attackHitBox.SetActive(false);
    }

    private void stopAttack()
    {
        animator.SetBool("Attack", false);
    }

    public int GetLife()
    {
        return curHp;
    }

}
