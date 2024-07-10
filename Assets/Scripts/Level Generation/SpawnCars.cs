using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [Header("Objects")]

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private GameObject[] carPrefabs;

    [Header("Road 1 Car Spawning")]

    [SerializeField] private float distanceFromPlayer1;
    [SerializeField] private float spawningDistance;
    [SerializeField] private int road1MaximalCarCount;
    public int road1CarCount;

    private List<Vector3> recentCarPositions1 = new List<Vector3>();


    [Header("Road 2 Car Spawning")]

    [SerializeField] private float distanceFromPlayer2;
    [SerializeField] private int road2MaximalCarCount;
    public int road2CarCount;

    private List<Vector3> recentCarPositions2 = new List<Vector3>();


    private void Update()
    {

        distanceFromPlayer1 = Vector3.Distance(player1.transform.position, GetSpawnPosition(player1));

        if (distanceFromPlayer1 < 120 && road1CarCount < road1MaximalCarCount)
        {
            SpawnCarsOnRoad1();
        }

        distanceFromPlayer2 = Vector3.Distance(player2.transform.position, GetSpawnPosition(player2));

        if (distanceFromPlayer2 < 120 && road2CarCount < road2MaximalCarCount)
        {
            SpawnCarsOnRoad2();
        }
    }

    private void SpawnCarsOnRoad1()
    {
        Vector3 spawnPosition = GetValidSpawnPosition(player1, recentCarPositions1);
        Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length)], spawnPosition, Quaternion.identity);
        recentCarPositions1.Add(spawnPosition);
        road1CarCount++;
    }

    private void SpawnCarsOnRoad2()
    {
        Vector3 spawnPosition = GetValidSpawnPosition(player2, recentCarPositions2);
        Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length)], spawnPosition, Quaternion.identity);
        recentCarPositions2.Add(spawnPosition);
        road2CarCount++;
    }

    private Vector3 GetValidSpawnPosition(GameObject player, List<Vector3> recentPositions)
    {
        Vector3 spawnPosition;
        bool positionIsValid;

        do
        {
            Vector3 forward = player.transform.forward;
            spawnPosition = player.transform.position + forward * spawningDistance;
            spawnPosition.x += Random.Range(-5, 5);
            spawnPosition.z += Random.Range(0, 100);

            positionIsValid = true;
            foreach (Vector3 recentPosition in recentPositions)
            {
                if (Vector3.Distance(spawnPosition, recentPosition) < 5f) // Minimum distance between cars
                {
                    positionIsValid = false;
                    break;
                }
            }
        } while (!positionIsValid);

        return spawnPosition;
    }

    private Vector3 GetSpawnPosition(GameObject player)
    {
        Vector3 forward = player.transform.forward;
        Vector3 spawnPosition = player.transform.position + forward * spawningDistance;
        spawnPosition.x += Random.Range(-5, 5);
        spawnPosition.z += Random.Range(0, 100);
        return spawnPosition;
    }
}
