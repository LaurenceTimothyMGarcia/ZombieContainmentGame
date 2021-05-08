using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float radius = 20;

    void Start()
    {
        SpawnObjectAtRandom();
    }

    void SpawnObjectAtRandom()
    {
        //Vector3 randomPos = RandomSpawner.insideUnitCircle * radius;

        //Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    }
}
