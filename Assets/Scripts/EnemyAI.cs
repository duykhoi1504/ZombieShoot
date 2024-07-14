using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
     Transform target;
    [SerializeField] float chaseRange=5f;
    NavMeshAgent  navMeshAgent;
    float distanceToTarget=Mathf.Infinity;
    [SerializeField ]bool isProvoked=false;
    EnemyHealth enemyHealth;
    [SerializeField] float turnSpeed=10f;
    [Header("Patrol")]
     [Range(0f, 10f)] [SerializeField] float posTime;
    [SerializeField] Vector3 PosRandom;
    [SerializeField] Vector3 priviosPos;
    // [SerializeField] Transform[] posPoints;
    // int postInt;
    // Vector3 dest;
    
    void Start()
    {
       
        navMeshAgent=GetComponent<NavMeshAgent>();
        enemyHealth=GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
         //patrol
        // postInt=Random.Range(0, posPoints.Length);
        SetRandomPosition();
        StartCoroutine(GoPosPoint());
        //
    }


    // Update is called once per frame
    void Update()
    {   
        // dest=posPoints[postInt].position;
        if(priviosPos!=PosRandom)
        {
            navMeshAgent.SetDestination(PosRandom);
            GetComponent<Animator>().SetTrigger("patrol");
        }
        if(enemyHealth.IsDead())
        {
            enabled=false;
            // navMeshAgent.enabled=false;
            
        }
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

       IEnumerator GoPosPoint(){
       GetComponent<Animator>().SetTrigger("idle");
        yield return new WaitForSeconds(posTime);
       priviosPos=PosRandom;
       SetRandomPosition() ;
        
    //    postInt=Random.Range(0, posPoints.Length);
       StartCoroutine(GoPosPoint());
       
    }

    void SetRandomPosition()
    {
        PosRandom = new Vector3(
            this.transform.position.x + Random.Range(-10f, 10f),
            this.transform.position.y,
            this.transform.position.z + Random.Range(-10f, 10f)
        );
    }
    public void OnDamageTaken(){
        isProvoked=true;
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
