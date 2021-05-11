using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmongUsBullet : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsPlayer;

    public int explosionDamage;
    public float explosionRange;

    public float maxLifeTime;
    public bool explodeOnTouch = true;


    private void Update()
    {
        maxLifeTime -= Time.deltaTime;
        if (maxLifeTime <= 0)
            Explode();
    }

    private void Explode()
    {
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        //Collider player = 
        Physics.OverlapSphere(transform.position, explosionRange, whatIsPlayer);

        GlobalHealth.PlayerHealth -= explosionDamage;

        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisonEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && explodeOnTouch)
        {
            Explode();
        }
    }
}
