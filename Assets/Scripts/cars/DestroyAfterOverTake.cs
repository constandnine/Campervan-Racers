using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterOverTake : MonoBehaviour
{

    [SerializeField] private SpawnCars spawnCars;
    private void OnTriggerEnter(Collider other)
    {
        // Destroy the GameObject
        Destroy(other.gameObject);


        if (CompareTag("Road 1 Car Destroyer"))
        {
            spawnCars.road1CarCount--;
        }


        // Check if the tag is "two"
        else if (CompareTag("Road 2 Car Destroyer"))
        {
            spawnCars.road2CarCount--;
        }
    }
}
