using UnityEngine;
using UnityEngine.InputSystem;

public class ZombieBehavior: MonoBehaviour
{
    public bool IS_ALIVE = true;
    private bool IS_GROUNDED;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float _jumpHeight = 10.0f;

    [SerializeField]
    private float _rayLength = 1.0f;

    [SerializeField]
    private LayerMask _groundLayer;
    private Animator _animator;
    private GameScript _gameScript;
    private void Start()
    {

        Time.timeScale = 1.0f;
        IS_ALIVE = true;
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _gameScript = FindAnyObjectByType<GameScript>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the GameObject.");
        }

        if(_gameScript == null)
        {
            Debug.LogError("GameScript not found in the scene.");
        }
    }
    
    private void FixedUpdate()
    {
        RaycastHit2D playerRaycast = Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _groundLayer);
        IS_GROUNDED = playerRaycast.collider != null;

        Debug.Log("Is Grounded: " + IS_GROUNDED);

        Debug.DrawRay(transform.position, Vector2.down * _rayLength, Color.yellow);

        if(_animator != null)
        {
            _animator.SetBool("IsJumping", !IS_GROUNDED);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Barrier hit!");
            IS_ALIVE = false;
            _gameScript.GameOver();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PerformJump();
        }
    }

    public void MobileJump()
    {
        PerformJump();
    }
    private void PerformJump()
    {
        if (IS_GROUNDED && IS_ALIVE && rb != null)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                _jumpHeight
            );
        }
    }


}
