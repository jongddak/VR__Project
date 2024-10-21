using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // 带廉辑 老沥加档 捞惑老 锭 何婬洒搁 家府唱霸  velocity.magnitude
    [SerializeField] Rigidbody body;
    [SerializeField] AudioSource audioSource;


    private void OnCollisionEnter(Collision collision)
    {
        if (body.velocity.magnitude > 2f) 
        {
            // 家府 犁积 
            Debug.Log("家府犁积!");
            audioSource.Play();
            Destroy(gameObject, 3f);
        }
    }
}
