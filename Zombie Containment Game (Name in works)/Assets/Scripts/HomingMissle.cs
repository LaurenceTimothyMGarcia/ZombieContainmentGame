using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    GameObject Target;
    Transform RocketTarget;
    public Rigidbody Rocket;
    public GameObject explosion;

    public int damage = 1;
    public float turnSpeed = 1f;
    public float rocketFlySpeed = 1f;
    public float lifeTime = 2f;

    private Transform rocketLocalTrans;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        RocketTarget = Target.transform;
        if(!RocketTarget)
        {

        }

        rocketLocalTrans = GetComponent<Transform>();

        StartCoroutine(DestroyGameObject());
    }

    private void Update()
    {
        if (!Rocket)
        {
            return;
        }

        Rocket.velocity = rocketLocalTrans.forward * rocketFlySpeed;

        var rocketTargetRot = Quaternion.LookRotation(RocketTarget.position - rocketLocalTrans.position);

        Rocket.MoveRotation(Quaternion.RotateTowards(rocketLocalTrans.rotation, rocketTargetRot, turnSpeed));

        /*if (Vector3.Distance(RocketTarget.transform.position, transform.position) < 0.3f)
        {
            GlobalHealth.PlayerHealth -= damage;
            Destroy(this);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            GlobalHealth.PlayerHealth -= damage;
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }



    /*void Update()
    {
        Rocket.transform.LookAt(Target.transform);
        //SendHoming(RocketTarget, rocketFlySpeed, damage);
        while (Vector3.Distance(RocketTarget.transform.position, transform.position) > 0.3f || lifeTime >= 0)
        {
            transform.position += (RocketTarget.transform.position - transform.position).normalized * rocketFlySpeed * Time.deltaTime;
            transform.LookAt(RocketTarget.transform);
            lifeTime -= Time.deltaTime;
            //yield return null;
        }

        if (lifeTime <= 0)
        {
            Destroy(this);
        }
        else
        {
            GlobalHealth.PlayerHealth -= damage;
            Destroy(this);
        }
    }

    public void SendHoming(Transform target, float speed, int damage)
    {
        
    }*/


    /**/





    /*public List<GameObject> spawnPositions;
    public GameObject misslePrefab;
    public Transform target;
    public float speed = 1f;

    // Update is called once per frame
    public void LaunchRocket(GameObject misslePrefab, GameObject gonk, Transform target, float speed, int damage)
    {
        GameObject rocket = Instantiate(misslePrefab, gonk.transform.position, misslePrefab.transform.rotation);
        rocket.transform.LookAt(target.transform);
        StartCoroutine(SendHoming(rocket, target, speed, damage));
    }

    public IEnumerator SendHoming(GameObject rocket, Transform target, float speed, int damage)
    {
        while (Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3f)
        {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);
            yield return null;
        }
        GlobalHealth.PlayerHealth -= damage;
        Destroy(rocket);
    }*/
}
