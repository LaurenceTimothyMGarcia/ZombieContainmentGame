using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    //Add the game object
    public GameObject item;
    
    //Locations
    private int xPos;
    private int zPos;

    //Spawner range minimums
    public int xMin;
    public int zMin;

    //User inputs the item spawner range maximums
    public int xMax;
    public int zMax;

    //Reduce the amount of items that spawn, the higher itemCount is
    public int itemCount;
    int i = 0;
    bool runOnce = true;

    void Start()
    {
        /*Debug.Log("Drop items right now");
        FindObjectOfType<AudioManager>().Play("ItemDrop");
        StartCoroutine(ItemDrop());*/
    }

    void Update()
    {
        if (runOnce)
        {
            //FindObjectOfType<AudioManager>().Play("ItemDrop");
            StartCoroutine(ItemDrop());
            runOnce = false;
        }
    }

    IEnumerator ItemDrop()
    {
        FindObjectOfType<AudioManager>().Play("ItemDrop");
        while(i < itemCount)
        {
            xPos = Random.Range(xMin, xMax); //Default: xPos = (1, 50)
            zPos = Random.Range(zMin, zMax); //Default: zPos = (1, 31)

            //Spawn item
            Instantiate(item, new Vector3(xPos, 43, zPos), Quaternion.identity);

            //Spawn delay
            yield return new WaitForSeconds(0.5f);
            
            //Item spawn incriment
            i++;
        }
    }

}
