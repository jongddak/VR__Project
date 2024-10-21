using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] GameObject flash;

    [SerializeField] float BatteryRemain;

    private bool flashOn;

    private Coroutine flashCoroutine;

    private void Awake()
    {   
        
        BatteryRemain = 87f;
        flashOn = false;
        flash.SetActive(false);    
    }

    public void ChargingBattery() // ���͸� ���� 
    {
        Debug.Log("���͸� ����");
        BatteryRemain = 87f;
    }


    public void Testtri() 
    {
        Debug.Log("Ʈ���� ��Ƽ��");
    }
    public void LightOnoff() 
    {
        // ����Ʈ �¿��� 
        Debug.Log("����Ʈ �¿���");
        if (flashOn == false)
        {
            StartCoroutine("FlashBatteryReduce");
        }
        else if (flashOn == true) 
        {
            StopCoroutine("FlashBatteryReduce");
            flashOn = false;
            flash.SetActive(false);

        }
    }
   

    IEnumerator FlashBatteryReduce() 
    {
        WaitForSeconds time =  new WaitForSeconds(3f);
        flashOn = true;
        flash.SetActive(true);
        
        while (true) 
        {   
            
           
            BatteryRemain -= 1f;
            if (BatteryRemain <= 0f) 
            {
                flashOn = false;
                flash.SetActive(false);
                break;
            }
            yield return time;
        }

    }

}
