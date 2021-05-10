using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGun : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        originalRotation = transform.localEulerAngles;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        
        //Fire weapon
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire) //Remove down to spray and praystatement if gun is semi-automatic
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            FindObjectOfType<AudioManager>().Play("GunShot");
            anim.SetBool("Fire", true);
            AddRecoil();
            Shoot();
            StopRecoil();
        }
        else
        {
            anim.SetBool("Fire", false);
        }

        //R input required     
        if(Input.GetKey("r"))
        {
            anim.SetBool("Reload", true);
            StartCoroutine(Reload());
            return;
        }
        

        totalAmmo.text = maxAmmo.ToString();
        ammoDisplay.text = currentAmmo.ToString();

    }



    //Reloading
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        FindObjectOfType<AudioManager>().Play("Reload");

        yield return new WaitForSeconds(reloadTime);
        anim.SetBool("Reload", false);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    //Shooting
    void Shoot()
    {
        RaycastHit hit;

        muzzleFlash.Play();
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);
        
        //Raycast
        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
        {
            Debug.Log(hit.transform.name + " hit him");
            
            MonsterFollow target = hit.transform.GetComponent<MonsterFollow>();
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            Target box = hit.transform.GetComponent<Target>();
            //Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (box != null)
            {
                box.TakeDamage(damage);
            }

            GameObject clone = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(clone, 1f);
        }

        SpawnBulletTrail(hit);

        currentAmmo--;
    }

    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }

    private void SpawnBulletTrail(RaycastHit hit)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, bulletOrigin.transform.position, Quaternion.identity);

        LineRenderer bulletShot = bulletTrailEffect.GetComponent<LineRenderer>();

        bulletShot.SetPosition(0, bulletOrigin.transform.position);
        bulletShot.SetPosition(1, hit.point);

        Destroy(bulletTrailEffect, 1f);
    }
}
