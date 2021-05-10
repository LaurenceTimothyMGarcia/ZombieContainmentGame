using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Collider boxCollider;
    GameObject[] enemyCount;
    public ParticleSystem doorOpen;

    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyCount.Length == 0)
        {
            boxCollider.enabled = true;
            doorOpen.Play();
            FindObjectOfType<AudioManager>().Play("OpenDoor");
        }
    }
}
