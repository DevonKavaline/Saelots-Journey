using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the Player to move slightly to the left and right and jump, with a double jump.
/// </summary>

public class AutoRunMovement : MonoBehaviour
{
    [Header("Movement Mode")]
    [Tooltip("True if in Auto Run Mode, False if in Boss Mode")]
    public bool isActive = true;

    [Header("Character Movement Variables")]
    [Tooltip("Character's Base Speed")]
    public float movementSpeed = 1.0f;
    [Tooltip("Multiplies Character Movement Speed")]
    public float speedMultiplier = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Move();
        }
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        transform.position += movement * (movementSpeed*speedMultiplier) * Time.deltaTime;
    }
}
