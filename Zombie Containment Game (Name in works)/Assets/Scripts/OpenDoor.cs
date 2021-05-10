using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Collider boxCollider;
    GameObject[] enemyCount;
    public ParticleSystem doorOpen;
    public ParticleSystem flames;

    void Start()
    {

    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("enemies in scene: " + enemyCount.Length);
        if (enemyCount.Length <= 0)
        {
            boxCollider.enabled = true;
            doorOpen.Play();
            flames.Play();
            FindObjectOfType<AudioManager>().Play("OpenDoor");
            this.GetComponent<OpenDoor>().enabled = false;
        }
    }
}
