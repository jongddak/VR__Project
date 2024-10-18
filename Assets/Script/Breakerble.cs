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
    private void OnCollisionEnter(Collision collision) // ������ �ӵ��� �����ؼ� �����ӵ� �̻��̿��� ī��Ʈ�� �ö󰡰� 
    {
        
        if (collision.gameObject.name == "Axe") 
        {
            if (rb.velocity.magnitude > 5)
            {
                curCount++;
                Debug.Log("������ ����");
            }
        }
        if (curCount >= Breakcount) 
        {
            Destroy(gameObject);
        }
    }
}
