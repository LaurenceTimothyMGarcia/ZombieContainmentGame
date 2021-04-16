using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    //enemy properties
    public float health = 50f;
    
    //item box properties
    public bool isBox;
    public List<GameObject> items = new List<GameObject>();
    public bool isRandomized;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {          
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
        if (isBox == true)
        {
            int index = isRandomized ? Random.Range(0, items.Count) : 0;
            if (items.Count > 0)
            {

                Instantiate(items[index], transform.position, transform.rotation);

            }
        }
    }
    

}
