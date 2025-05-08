using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))] //Script can only be applied to GO's with rgbd2D
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float dashPower;
    public int dashStamCost;
    public float jumpHeight;
    private Rigidbody2D _rb;
    private Vector2 _moveAmount;
    private bool isJumping = false;
    private bool facingRight;
    

    void Awake()
    {
        //Unity prefers _rb to rb, and this section will grasp onto the rigidbody
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Apply the velocity to the X axis
        _rb.linearVelocityX = _moveAmount.x * movementSpeed;

         if(_rb.linearVelocity.x < 0 && facingRight) 
        {
           Flip();
        }
        else if(_rb.linearVelocity.x > 0 && !facingRight) 
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    //This function will read our movement input and apply it to apply to a variable inside the script
    public void HandleMovement(InputAction.CallbackContext ctx)
    {
        _moveAmount = ctx.ReadValue<Vector2>();


    }
    public void HandleJump(InputAction.CallbackContext ctx)
    {
        if (isJumping == false)
        {
            if (ctx.ReadValue<float>() == 1)
            {

                _rb.AddForce(Vector2.up * jumpHeight);
                isJumping = true;

                FindFirstObjectByType<AudioManager>().PlaySFX(jump);
            }
        }
       
    }

    [Header("SFX")]
    [SerializeField] private AudioClip jump;


    public void HandleDash(InputAction.CallbackContext ctx)
    {
        if (gameObject.GetComponent<playerHealth>().stam > 0)
        {

            if (_moveAmount.x > 0)
            {
                _rb.linearVelocity = Vector2.right * dashPower;
                gameObject.GetComponent<playerHealth>().stam -= dashStamCost;

            }
            else
            {
                _rb.linearVelocity = Vector2.left * dashPower;
                gameObject.GetComponent<playerHealth>().stam -= dashStamCost;
            }

        }
       


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}