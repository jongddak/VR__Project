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


    public void hingeLimit()  // ����� ���� 
    {
        Debug.Log("�� ����");
        limits.max = 0f;
        limits.min = -120f;

        joint.limits = limits;

        Destroy(Key, 0.5f);
    }
    public void test() 
    {
       
    }

    //public void Handlehinge() //�ڵ�� �� �� , �θ��� �����Ͽ� ������ �޾Ƽ� ����� �̻����� , �ϴ� ���� !
    //{
    //    joint = Door.GetComponent<HingeJoint>();
    //    joint.limits = limits;

    //    if (Handle1.transform.localRotation.eulerAngles.z > 80f)
    //    {
    //        Debug.Log("�ڵ� �� ���ư�");
    //        limits.max = 80f;
    //        limits.min = -80f;
    //        joint.limits = limits;
    //    }
    //    else if (Handle2.transform.localRotation.eulerAngles.z > 80f) 
    //    {
    //        Debug.Log("�ڵ� �� ���ư�");
    //        limits.max = 80f;
    //        limits.min = -80f;

    //        joint.limits = limits;
    //    }
      
    //}
}
