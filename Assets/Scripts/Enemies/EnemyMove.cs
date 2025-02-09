using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direction;
    public float EnemySpeed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float randDirection = Random.Range(-1.0f, 2.0f);
        direction = Mathf.Pow(randDirection,0);
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity == Vector2.zero)
        {
            rb.linearVelocityX = 0;
            direction = -direction;
        }

        rb.linearVelocityX = EnemySpeed * direction;
    }
}
