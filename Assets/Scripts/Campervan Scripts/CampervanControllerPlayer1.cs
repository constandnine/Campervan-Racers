using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class CampervanControllerPlayer1 : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float steeringSpeed;




    private void Update()
    {
        CampervanMovement();

        // Get the horizontal input
        float move = Input.GetAxis("Horizontal");

        // Move the player left and right
        transform.Translate(Vector3.right * move * steeringSpeed * Time.deltaTime);
    }


    private void CampervanMovement()
    {
        // Moves the campervan forwards cuntinuesly.
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

}
