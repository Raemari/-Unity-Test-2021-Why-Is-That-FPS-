using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator animator;
    Rigidbody rb;
    EnemyHealth health;
    Transform target;

    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    float distanceToTarget = Mathf.Infinity;

    public float movementSpeed = 3f;
    public float rotSpeed = 100f;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    private bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerManager>().transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(health.IsDead())
        {
            //disables enemyAI
            //first line doesnt disable navmesh agent
            enabled = false;
            navMeshAgent.enabled = false;
            animator.SetTrigger("isDead");
        }
        IsProvoked();
        EnemyPatrolling();
    }
    private void EnemyPatrolling()
    {
        if (isWandering == false && isProvoked == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true && isProvoked == false)
        {
            gameObject.GetComponent<Animator>().Play("Idle");
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true && isProvoked == false)
        {
            gameObject.GetComponent<Animator>().Play("Idle");
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true && isProvoked == false)
        {
            gameObject.GetComponent<Animator>().Play("Move");
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
    // private void UpdateDestination()
    // {
    //     targetWaypoint = waypoints[waypointIndex].position;
    //     navMeshAgent.SetDestination(targetWaypoint);
    // }
    // private void IterateWaypoints()
    // {
    //     waypointIndex++;
    //     if(waypointIndex == waypoints.Length)
    //     {
    //         waypointIndex = 0;
    //     }
    // }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void IsProvoked()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }
    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    private void ChaseTarget()
    {
        animator.SetTrigger("move");
        animator.SetBool("attack", false);
        rb.AddForce(transform.forward * movementSpeed);
        if(navMeshAgent!= null && navMeshAgent.enabled == true)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void AttackTarget()
    {
        animator.SetBool("attack", true);
    }
    private void FaceTarget()
    {
        //vector3.normalized to preserve the direction. 
        //moves the point to 1 unit from the origin to that point
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //Slerp to provide uniform curve
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    // private void FaceTarget()
    // {
    //     Vector3 direction = Vector3.Normalize(target.transform.position - transform.position);
    //     Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //     transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    // }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
    }
}
