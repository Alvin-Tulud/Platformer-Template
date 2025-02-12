using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask groundLayers;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityScale = 1.0f;
    private const float gravityValue = -9.81f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        InputMove();
        InputJump();

        if (rb.linearVelocityX == 0)
        {
            rb.linearVelocityX = 0;
        }

        rb.linearVelocityY += gravityValue * gravityScale * Time.fixedDeltaTime;
    }

    private bool isGrounded()
    {
        RaycastHit2D onGround;
        onGround = Physics2D.CircleCast(transform.position, 0.4f, Vector2.down, 0.2f, groundLayers);

        if (onGround)
        {
            return true;
        }

        return false;
    }

    public void InputMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = playerSpeed * Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = playerSpeed * Vector2.left;
        }
    }

    public void InputJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rb.linearVelocityY = jumpHeight;
        }
    }
}