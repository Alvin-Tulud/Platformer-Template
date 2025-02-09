using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
