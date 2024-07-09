using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CampervanControllerPlayer2 : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float steeringSpeed;


    private void Update()
    {
        CampervanMovement();

    }
    private void CampervanMovement()
    {
        float move = 0f;

        // Moves the campervan forwards cuntinuesly.
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f; // Move left
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f; // Move right
        }

        // Move the player left and right
        transform.Translate(Vector3.right * move * steeringSpeed * Time.deltaTime);
    }

}
