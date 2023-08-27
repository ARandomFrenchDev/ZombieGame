using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent navMeshAgent;
    Animator enemyAnimation;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<Animator>();
    }
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked) {
            enemyAnimation.SetBool("isProvoked", true);
            EngageTarget();
        } 
        else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
        else if (distanceToTarget > chaseRange) {
            isProvoked = false;
            enemyAnimation.SetBool("isProvoked", false);
        }

    }

    private void EngageTarget() {
        if(distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void ChaseTarget() {
        enemyAnimation.SetBool("isInAttackRange", false);
        navMeshAgent.SetDestination(target.position);

    }

    private void AttackTarget() {
        enemyAnimation.SetBool("isInAttackRange", true);
        Debug.Log("MANGER HUMAIN.");
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
