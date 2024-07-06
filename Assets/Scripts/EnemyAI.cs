using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float chaseRange=5f;
    NavMeshAgent  navMeshAgent;
    float distanceToTarget=Mathf.Infinity;
    [SerializeField ]bool isProvoked=false;
    [SerializeField] float turnSpeed=10f;
    void Start()
    {

        navMeshAgent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget=Vector3.Distance(target.position,transform.position);
            if(isProvoked)
            {
                EngageTarget();
            }
            else if(distanceToTarget<=chaseRange)
            {
                isProvoked=true;    
            //  navMeshAgent.SetDestination(target.position);
            }
       
    }

    void EngageTarget(){
         FaceToTarget();
        if(distanceToTarget >=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }


    void ChaseTarget(){
        GetComponent<Animator>().SetBool("attack",false);
       
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    void AttackTarget(){
        GetComponent<Animator>().SetBool("attack",true);

        // Debug.Log(name+"has seeked and is destoy"+ target.name);
    }
    void FaceToTarget(){
        // transform.LookAt(new Vector3(target.transform.position.x,0, target.transform.position.z));
        Vector3 direction = (target.position-transform.position).normalized;
        Debug.DrawRay(transform.position,direction,Color.green);
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*turnSpeed);
    }
    private void OnDrawGizmos() {
           Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
