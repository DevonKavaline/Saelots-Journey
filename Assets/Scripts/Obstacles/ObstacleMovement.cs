using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the object attached in the -X direction indefinitely
/// FEATURES TO ADD
/// TODO: Have the movement speed increase or decrease based on the movement of the player.
/// </summary>

public class ObstacleMovement : MonoBehaviour
{
    [Header("Obstacle Movement Variables")]
    [Tooltip("Base Obstacle Speed")]
    public float moveSpeed; // A moveSpeed value of 3 mimics the speed the character would be moving.
    [Tooltip("Multiplies base speed")]
    public float speedMultiplier;

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 movement = new Vector3((moveSpeed*-1), 0.0f, 0.0f);
        transform.position += movement * (moveSpeed * speedMultiplier) * Time.deltaTime;
    }
}
