using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunR : Gun
{
    //Variables
    //public Animator anim;
    public Transform spawnPoint;
    //public Text ammoDisplay;
    //public Text totalAmmo;

    /*public int currentAmmo;
    public int maxAmmo;
    public float fireRate;
    public float distance = 15f;
    public float damage;
    public float reloadTime;
    private float nextTimeToFire = 0f;
    private bool isReloading = false;*/

    //public GameObject muzzle;
    //public GameObject impact;
    //public LineRenderer bulletTrail;

    //Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fpsCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            OpenBox();
        }
        
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            anim.SetBool("Reload", true);
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            FindObjectOfType<AudioManager>().Play("ShotgunShot");
            anim.SetBool("Fire", true);
            Shoot();
        }
        else
        {
            anim.SetBool("Fire", false);
        }

        if (Input.GetKey("r"))
        {
            anim.SetBool("Reload", true);
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKey("e"))
        {
            OpenBox();
        }

        totalAmmo.text = amountOfAmmo.ToString();
        ammoDisplay.text = currentAmmo.ToString();
    }

    //Shoot method
    private void Shoot()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        ParticleSystem muzzleInstance = Instantiate(muzzleFlash, spawnPoint.position, spawnPoint.localRotation);
        muzzleInstance.transform.parent = spawnPoint;

        //Bullet that goes forward
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Hit(hit, damage);
            SpawnBulletTrail(hit);
        }

        //Bullet that goes forward
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(-.2f, 0f, 0f), out hit1, range))
        {
            //Instantiate(impactEffect, hit1.point, Quaternion.LookRotation(hit1.normal));

            Hit(hit1, damage);
            SpawnBulletTrail(hit1);
        }

        //Bullet that goes up
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(0f, .1f, 0f), out hit2, range))
        {
            //Instantiate(impactEffect, hit2.point, Quaternion.LookRotation(hit2.normal));

            Hit(hit2, damage);
            SpawnBulletTrail(hit2);
        }

        //Bullet that goes down
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(0f, -.1f, 0f), out hit3, range))
        {
            //Instantiate(impactEffect, hit3.point, Quaternion.LookRotation(hit3.normal));

            Hit(hit3, damage);
            SpawnBulletTrail(hit3);
        }

        currentAmmo--;
    }

    private void SpawnBulletTrail(RaycastHit hit)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, spawnPoint.transform.position, Quaternion.identity);

        LineRenderer bulletShot = bulletTrailEffect.GetComponent<LineRenderer>();

        bulletShot.SetPosition(0, spawnPoint.transform.position);
        bulletShot.SetPosition(1, hit.point);

        Destroy(bulletTrailEffect, 1f);
    }
}
