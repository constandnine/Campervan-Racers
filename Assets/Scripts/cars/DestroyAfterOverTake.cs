using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterOverTake : MonoBehaviour
{
    private void Update()
    {
        // Find all objects with the tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Campervan");

        // Assume initially that no player is within range
        bool playerInRange = false;

        // Check distance to each player
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= 15.0f)
            {
                playerInRange = true;
                break;
            }
        }

        // Destroy the object if no player is within 15 units
        if (!playerInRange)
        {
            Destroy(gameObject);
        }
    }
}
