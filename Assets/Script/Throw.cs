using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // ������ �����ӵ� �̻��� �� �΋H���� �Ҹ�����  velocity.magnitude
    [SerializeField] Rigidbody body;
    [SerializeField] AudioSource audioSource;


    private void OnCollisionEnter(Collision collision)
    {
        if (body.velocity.magnitude > 2f) 
        {
            // �Ҹ� ��� 
            Debug.Log("�Ҹ����!");
            audioSource.Play();
            Destroy(gameObject, 3f);
        }
    }
}
