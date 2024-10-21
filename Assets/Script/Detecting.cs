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
                //패트롤
                WaitForSeconds time1 = new WaitForSeconds(20f);

                Debug.Log("순찰중");
                int x = Random.Range(0, patrolPoints.Length);
                agent.destination = patrolPoints[x].position;
                yield return time1;
            }
            else if (curstate == State.Trace)
            {
                //트레이스
                Debug.Log("추적중");
                WaitForSeconds time2 = new WaitForSeconds(8f);
                agent.destination = targetPos;
                Vector3 prevmobPos = mob.transform.position; 
                yield return time2;
                if (Vector3.Distance(targetPos, mob.transform.position) < 0.5f)
                {
                    curstate = State.Patrol; // 타겟이 플레이어는 아닌데 도착했을 때 
                }
                else if (prevmobPos == mob.transform.position) 
                {
                    curstate = State.Patrol; // 도착못하는 곳이 타겟일 때 다시 순찰모드로 
                }
            }
            else if (curstate == State.Attack)
            {
                WaitForSeconds time3 = new WaitForSeconds(8f);
                Debug.Log("플레이어 공격");
                // 애니메이션 바꾸고, 소리 재생하고 , 게임종료 화면 띄우고
                yield return time3;
                curstate = State.Patrol;
            }
        }
    }
}
