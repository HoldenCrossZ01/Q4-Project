using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))] //Script can only be applied to GO's with rgbd2D
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    
    public float jumpHeight;
    private Rigidbody2D _rb;
    private Vector2 _moveAmount;
    private bool isJumping = false;
    

    void Awake()
    {
        //Unity prefers _rb to rb, and this section will grasp onto the rigidbody
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Apply the velocity to the Y axis
        

        //Apply the velocity to the X axis
        _rb.linearVelocityX = _moveAmount.x * movementSpeed;
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

            }
        }
        //if (ctx.ReadValue<float>()==1) 
        //{
        //  _rb.AddForce(Vector2.up * jumpHeight);
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

    }


}
JobParallelIndexListExtensions maksaed
    dd
    ]fdasd
    fasdfa
    sdfas
    dfasd
    fasd
    fasd
    fa
    sdf
    asd
    fa
    sdfal;sdkfal;skdflasdfkljasd;lkfjal;skjdfl;aksjdfl;kajsd;lfkja;lskdfjalksdjfl;kajsfkja;sldkfja;lksjf;laksjd;flasdlkfjalksdjflkasdlkajsdlkfjakkk`````````````````````````gfggggg```gg    `jiioioisdfupqowerufpoqiwufepoiqwuepfoiuq pwoeif uqoiweu fpoqiweu f0iqw eofiqwpoeif qpowief psdf;glksdsflkfams'd;lcv asldkcv asdfvca e
    sdrgfv[w 
    sedfg lw
    'e;drflg
    w's;efl g
    ';wer
    g';qwer
    gff;qwer
    gwq
    er';gw
    e'r;g
    w';erg
    'w;er
    g';we
    r';gfwe'rd;f
    a';d
    as
    AccelerationEventdas
    \df
    Asd
    fawsd
    'fqwer
    ]fwq3e fs]
    =Matrix4x4';dfslwkfjqrvcsdmaemwf    qwrqwe
    ]fsd