using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float health = 1f;
    public float blastRadius = 5f;
    public float force = 700f;
    public int damage = 10;

    public GameObject explosionEffect;

    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            Rigidbody rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
            Rigidbody rbFrog = GameObject.Find("FrogMonster").GetComponent<Rigidbody>();
            Rigidbody rbElong = GameObject.Find("Elongated").GetComponent<Rigidbody>();

            MonsterFollow target = GameObject.Find("FrogMonster").GetComponent<MonsterFollow>();
            EnemyAI enemy = GameObject.Find("Elongated").GetComponent<EnemyAI>();

            if(rb == rbPlayer)
            {
                GlobalHealth.PlayerHealth -= damage;
            }

            if(rb == rbFrog)
            {
                target.TakeDamage(damage);
            }

            if(rb == rbElong)
            {
                enemy.TakeDamage(damage);
            }

            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, blastRadius);
            }
        }


        Destroy(gameObject);
    }
}
