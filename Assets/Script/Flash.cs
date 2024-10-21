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

    public void ChargingBattery() // 배터리 충전 
    {
        Debug.Log("배터리 충전");
        BatteryRemain = 87f;
    }


    public void Testtri() 
    {
        Debug.Log("트리거 액티브");
    }
    public void LightOnoff() 
    {
        // 라이트 온오프 
        Debug.Log("라이트 온오프");
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
