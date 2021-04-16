using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    public static int dashAmount = 1;
    public int dashCount = dashAmount;
    

    playerController moveScript;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<playerController>();
    }

    // Update is called once per frame
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
}
