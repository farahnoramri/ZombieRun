using UnityEngine;

public class BarrierBehavior : MonoBehaviour
{
    [SerializeField]
    private float _barrierMovementSpeed = 5.0f;

    [SerializeField]
    private float _screenExit = -10.0f;

    [SerializeField]
    private Rigidbody2D barrierRigidBody;

    private void Start()
    {
        barrierRigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        transform.Translate(Vector2.left * _barrierMovementSpeed * Time.deltaTime);

        if (transform.position.x < _screenExit)
        {
            Destroy(gameObject);
        }
    }
}
