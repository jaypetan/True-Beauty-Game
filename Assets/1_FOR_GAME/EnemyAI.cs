using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    public Animator animator;

    public float activationDistance = 5f;  // Adjust this distance as needed

    private void Start()
    {
        animator.SetBool("IsRunning", false);
    }
    private void Update()
    {
        // Check the distance between the player and the NPC
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (target != null && distanceToPlayer <= activationDistance)
        {
            agent.SetDestination(target.position);
            animator.SetBool("IsRunning", true);
        }
    }
}