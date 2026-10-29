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

    [SerializeField]
    private int _maxJumps = 2; // Set to 2 for double jump (or 1 for single jump)
    private int _jumpsRemaining;

    private Animator _animator;
    private GameScript _gameScript;

    private void Start()
    {
        IS_ALIVE = true;
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _gameScript = FindAnyObjectByType<GameScript>();
        _jumpsRemaining = _maxJumps;

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

        // Reset available jumps whenever the zombie is back on the ground
        if (IS_GROUNDED)
        {
            _jumpsRemaining = _maxJumps;
        }

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
        // Allow jumping if we still have jumps remaining (e.g. 2 for ground jump + mid-air jump) and are alive
        if (_jumpsRemaining > 0 && IS_ALIVE && rb != null)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                _jumpHeight
            );
            _jumpsRemaining--; // Consume one jump count
        }

        if (Audio.Instance != null){
        Audio.Instance.PlayJump();
        }
    }
}
