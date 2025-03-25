using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber_bat_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform point1;
    public Transform point2;
    int curHp;
    int maxHp = 0;
    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, point1.position.z);
        curHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
