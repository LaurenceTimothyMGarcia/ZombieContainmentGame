using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GonkAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Animator anim;
    public GameObject ScreenFlash;
    public ParticleSystem flames;

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
    public GameObject projectile;
    //HomingMissle missle;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("PlayerCharacter").transform;
        agent = GetComponent<NavMeshAgent>();
        //missle = GetComponent<HomingMissle>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            anim.SetBool("isAttack", false);
            Patroling();
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            anim.SetBool("isAttack", false);
            ChasePlayer();
        }

        if (playerInSightRange && playerInAttackRange)
        {
            anim.SetBool("isAttack", true);
            AttackPlayer();
        }

        if (health <= 25)
        {
            FindObjectOfType<VoiceManager>().Play("WarningLowHealth");
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
        FindObjectOfType<VoiceManager>().Play("WeLiveInSociety");
        flames.Play();
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        FindObjectOfType<VoiceManager>().Play("Gonked");
        flames.Stop();
        //make sure enemy doesnt move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //attack code here
            //missle.LaunchRocket(projectile, this.gameObject, player, 1f, damage);
            Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            /*rb.AddForce(transform.forward * 16f, ForceMode.Impulse);
            rb.AddForce(transform.up, ForceMode.Impulse);*/

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    //private void 

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("MonsterHit");
        health -= damage;
        agent.SetDestination(transform.position);
        //anim.SetTrigger("isShot");

        if (health <= 0)
        {
            FindObjectOfType<VoiceManager>().Play("WarningDead");
            //anim.SetTrigger("isDead");
            Invoke(nameof(DestroyEnemy), 2f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    /*private void Fire()
    {
        if(!flames.active)
        {
            flames.SetActive() = true;
        }
    }

    private void StopFire()
    {
        if(flames.active)
        {
            flames.SetActive() = false;
        }
    }*/

    IEnumerator FlashScreen()
    {
        ScreenFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        ScreenFlash.SetActive(false);
    }
}

