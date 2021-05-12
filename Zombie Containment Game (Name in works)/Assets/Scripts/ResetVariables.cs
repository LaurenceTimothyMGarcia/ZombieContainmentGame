using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ListOfRooms.listOfScenes.Clear();
        GlobalHealth.PlayerHealth = GlobalHealth.originalHealth;
        GlobalHealth.maxHealth = GlobalHealth.originalHealth;
        WeaponSwitch.selectedWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
