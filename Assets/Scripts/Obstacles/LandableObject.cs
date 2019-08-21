using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Determines that the player can land on this object and the player will "stick" to that object while its moving.
/// </summary>

public class LandableObject : MonoBehaviour
{
    private Vector3 velocity;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
