using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Animator anim;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bulletOrigin;
    public LineRenderer bulletTrail;

    //Ammo Display UI
    public Text ammoDisplay;
    public Text totalAmmo;
    public bool isFiring;

    //Weapon Statistics
    public int damage;
    public float range;
    public float fireRate;
    public int maxAmmo;
    public int currentAmmo;
    public int amountOfAmmo;
    public float spread;
   
    //Reload Statistics
    public bool isReloading = false;
    public float reloadTime;

    public float nextTimeToFire = 0f;

    //Recoil Statistics
    public Vector3 upRecoil;
    public Vector3 originalRotation;

    public LayerMask canBeShot;

    public void Hit(RaycastHit hit, int damage)
    {
        MonsterFollow target = hit.transform.GetComponent<MonsterFollow>();
        EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
        GonkAI gonk = hit.transform.GetComponent<GonkAI>();
        Target box = hit.transform.GetComponent<Target>();
        Barrel bar = hit.transform.GetComponent<Barrel>();
        HomingMissle amongUs = hit.transform.GetComponent<HomingMissle>();
        //Target target = hit.transform.GetComponent<Target>();
        if(target != null)
        {
            target.TakeDamage(damage);
        }

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if(gonk != null)
        {
            gonk.TakeDamage(damage);
        }

        if (box != null)
        {
            box.TakeDamage(damage);
        }

        if (bar != null)
        {
            bar.health -= damage;
        }

        if (amongUs != null)
        {
            amongUs.health -= damage;
        }

        GameObject clone = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(clone, 1f);
    }

    protected IEnumerator Reload()
    {
        int difference;

        if (amountOfAmmo <= 0)
        {
            anim.SetBool("Reload", false);
            yield break;
        }
        
        isReloading = true;
        //Debug.Log("Reloading...");
        FindObjectOfType<AudioManager>().Play("Reload");

        yield return new WaitForSeconds(reloadTime);
        anim.SetBool("Reload", false);

        if (amountOfAmmo < maxAmmo)
        {
            currentAmmo += amountOfAmmo;
            if (currentAmmo > maxAmmo)
            {
                amountOfAmmo = currentAmmo - maxAmmo;
                currentAmmo = maxAmmo;
            }
            else
            {
                amountOfAmmo -= amountOfAmmo;
            }
        }
        else
        {
            difference = maxAmmo - currentAmmo;
            currentAmmo = maxAmmo;
            amountOfAmmo -= difference;
        }

        isReloading = false;
    }

    protected void OpenBox()
    {
        RaycastHit hit;
        Vector3 direction = fpsCam.transform.forward;
        
        //Raycast
        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
        {
            Target box = hit.transform.GetComponent<Target>();
            if (box != null)
            {
                box.TakeDamage(damage);
            }
        }

    }
}
