using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenarator : MonoBehaviour
{
    [SerializeField] private float platformMoveDistance;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Campervan"))
        {
            StartCoroutine("Transfer");
        }
    }

    IEnumerator Transfer()
    {
        yield return new WaitForSeconds(3f);

        Vector3 currentPosition = transform.parent.position;

        gameObject.transform.parent.position = new Vector3(currentPosition.x, currentPosition.y, gameObject.transform.position.z + platformMoveDistance);
    }
}
