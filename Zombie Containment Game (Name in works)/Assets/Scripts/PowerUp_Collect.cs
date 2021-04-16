using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_Collect : MonoBehaviour
{

    public Camera m_Camera;
    private float timeLeft = 20f;

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

    public bool isNegative;


    

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        
        Vector3 targetVector = this.transform.position - m_Camera.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, m_Camera.transform.rotation * Vector3.up);

        /*
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        Pickup(other);
        Destroy(gameObject);
    }
    
    //Power-up effects go here
    void Pickup(Collider player)
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        Gun weapon = player.GetComponentInChildren<Gun>();
        PlayerMovement movement = player.GetComponentInChildren<PlayerMovement>();


        if (isNegative == true)
        {
            if (isVitality == true)
            {
                health.maxHealth -= 50;
                health.currentHealth -= 50;
            }

            if (isCaliber == true)
            {

            }

            if (isPiercing == true) //float value
            {
                weapon.damage -= 4;

            }

            if (isBandolier == true) //int value
            {
                weapon.maxAmmo -= 4;
                weapon.currentAmmo -= 4;

            }

            if (isFireSpeed == true) //float value
            {
                weapon.fireRate -= 4;

            }

            if (isStamina == true)
            {
                movement.speed -= 2;

            }

            if (isDexterity == true) //float value
            {
                weapon.reloadTime += 1;

            }

            if (isPrecision == true) //float value
            {
                weapon.range -= 8;

            }

            if (isArmor == true)
            {

            }
        }


        if (isVitality == true)
        {
            health.maxHealth += 25;
            health.currentHealth += 25;

        }

        if (isCaliber == true)
        {

        }

        if (isPiercing == true)
        {
            weapon.damage += 2;

        }

        if (isBandolier == true)
        {
            weapon.maxAmmo += 2;
            weapon.currentAmmo += 2;

        }

        if (isFireSpeed == true)
        {
            weapon.fireRate += 2;

        }

        if (isStamina == true)
        {
            movement.speed += 1;

        }

        if (isDexterity == true)
        {
            weapon.reloadTime -= 0.5f;

        }

        if (isPrecision == true)
        {
            weapon.range += 4;

        }

        if (isArmor == true)
        {

        }


    }
    
}
