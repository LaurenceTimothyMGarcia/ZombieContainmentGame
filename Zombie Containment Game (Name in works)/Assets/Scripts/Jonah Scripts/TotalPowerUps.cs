using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPowerUps : MonoBehaviour
{

    public GameObject scoreText;
    public static int total = 0;
    public Collider item;

    public bool isNegative;

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = total.ToString();

    }

    void OnTriggerEnter(Collider item)
    {
        if(isNegative == true)
        {
            total--;
        }
        else
        {
            total++;
        }
        
    }

 


    
}
