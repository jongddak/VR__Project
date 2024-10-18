using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLock : MonoBehaviour
{


    [SerializeField] GameObject Handle1;
    [SerializeField] GameObject Handle2;

    private float handleRot1;
    private float handleRot2;
    private void Awake()
    {
        handleRot1 = Handle1.transform.rotation.z;
        handleRot2 = Handle2.transform.rotation.z;
    }
}
