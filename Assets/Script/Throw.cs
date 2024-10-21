using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // ������ �����ӵ� �̻��� �� �΋H���� �Ҹ�����  velocity.magnitude
    [SerializeField] Rigidbody body;
    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject prefab;


    private void OnCollisionEnter(Collision collision)
    {
        if (body.velocity.magnitude > 2f) 
        {
            GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
            // �Ҹ� ��� 
            Debug.Log("�Ҹ����!");
            audioSource.Play();
            Destroy(obj,1f);
            Destroy(gameObject, 3f);
        }
    }
}
