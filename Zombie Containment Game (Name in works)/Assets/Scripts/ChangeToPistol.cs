using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToPistol : MonoBehaviour
{
    void OnTriggerEnter()
    {
        WeaponSwitch.selectedWeapon--;
    }
}
