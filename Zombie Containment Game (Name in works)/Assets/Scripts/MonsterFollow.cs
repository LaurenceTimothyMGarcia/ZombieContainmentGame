using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance < AllowedRange)
            {
                EnemySpeed = 0.01f;
                if (AttackTrigger == 0)
                {
                    TheEnemy.GetComponent<Animation>().Play("rig_Run");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            }
            else //stops walking, maybe replace with random roaming
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("rig_Walking");
            }
        }

        if (AttackTrigger == 1)
        {
            TheEnemy.GetComponent<Animation>().Play("rig_Attack");
        }
    }
}
