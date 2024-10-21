using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    

    private Vector3 curPos;
    private Vector3 Pos;
    private Vector3 velo;

    private void Start()
    {
        transform.position = Pos;
    }
    private void Update()
    {
        curPos = transform.position;
        velo = (curPos - Pos)/Time.deltaTime; 
        Pos = curPos;
        Debug.Log(velo.magnitude);
        if (velo.magnitude >= 0.1f && !AudioSource.isPlaying)
        {
            AudioSource.Play();
            
        }
        else if (velo.magnitude <= 0.09f && AudioSource.isPlaying) 
        {
            AudioSource.Stop();
        }
       




    }
}
