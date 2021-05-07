using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public Camera fpsCam;

    public int selectedWeapon = 0;
    public int range = 10;
    string weaponName;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.E))// && (previousSelectedWeapon != selectedWeapon))
        {
            Pickup();
            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }
            Drop();
        }

        /*if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }*/
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    void Pickup()
    {
        RaycastHit hit;
        Vector3 direction = fpsCam.transform.forward;
        Transform weaponCheck;

        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
        {
            Debug.Log("pick up " + hit.transform.name);

            if(hit.transform.CompareTag("CanGrab"))
            {
                weaponName = hit.transform.name;
                weaponCheck = transform.Find(weaponName);

                if (weaponCheck)
                {
                    selectedWeapon = weaponCheck.GetSiblingIndex();
                    Debug.Log("Weapon name picked up is " + weaponName + selectedWeapon);
                }
                else
                {
                    Debug.Log("Did not pick up weapon");
                }

                Destroy(hit.transform.gameObject);
            }
        }
    }

    void Drop()
    {

    }
}
