using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakerble : MonoBehaviour
{
    [SerializeField] int Breakcount;
    [SerializeField] GameObject Axe;

    private int curCount;
    private Rigidbody rb;

    private void Awake()
    {
        curCount = 0;
        rb = Axe.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Debug.Log(rb.velocity.magnitude);
    }
    private void OnCollisionEnter(Collision collision) // 도끼의 속도를 측정해서 일정속도 이상이여야 카운트가 올라가게 
    {
        
        if (collision.gameObject.name == "Axe") 
        {
            if (rb.velocity.magnitude > 5)
            {
                curCount++;
                Debug.Log("도끼로 맞음");
            }
        }
        if (curCount >= Breakcount) 
        {
            Destroy(gameObject);
        }
    }
}
