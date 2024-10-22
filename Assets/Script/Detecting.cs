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

    [SerializeField] Transform Cam;

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip walksound;
    [SerializeField] AudioClip atksound;

    public UnityEvent PlayerDead;
    private Vector3 targetPos;

    private bool isatk = false;

    public enum State
    {
        Patrol, Trace, Attack
    }

    public State curstate;
    private void Start()
    {   
        source.clip = walksound;
        curstate = State.Patrol;
        StartCoroutine("Doing");
    }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, mob.transform.position) < 1.5f)
        {
            if (isatk == false)
            {
                isatk = true;
                curstate = State.Attack;
                mob.transform.position = Cam.transform.position;
                mob.transform.LookAt(Player.transform);
                animator.Play("Atk");
                source.clip = atksound;
                source.Play();
                PlayerDead?.Invoke();
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
        WaitForSeconds time = new WaitForSeconds(6f);
        while (true)
        {
            source.clip = walksound;
            source.Play();
            animator.Play("Run");
            if (curstate == State.Patrol)
            {
                Debug.Log("순찰중");
                int x = Random.Range(0, patrolPoints.Length);
                agent.destination = patrolPoints[x].position;
                yield return time;
            }
            else if (curstate == State.Trace)
            {
                //트레이스
                Debug.Log("추적중");
            
                agent.destination = targetPos;
                Vector3 prevmobPos = mob.transform.position;
                
                if (Vector3.Distance(targetPos, mob.transform.position) < 1.5f)
                {
                    curstate = State.Patrol; // 타겟이 플레이어는 아닌데 도착했을 때 
                }
                else if (prevmobPos == mob.transform.position)
                {
                    curstate = State.Patrol; // 도착못하는 곳이 타겟일 때 다시 순찰모드로 
                }
            }
            yield return time;
            

        }
    }
}
