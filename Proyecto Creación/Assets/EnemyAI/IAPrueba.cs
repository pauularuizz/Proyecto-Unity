using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAPrueba : MonoBehaviour
{
    public  NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    //patrulla
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject Projectile;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("_Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        
        if (!playerInSightRange&&!playerInAttackRange)
        {
            Patrolling();
        }
        if (playerInSightRange&&!playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange&&playerInAttackRange)
        {
            AttackPlayer();
        }
    }
    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector2 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude<1f)
        {
            walkPointSet = false;
        }
    }void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

        if (Physics2D.Raycast(walkPoint,-transform.up,2f,whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked==true)
        {
            Rigidbody2D rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            rb.AddForce(transform.forward * 32f, ForceMode2D.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Invoke(nameof(DestroyEnemy), 5f);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
