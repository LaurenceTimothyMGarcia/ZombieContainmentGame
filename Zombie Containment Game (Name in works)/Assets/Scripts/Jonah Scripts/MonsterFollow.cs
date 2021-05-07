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

    public float health = 50f;

    public int IsAttacking;
    public GameObject ScreenFlash;
    public AudioSource Hurt01;
    public AudioSource Hurt02;
    public AudioSource Hurt03;
    public int HurtSound;

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
            if (IsAttacking == 0)
            {
                StartCoroutine(EnemyDamage());
            }
            EnemySpeed = 0;
            TheEnemy.GetComponent<Animation>().Play("rig_Attack");
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = 1;
    }
    void OnTriggerExit()
    {
        AttackTrigger = 0;
    }

    public void TakeDamage(float amount)
    {
        FindObjectOfType<AudioManager>().Play("MonsterHit");
        health -= amount;
        TheEnemy.GetComponent<Animation>().Play("rig_ShotAt");
        StartCoroutine(Stagger());
        if (health <= 0f)
        {
            this.GetComponent<MonsterFollow>().enabled = false;
            TheEnemy.GetComponent<Animation>().Play("rig_DeathAnimation");
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator Stagger()
    {
        this.GetComponent<MonsterFollow>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<MonsterFollow>().enabled = true;
    }

    IEnumerator EnemyDamage()
    {
        IsAttacking = 1;
        HurtSound = Random.Range(1, 4);
        yield return new WaitForSeconds(0.5f);
        ScreenFlash.SetActive(true);
        GlobalHealth.PlayerHealth -= 1;
        /*if (HurtSound == 1)
         * {
         *    Hurt01.Play();
         * }
         * if (HurtSound == 2)
         * {
         *    Hurt02.Play();
         * }
         * if (HurtSound == 3)
         * {
         *    Hurt03.Play();
         * }*/
        yield return new WaitForSeconds(0.05f);
        ScreenFlash.SetActive(false);
        yield return new WaitForSeconds(1);
        IsAttacking = 0;
    }

}
