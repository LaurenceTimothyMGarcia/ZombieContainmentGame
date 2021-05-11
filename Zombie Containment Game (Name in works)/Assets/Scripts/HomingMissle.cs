using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    
    public List<GameObject> spawnPositions;
    /*public GameObject misslePrefab;
    public Transform target;
    public float speed = 1f;*/

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
    }
}
