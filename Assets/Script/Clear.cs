using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clear : MonoBehaviour
{
    public UnityEvent ClearMap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("≈ª√‚!");
            ClearMap?.Invoke();
        }
    }
}
