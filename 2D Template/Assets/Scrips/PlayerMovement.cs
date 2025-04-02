using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed_;
    public float jumpForce = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public LayerMask groundLayer;

    private Vector2 _moveDirection;
    private bool _isDashing;

    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference dash;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
                Debug.LogError("Rigidbody2D is missing from Player!");
        }
    }

    private void Update()
    {
        if (move == null || move.action == null)
        {
            Debug.LogError("Move InputActionReference is not assigned!");
            return;
        }
        _moveDirection = move.action.ReadValue<Vector2>();

        if (jump != null && jump.action != null && jump.action.triggered && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        //if (dash != null && dash.action != null && dash.action.IsPressed() && !_isDashing)
        //{
        //    StartDash();
        //}
    }

    //private void FixedUpdate()
    //{
    //    if (rb == null) return;
    //    if (!_isDashing)
    //    {
    //        rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed_, rb.linearVelocity.y);
    //    }
    //}

    //private void StartDash()
    //{
    //    _isDashing = true;
    //    rb.linearVelocity = new Vector2(transform.localScale.x * dashSpeed, rb.linearVelocity.y);
    //    Invoke(nameof(StopDash), dashDuration);
    //}

    //private void StopDash()
    //{
    //    _isDashing = false;
    //}

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
    }
}
