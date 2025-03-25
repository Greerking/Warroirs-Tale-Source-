using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class change_hp : MonoBehaviour
{
    public int curHp;
    public GameObject boss;
    public Animator animator;
    public CapsuleCollider2D capsuleCollider;
    public void ChangeHp(int deltaHp)
    {
        curHp += deltaHp;
        animator.SetInteger("Hp", curHp);
        print(curHp);
        if (curHp <= 0)
        {
            animator.SetBool("Alive", false);
            capsuleCollider.enabled = false;
            

            Invoke("OnFail", 1.5f);
        }

    }
}
