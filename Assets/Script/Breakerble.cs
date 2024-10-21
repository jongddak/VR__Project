using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakerble : MonoBehaviour
{
    [SerializeField] int Breakcount;
    [SerializeField] GameObject Axe;

    private int curCount;
    private Rigidbody rb;

    // 부술 수 있는 오브젝트에 달아주면 됨 
    private void Awake()
    {
        curCount = 0;
        rb = Axe.GetComponent<Rigidbody>();
    }
    private void Update()
    {
      
    }
    private void OnCollisionEnter(Collision collision) // 도끼의 속도를 측정해서 일정속도 이상이여야 카운트가 올라가게 
    {
        
        if (collision.gameObject.name == "Axe") 
        {
            if (rb.velocity.magnitude > 7)
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
