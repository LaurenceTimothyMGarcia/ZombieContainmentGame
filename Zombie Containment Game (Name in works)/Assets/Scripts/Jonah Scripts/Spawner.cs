using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> items = new List<GameObject>();
    public bool isRandomized;

    public void SpawnObject()
    {
        int index = isRandomized ? Random.Range(0, items.Count) : 0;
        if(items.Count > 0)
        {
            
            Instantiate(items[index], transform.position, transform.rotation);

        }
    }
}
