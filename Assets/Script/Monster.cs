using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] BoxCollider boxcollider;
    [SerializeField] Animator animator;

    private void Update()
    {
        
    }


    public void Trace() 
    {
        Debug.Log("추적시작!");
    }

}
