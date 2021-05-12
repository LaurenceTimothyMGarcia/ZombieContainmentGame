using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StopWatch : MonoBehaviour
{
    public bool stopWatchActive = false;
    public static float currentTime = 0;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        //stopWatchActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalHealth.PlayerHealth <= 0)
        {
            stopWatchActive = false;
        }
        
        if (stopWatchActive == true)
        {
            currentTime += Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }

    public void StartStopwatch()
    {
        stopWatchActive = true;
    }

    public void StopStopwatch()
    {
        stopWatchActive = false;
    }
}
