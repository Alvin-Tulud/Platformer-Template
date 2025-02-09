using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagWin : MonoBehaviour
{
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
