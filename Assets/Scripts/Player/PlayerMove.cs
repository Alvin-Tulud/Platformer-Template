using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool holdMove;
    private float direction;
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
        if (holdMove)
        {
            rb.linearVelocityX = playerSpeed * direction;
        }

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

    public void InputMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            holdMove = true;
            direction = Mathf.Floor(context.ReadValue<Vector2>().x);
        }
        else if (context.canceled)
        {
            holdMove = false;
        }
    }

    public void InputJump(InputAction.CallbackContext context)
    {
        if (context.action.triggered && isGrounded())
        {
            rb.linearVelocityY = jumpHeight;
        }
    }
}