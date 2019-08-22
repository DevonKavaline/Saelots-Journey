using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <TODO>
/// Fix jump counter reset. see Jumpcheck function
/// </TODO>
public class JumpAbility : MonoBehaviour
{

    [Header("Character Jump Variables")]
    [Tooltip("Height of Character's Jump")]
    public float jumpspeed = 10.0f;
    [Tooltip("Forward Momentum of Character Jumps")]
    public float fowardSpeed = 2;
    [Tooltip("Current times the Character can jump before touching the ground")]
    public int currentJumpCount = 2;
    [Tooltip("Max Times the character can jump before touching the ground")]
    public int maxJumpCount = 2;
    [Tooltip("Button to jump")]
    public string jumpButton;
    private bool canJump;
    [Tooltip("How fast the character falls")]
    public float fallMultiplier = 2.5f;
    [Tooltip("fa")]
    public float lowJumpMultiplier = 2.0f;

    private Rigidbody rb;
    private float distanceToGround;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialReferences();
    }

    // Update is called once per frame
    void Update()
    {
        JumpCheck();
        ApplyGravity();
        if (Input.GetButtonDown(jumpButton) && currentJumpCount > 0 && canJump)
        {
            Jump();
        }
        ///Debug.Log(distanceToGround.ToString());
    }
    public void Jump()
    {
        rb.velocity = new Vector3(transform.position.x < 0 ? fowardSpeed : 0, jumpspeed);
        currentJumpCount--;
    }
    public void JumpCheck()
    {
        if (!Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.00001f) && currentJumpCount > 0)
        {
            canJump = true;
        }
        else if (!Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.00001f) && currentJumpCount <= 0)
        {
            canJump = false;
        }
        else ///Something here is causing the player to not regain jumps if landing on rocks.
        {
            canJump = true;
            currentJumpCount = maxJumpCount;
        }
    }
    public void ApplyGravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButtonDown(jumpButton))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    public void SetInitialReferences()
    {
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }
}
