
using UnityEngine;

public class ObstaclesBehavior : MonoBehaviour
{
    // NEW: Reference to GameScript
    private GameScript gameScript;

    [SerializeField]
    private float _screenExit = -10.0f;

    [SerializeField]
    private Rigidbody2D barrierRigidBody;

    private void Start()
    {
        barrierRigidBody = GetComponent<Rigidbody2D>();
        gameScript = FindAnyObjectByType<GameScript>();
    }

    private void Update()
    {
        // CHANGED: Use shared speed from GameScript
        if (gameScript != null)
        {
            transform.Translate(
                Vector2.left * gameScript.currentSpeed * Time.deltaTime
            );
        }

        if (transform.position.x < _screenExit)
        {
            Destroy(gameObject);
        }
    }
}

