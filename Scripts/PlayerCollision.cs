using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverScreen; // Assign your game over screen UI in the Inspector
    public float shrinkDuration = 0.5f; // Duration of shrinking effect
    public float destroyDelay = 1f; // Delay before destroying the player

    [SerializeField] private bool gameIsOver = false; // Now visible in the Inspector

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") && !gameIsOver)
        {
            gameIsOver = true;
            StartCoroutine(HandlePlayerDeath());
        }
    }

    private IEnumerator HandlePlayerDeath()
    {
        // Stop any movement or actions by disabling the Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        // Shrink the player over time
        Vector3 originalScale = transform.localScale;
        float timer = 0;
        while (timer < shrinkDuration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, timer / shrinkDuration);
            yield return null;
        }

        // Show game over screen and stop score
        gameOverScreen.SetActive(true);
        FindObjectOfType<ScoreManager>().StopScore();

        // Wait before resetting
        yield return new WaitForSeconds(4f);

        // Restart the game using GameManager
        GameManager.instance.RestartGame();

        // Destroy the player after shrinking
        Destroy(gameObject, destroyDelay);

    }

}
