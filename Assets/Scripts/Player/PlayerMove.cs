using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public LayerMask groundLayers;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        groundedPlayer = isGrounded();
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);
        rigidbody.linearVelocity = move * Time.deltaTime * playerSpeed;

        Debug.Log(move + " " + rigidbody.linearVelocity);

        // Makes the player jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * 2.0f);
        }

        rigidbody.linearVelocityY += gravityValue * Time.deltaTime;
        rigidbody.linearVelocity = playerVelocity * Time.deltaTime;
    }

    private bool isGrounded()
    {
        RaycastHit2D hitGround;
        hitGround = Physics2D.CircleCast(Vector2.zero, 0.5f, Vector2.down, 0.1f, groundLayers);

        if (hitGround)
        {
            return true;
        }

        return false;
    }
}