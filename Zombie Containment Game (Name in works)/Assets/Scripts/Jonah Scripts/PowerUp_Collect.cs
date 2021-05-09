using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_Collect : MonoBehaviour
{

    //public Camera m_Camera;
    //private float timeLeft = 20f;

    //Select power-up type
    public bool isVitality;
    public bool isCaliber;
    public bool isPiercing;
    public bool isBandolier;
    public bool isFireSpeed;
    public bool isStamina;
    public bool isDexterity;
    public bool isPrecision;
    public bool isArmor;
    public bool isJackpot;
    public bool isHealthPickup;


    public bool isNegative;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other);
            Pickup(other);
            Destroy(gameObject);
        }
    }
    
    //Power-up effects go here
    void Pickup(Collider player)
    {
        GlobalHealth health = player.GetComponentInChildren<GlobalHealth>();
        Gun weapon = player.GetComponentInChildren<Gun>();
        playerController movement = player.GetComponentInChildren<playerController>();
        //ShotgunR shotgun = player.GetComponentInChildren<ShotgunR>();

        Debug.Log("Global health: " + health);
        Debug.Log("Gun: " + weapon);
        Debug.Log("playerController: " + movement);
        //Debug.Log("Shotgun: " + shotgun);

        /*if (isNegative == true)
        {
            if (isVitality == true)
            {
                GlobalHealth.PlayerHealth -= 50;
                health.InternalHealth -= 50;

            }

            if (isCaliber == true)
            {
                weapon.range -= 8;
                shotgun.distance -= 1;
            }

            if (isPiercing == true) //float value
            {
                weapon.damage -= 4;
                shotgun.damage -= 1;
            }

            if (isBandolier == true) //int value
            {
                weapon.maxAmmo -= 4;
                weapon.currentAmmo -= 4;
                shotgun.currentAmmo -= 1;
                shotgun.maxAmmo -= 1;
            }

            if (isFireSpeed == true) //float value
            {
                weapon.fireRate -= 4;
                shotgun.fireRate -= 0.5f;
            }

            if (isStamina == true)
            {
                movement.walkSpeed -= 2;
            }

            if (isDexterity == true) //float value
            {
                weapon.reloadTime += 1;

            }

            if (isPrecision == true) //float value
            {
                weapon.spread += 0.002f;
            }


            if (isArmor == true)
            {

            }
        }*/


        if (isVitality == true)
        {
            GlobalHealth.PlayerHealth += 25;
            health.InternalHealth += 25;
        }

        if (isCaliber == true)
        {
            weapon.range += 4;
            //shotgun.range += 1;
        }

        if (isPiercing == true)
        {
            weapon.damage += 2;
            //Debug.Log(shotgun.damage);
            //shotgun.damage += 1;
        }

        if (isBandolier == true)
        {
            weapon.maxAmmo += 2;
            weapon.currentAmmo += 2;
            //Debug.Log(shotgun.currentAmmo);
            //shotgun.currentAmmo += 1;
            //shotgun.maxAmmo += 1;
        }

        if (isFireSpeed == true)
        {
            weapon.fireRate += 2;
            //shotgun.fireRate += 0.5f;
        }

        if (isStamina == true)
        {
            movement.walkSpeed += 1;

        }

        if (isDexterity == true)
        {
            weapon.reloadTime -= 0.5f;
            //shotgun.reloadTime -= 0.5f;
        }

        if (isPrecision == true)
        {
            weapon.spread -= 0.001f;
        }

        if (isJackpot == true)
        {
            GlobalHealth.PlayerHealth += 25;
            health.InternalHealth += 25;
            weapon.damage += 2;
            weapon.maxAmmo += 2;
            weapon.currentAmmo += 2;
            weapon.fireRate += 2;
            movement.walkSpeed += 1;
            weapon.reloadTime -= 0.5f;
            weapon.range += 4;
            weapon.spread -= 0.001f;
            /*shotgun.reloadTime -= 0.5f;
            shotgun.fireRate += 0.5f;
            shotgun.currentAmmo += 1;
            shotgun.maxAmmo += 1;
            shotgun.damage += 1;
            shotgun.range += 1;*/
        }

        if (isHealthPickup == true)
        {
            if (health.InternalHealth > GlobalHealth.PlayerHealth)
            {
                GlobalHealth.PlayerHealth += 10;
                if (health.InternalHealth < GlobalHealth.PlayerHealth)
                {
                    GlobalHealth.PlayerHealth = health.InternalHealth;
                }
            }
        }

        if (isArmor == true)
        {

        }


    }
    
}
