using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;

    // Update is called once per frame
    public void HandleAttack(InputAction.CallbackContext ctx)
    {
        if(timeBtwAttack <= 0)
        {
          //Collider2D[] enemiesToDamage = Physics2D.OverlapAreaAll(attackPos.position, attackRange, 0,
        }
    }
}
