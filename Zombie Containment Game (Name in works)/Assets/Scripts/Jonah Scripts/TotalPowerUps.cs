using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPowerUps : MonoBehaviour
{

    public Text scoreText;
    public static int total;
    public Collider item;

    //Total power-ups collected (viewed on Pause Menu UI)
    public static int VitalityTotal;
    public static int CaliburTotal;
    public static int PiercingTotal;
    public static int BandolierTotal;
    public static int FireSpeedTotal;
    public static int StaminaTotal;
    public static int DexterityTotal;
    public static int PrecisionTotal;
    public static int JackpotTotal;

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


    public bool isNegative;


    void OnTriggerEnter(Collider Player)
    {
        if(isNegative == true)
        {
            if(isVitality == true)
            {
                VitalityTotal--;
                scoreText.GetComponent<Text>().text = VitalityTotal.ToString();
            }
            
            if (isCaliber == true)
            {
                CaliburTotal--;
                scoreText.GetComponent<Text>().text = CaliburTotal.ToString();
            }
            if (isPiercing == true)
            {
                PiercingTotal--;
                scoreText.GetComponent<Text>().text = PiercingTotal.ToString();
            }
            if (isBandolier == true)
            {
                BandolierTotal--;
                scoreText.GetComponent<Text>().text = BandolierTotal.ToString();
            }
            if (isFireSpeed == true)
            {
                FireSpeedTotal--;
                scoreText.GetComponent<Text>().text = FireSpeedTotal.ToString();
            }
            if (isStamina == true)
            {
                StaminaTotal--;
                scoreText.GetComponent<Text>().text = StaminaTotal.ToString();
            }
            if (isDexterity == true)
            {
                DexterityTotal--;
                scoreText.GetComponent<Text>().text = DexterityTotal.ToString();
            }
            if (isPrecision == true)
            {
                PrecisionTotal--;
                scoreText.GetComponent<Text>().text = PrecisionTotal.ToString();
            }


        }
        else
        {
            if (isVitality == true)
            {
                VitalityTotal++;
                scoreText.GetComponent<Text>().text = VitalityTotal.ToString();
            }

            if (isCaliber == true)
            {
                CaliburTotal++;
                scoreText.GetComponent<Text>().text = CaliburTotal.ToString();
            }
            if (isPiercing == true)
            {
                PiercingTotal++;
                scoreText.GetComponent<Text>().text = PiercingTotal.ToString();
            }
            if (isBandolier == true)
            {
                BandolierTotal++;
                scoreText.GetComponent<Text>().text = BandolierTotal.ToString();
            }
            if (isFireSpeed == true)
            {
                FireSpeedTotal++;
                scoreText.GetComponent<Text>().text = FireSpeedTotal.ToString();
            }
            if (isStamina == true)
            {
                StaminaTotal++;
                scoreText.GetComponent<Text>().text = StaminaTotal.ToString();
            }
            if (isDexterity == true)
            {
                DexterityTotal++;
                scoreText.GetComponent<Text>().text = DexterityTotal.ToString();
            }
            if (isPrecision == true)
            {
                PrecisionTotal++;
                scoreText.GetComponent<Text>().text = PrecisionTotal.ToString();
            }

            if (isJackpot == true)
            {
                JackpotTotal++;
                scoreText.GetComponent<Text>().text = JackpotTotal.ToString();
            }
        }

    }





}
