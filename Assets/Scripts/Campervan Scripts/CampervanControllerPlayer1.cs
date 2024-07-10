using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class CampervanControllerPlayer1 : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float steeringSpeed;


    private float initialXPosition;

    void Start()
    {
        // Store the initial x position
        initialXPosition = transform.position.x;
    }


    private void Update()
    {
        CampervanMovement();
    }


    private void CampervanMovement()
    {
        // Moves the campervan forwards cuntinuesly.
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        // Get the horizontal input
        float move = Input.GetAxis("Horizontal");


        // Calculate the new x position with steering speed and Time.deltaTime
        float newXPosition = transform.position.x + (move * steeringSpeed * Time.deltaTime);

        // Calculate the clamped x position based on the initial x position
        float minX = initialXPosition - 5f;
        float maxX = initialXPosition + 5f;
        newXPosition = Mathf.Clamp(newXPosition, minX, maxX);

        // Apply the clamped x position back to the transform position
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

    }

}
