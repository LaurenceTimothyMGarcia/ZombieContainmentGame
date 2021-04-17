using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    public float dashBreak = 1;
    public static int dashAmount = 1;
    public int dashCount = dashAmount;
    

    playerController moveScript;

    void Start()
    {
        moveScript = GetComponent<playerController>();
    }

    void Update()
    {
        if (moveScript.controller.isGrounded)
        {
            dashCount = dashAmount;
        }

        if (dashCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Dash());
                dashCount--;
                StartCoroutine(DashTimer());
            }
        }
        
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.dashDir * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator DashTimer()
    {
        this.GetComponent<playerDash>().enabled = false;
        yield return new WaitForSeconds(dashBreak);
        this.GetComponent<playerDash>().enabled = true;
    }
}
