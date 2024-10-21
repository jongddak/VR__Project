using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    [SerializeField] GameObject prefap;
    

    private Vector3 curPos;
    private Vector3 Pos;
    private Vector3 velo;

    private void Start()
    {
        Pos = transform.position;   
    }
    private void Update()
    {
        curPos = transform.position;
        velo = (curPos - Pos)/Time.deltaTime; 
        Pos = curPos;
        
        if (velo.magnitude >= 0.1f && !AudioSource.isPlaying)
        {
            AudioSource.Play();
            StartCoroutine("createSoundobj");
            
        }
        else if (velo.magnitude <= 0.09f && AudioSource.isPlaying) 
        {
            StopCoroutine("createSoundobj");
            AudioSource.Stop();
        }

    }

    IEnumerator createSoundobj() 
    {
        WaitForSeconds time = new WaitForSeconds(0.5f);

        while (true) 
        {
            yield return time;

            Instantiate(prefap, curPos, transform.rotation);
        }
    }
}
