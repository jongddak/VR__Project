using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    public UnityEvent OngetBattery;

    public void getBattery() 
    {
        // 배터리를 획득하면 손전등 충전

        Debug.Log("배터리 획득!");

        OngetBattery?.Invoke();

        Destroy(gameObject, 0.2f);

    }
}
