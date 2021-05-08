using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float raycastDistance = 40f;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;

    void Start()
    {
        PositionRaycast();
    }

    void PositionRaycast()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
            Collider[] collidersInisdeOverlapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInisdeOverlapBox, spawnRotation, spawnedObjectLayer);

            if(numberOfCollidersFound == 0)
            {
                Pick(hit.point, spawnRotation);
            }
        }
    }

    void Pick(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        Instantiate(itemPrefab, positionToSpawn, rotationToSpawn);
    }
}
