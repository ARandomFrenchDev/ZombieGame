using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] AudioClip zombieIdleClip;
    NavMeshAgent navMeshAgent;
    Animator enemyAnimation;
    AudioSource audioSource;
    float turnSpeed = 5f;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.5f, 1f);
    }
    void Update()
    {
        if(GetComponent<EnemyHealth>().IsDead() != true) {
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
        } else {
            navMeshAgent.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    private void EngageTarget() {
        FaceTarget();
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
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    
}
