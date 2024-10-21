using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Key;

    //[SerializeField] GameObject Handle1;
    //[SerializeField] GameObject Handle2;

    //private float handleRot1;
    //private float handleRot2;

    private HingeJoint joint;
    private JointLimits limits;
    private Vector3 scalehandle;
    private void Awake()
    {
        joint = Door.GetComponent<HingeJoint>();
        joint.limits = limits;

        //handleRot1 = Handle1.transform.rotation.z;
        //handleRot2 = Handle2.transform.rotation.z;
        //scalehandle = Handle1.transform.localScale;
    }


    public void hingeLimit()  // 열쇠로 열때 
    {
        Debug.Log("문 열림");
        limits.max = 0f;
        limits.min = -120f;

        joint.limits = limits;

        Destroy(Key, 0.5f);
    }
    public void test() 
    {
       
    }

    //public void Handlehinge() //핸들로 열 때 , 부모의 스케일에 영향을 받아서 모양이 이상해짐 , 일단 보류 !
    //{
    //    joint = Door.GetComponent<HingeJoint>();
    //    joint.limits = limits;

    //    if (Handle1.transform.localRotation.eulerAngles.z > 80f)
    //    {
    //        Debug.Log("핸들 다 돌아감");
    //        limits.max = 80f;
    //        limits.min = -80f;
    //        joint.limits = limits;
    //    }
    //    else if (Handle2.transform.localRotation.eulerAngles.z > 80f) 
    //    {
    //        Debug.Log("핸들 다 돌아감");
    //        limits.max = 80f;
    //        limits.min = -80f;

    //        joint.limits = limits;
    //    }
      
    //}
}
