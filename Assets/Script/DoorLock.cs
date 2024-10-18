using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] GameObject Door;

    [SerializeField] GameObject Handle1;
    [SerializeField] GameObject Handle2;

    private float handleRot1;
    private float handleRot2;

    private HingeJoint joint;
    private JointLimits limits;
    private Vector3 scalehandle;
    private void Awake()
    {
        joint = Door.GetComponent<HingeJoint>();
        joint.limits = limits;

        handleRot1 = Handle1.transform.rotation.z;
        handleRot2 = Handle2.transform.rotation.z;
        scalehandle = Handle1.transform.localScale;
    }


    public void hingeLimit()  // 열쇠로 열때 
    {
        
        limits.max = 80f;
        limits.min = -80f;

        joint.limits = limits;
    }
    public void test() 
    {
       
    }

    public void Handlehinge() //핸들로 열 때 
    {
        joint = Door.GetComponent<HingeJoint>();
        joint.limits = limits;

        if (Handle1.transform.localRotation.eulerAngles.z > 80f)
        {
            Debug.Log("핸들 다 돌아감");
            limits.max = 80f;
            limits.min = -80f;
            joint.limits = limits;
        }
        else if (Handle2.transform.localRotation.eulerAngles.z > 80f) 
        {
            Debug.Log("핸들 다 돌아감");
            limits.max = 80f;
            limits.min = -80f;

            joint.limits = limits;
        }
      
    }
}
