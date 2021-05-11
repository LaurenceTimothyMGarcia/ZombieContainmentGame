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
    //public ParticleSystem explosionEffect;

    bool hasExploded = false;
    Rigidbody rbPlayer;
    Rigidbody rbFrog;
    Rigidbody rbElong;
    
    MonsterFollow target;
    EnemyAI enemy;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        rbFrog = GameObject.Find("FrogMonster").GetComponent<Rigidbody>();
        rbElong = GameObject.Find("Elongated").GetComponent<Rigidbody>();

        target = GameObject.Find("FrogMonster").GetComponent<MonsterFollow>();
        enemy = GameObject.Find("Elongated").GetComponent<EnemyAI>();
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
        FindObjectOfType<AudioManager>().Play("Explosion");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //explosionEffect.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, blastRadius);
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
            }
        }

        Destroy(gameObject);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
    }
}
