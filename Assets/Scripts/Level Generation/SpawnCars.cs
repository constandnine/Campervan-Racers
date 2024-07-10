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

    [SerializeField] private int road1CarCount;
    [SerializeField] private int road1MaximalCarCount;

    private Vector3 spawnCarRoad1Position;


    [Header("Road 2 Car Spawning")]

    [SerializeField] private float distanceFromPlayer2;

    [SerializeField] private int road2CarCount;
    [SerializeField] private int road2MaximalCarCount;

    private Vector3 spawnCarRoad2Position;


    private void Update()
    {
        distanceFromPlayer1 = Vector3.Distance(player1.transform.position, spawnCarRoad1Position);

        if(distanceFromPlayer1 < 120 && road1CarCount < road1MaximalCarCount)
        {
            SpawnCarsOnRoad1();
        }


        distanceFromPlayer2 = Vector3.Distance(player2.transform.position, spawnCarRoad2Position);

        if (distanceFromPlayer2 < 120 && road2CarCount < road2MaximalCarCount)
        {
            SpawnCarsOnRoad2();
        }

    }


    private void SpawnCarsOnRoad1()
    {
        spawnCarRoad1Position = new Vector3(Random.Range(5, -5), 0, Random.Range(0, 100) + spawningDistance);

        Instantiate(carPrefabs[(Random.Range(0, carPrefabs.Length))], spawnCarRoad1Position, Quaternion.identity);


        road1CarCount++;

    }


    private void SpawnCarsOnRoad2()
    {
        spawnCarRoad2Position = new Vector3(Random.Range(53.41f, 63.41f), 0, Random.Range(0, 100) + spawningDistance);

        Instantiate(carPrefabs[(Random.Range(0, carPrefabs.Length))], spawnCarRoad2Position, Quaternion.identity);


        road2CarCount++;
    }
}
