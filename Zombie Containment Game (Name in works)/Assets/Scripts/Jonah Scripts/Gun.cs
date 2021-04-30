
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Animator anim;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    //Ammo Display UI
    public Text ammoDisplay;
    public Text totalAmmo;
    public bool isFiring;

    //Weapon Statistics
    public float damage;
    public float range;
    public float fireRate;
    public int maxAmmo;
    public int currentAmmo;
    public float spread;
   
    //Reload Statistics
    private bool isReloading = false;
    public float reloadTime;

    private float nextTimeToFire = 0f;


    //Recoil Statistics
    public Vector3 upRecoil;
    Vector3 originalRotation;

    public LayerMask canBeShot;



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
        
        damage += TotalPowerUps.PiercingTotal;
        //Fire weapon
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) //Remove && statement if gun is semi-automatic
        {
            nextTimeToFire = Time.time + 1f / fireRate;
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

        yield return new WaitForSeconds(reloadTime);

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
            Debug.Log(hit.transform.name);
            
            MonsterFollow target = hit.transform.GetComponent<MonsterFollow>();
            //Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }

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
}
