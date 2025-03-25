using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber_script : MonoBehaviour
{
    public GameObject bomb;
    public Transform bombPoint;
    public float timeToBomb = 4f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        bombPoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        StartCoroutine(Bombing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Bombing()
    {
        
        yield return new WaitForSeconds(timeToBomb);
        animator.SetBool("bombing", true);
        Instantiate(bomb, bombPoint.transform.position, transform.rotation);      
        StartCoroutine (Bombing());
        
    }

    private void stopBomb()
    {
        animator.SetBool("bombing", false);
    }

    private void stopAll()
    {
        print("stop");
        gameObject.SetActive(false);
        
    }

}
