using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampervanController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;


    private void Update()
    {
        CampervanMoevement();
    }

    private void CampervanMoevement()
    {
        // Moves the campervan forwards cuntinuesly.
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
