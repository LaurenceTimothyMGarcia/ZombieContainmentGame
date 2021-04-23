using UnityEngine;
using UnityEngine.UI;

public class pistola : MonoBehaviour
{
    public Animator anim;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    public float impactForce = 30f;

    public int ammoMax = 6;
    public int ammoCurrent;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Text ammoDisplay;
    public Text totalAmmo;

    private float nextTimeToFire;

    void Start()
    {
        anim = GetComponent<Animator>();
        ammoCurrent = ammoMax;
    }

    void Update()
    {
        ammoDisplay.text = ammoCurrent.ToString();
        totalAmmo.text = ammoMax.ToString();
        if(Input.GetButtonDown("Fire1") && ammoCurrent != 0)
        {
            anim.SetBool("Fire", true);
            Shoot();
        }
        else
        {
            anim.SetBool("Fire", false);
        }

        if(Input.GetKey("r"))
        {
            ammoCurrent = ammoMax;
        }

        if (nextTimeToFire < fireRate)
        {
            nextTimeToFire += Time.deltaTime;
        }
    }

    void Shoot()
    {
        if(nextTimeToFire < fireRate)
            return;

        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            MonsterFollow target = hit.transform.GetComponent<MonsterFollow>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        nextTimeToFire = 0.0f;
        ammoCurrent--;
    }
}
