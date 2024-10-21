using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Detecting : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] Animator animator;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject mob;

    [SerializeField] Transform[] patrolPoints;
    private Vector3 targetPos;


    public enum State
    {
        Patrol, Trace, Attack
    }

    public State curstate;
    private void Start()
    {
        curstate = State.Patrol;
        StartCoroutine("Doing");
    }

    private void Update()
    {
        if (curstate == State.Trace)
        {
            if (Vector3.Distance(Player.transform.position, mob.transform.position) < 0.5f) 
            {
                curstate = State.Attack;
            }
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sound")
        {

            targetPos = other.transform.position;

            curstate = State.Trace;
            StopCoroutine("Doing");
            StartCoroutine("Doing");
        }


    }
    IEnumerator Doing()
    {
        while (true)
        {
            if (curstate == State.Patrol)
            {
                //��Ʈ��
                WaitForSeconds time1 = new WaitForSeconds(20f);

                Debug.Log("������");
                int x = Random.Range(0, patrolPoints.Length);
                agent.destination = patrolPoints[x].position;
                yield return time1;
            }
            else if (curstate == State.Trace)
            {
                //Ʈ���̽�
                Debug.Log("������");
                WaitForSeconds time2 = new WaitForSeconds(8f);
                agent.destination = targetPos;
                Vector3 prevmobPos = mob.transform.position; 
                yield return time2;
                if (Vector3.Distance(targetPos, mob.transform.position) < 0.5f)
                {
                    curstate = State.Patrol; // Ÿ���� �÷��̾�� �ƴѵ� �������� �� 
                }
                else if (prevmobPos == mob.transform.position) 
                {
                    curstate = State.Patrol; // �������ϴ� ���� Ÿ���� �� �ٽ� �������� 
                }
            }
            else if (curstate == State.Attack)
            {
                WaitForSeconds time3 = new WaitForSeconds(8f);
                Debug.Log("�÷��̾� ����");
                // �ִϸ��̼� �ٲٰ�, �Ҹ� ����ϰ� , �������� ȭ�� ����
                yield return time3;
                curstate = State.Patrol;
            }
        }
    }
}
