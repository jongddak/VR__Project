using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    public UnityEvent OngetBattery;

    public void getBattery() 
    {
        // ���͸��� ȹ���ϸ� ������ ����

        Debug.Log("���͸� ȹ��!");

        OngetBattery?.Invoke();

        Destroy(gameObject, 0.2f);

    }
}
