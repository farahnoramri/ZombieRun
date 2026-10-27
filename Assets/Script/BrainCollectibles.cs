using UnityEngine;

public class BrainCollectible : MonoBehaviour
{
    private GameScript gameScript;

    private void Start()
    {
        gameScript = FindAnyObjectByType<GameScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // NEW: Detect zombie collision
        if (other.CompareTag("Player"))
        {
            if (gameScript != null)
            {
                gameScript.CollectBrain();
            }

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (gameScript != null)
        {
            transform.Translate(
                Vector2.left * gameScript.currentSpeed * Time.deltaTime,
                Space.World
            );
        }

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}

