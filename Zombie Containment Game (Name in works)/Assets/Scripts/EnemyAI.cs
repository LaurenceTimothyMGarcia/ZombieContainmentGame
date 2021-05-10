using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Animator anim;
    public GameObject ScreenFlash;

    public int health;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public int damage;
    public float damDelay;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("PlayerCharacter").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            AnimationBool(false, false);
            Patroling();
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            AnimationBool(true, false);
            ChasePlayer();
        }

        if (playerInSightRange && playerInAttackRange)
        {
            AnimationBool(false, true);
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
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
        //make sure enemy doesnt move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //attack code here
            Invoke(nameof(DamageDelay), damDelay);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void DamageDelay()
    {
        StartCoroutine(FlashScreen());
        GlobalHealth.PlayerHealth -= damage;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("MonsterHit");
        health -= damage;
        agent.SetDestination(transform.position);
        anim.SetTrigger("isShot");

        if (health <= 0)
        {
            anim.SetTrigger("isDead");
            Invoke(nameof(DestroyEnemy), 2f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void AnimationBool(bool chase, bool attack)
    {
        anim.SetBool("isChase", chase);
        anim.SetBool("isAttack", attack);
    }

    IEnumerator FlashScreen()
    {
        ScreenFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        ScreenFlash.SetActive(false);
    }
}
