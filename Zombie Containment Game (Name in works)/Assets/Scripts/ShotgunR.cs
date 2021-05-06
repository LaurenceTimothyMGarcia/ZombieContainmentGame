using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunR : MonoBehaviour
{
    //Variables
    public Transform spawnPoint;
    public float distance = 15f;

    public GameObject muzzle;
    public GameObject impact;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //Shoot method
    private void Shoot()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        GameObject muzzleInstance = Instantiate(muzzle, spawnPoint.position, spawnPoint.localRotation);
        muzzleInstance.transform.parent = spawnPoint;

        //Bullet that goes forward
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));

            //Apply damage if you have a method to do so
        }

        //Bullet that goes forward
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-.2f, 0f, 0f), out hit1, distance))
        {
            Instantiate(impact, hit1.point, Quaternion.LookRotation(hit1.normal));

            //Apply damage if you have a method to do so
        }

        //Bullet that goes up
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, .1f, 0f), out hit2, distance))
        {
            Instantiate(impact, hit2.point, Quaternion.LookRotation(hit2.normal));

            //Apply damage if you have a method to do so
        }

        //Bullet that goes down
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -.1f, 0f), out hit3, distance))
        {
            Instantiate(impact, hit3.point, Quaternion.LookRotation(hit3.normal));

            //Apply damage if you have a method to do so
        }
    }
}
