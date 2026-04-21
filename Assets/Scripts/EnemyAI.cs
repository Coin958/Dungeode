//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyAI : MonoBehaviour
//{
//    public Transform player;
//    private NavMeshAgent agent;

//    public Animator animator;

//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        if (player != null)
//        {
//            agent.SetDestination(player.position);
//        }

//        
//        animator.SetFloat("Speed", agent.velocity.magnitude);
//    }
//}

using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public Animator animator;

    [Header("Detección")]
    public float detectionDistance = 10f; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionDistance)
        {

            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {

            agent.isStopped = true;
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}