using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public static int PlayerHealth = 25;
    public static int maxHealth = 25;
    public int InternalHealth;
    public static int originalHealth = 25;
    public GameObject HealthDisplay;

    void Update()
    {
        InternalHealth = PlayerHealth;
        HealthDisplay.GetComponent<Text>().text = "Health: " + PlayerHealth + "/" + maxHealth;
    }
}
