using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
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

    void Start()
    {
        StartCoroutine(ItemDrop());
    }

    IEnumerator ItemDrop()
    {
        while(itemCount < 5)
        {
            xPos = Random.Range(xMin, xMax); //Default: xPos = (1, 50)
            zPos = Random.Range(zMin, zMax); //Default: zPos = (1, 31)

            //Spawn item
            Instantiate(item, new Vector3(xPos, 43, zPos), Quaternion.identity);

            //Spawn delay
            yield return new WaitForSeconds(0.5f);
            
            //Item spawn incriment
            itemCount += 1;
        }
    }

}
