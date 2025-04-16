using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public int attackRange;
    public int damage;

    public LayerMask whatIsEnemies;

    // Update is called once per frame
    public void HandleAttack(InputAction.CallbackContext ctx)
    {
        if(timeBtwAttack <= 0)
        {
          Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, whatIsEnemies, attackRange);
          for (int i = 0; i < enemiesToDamage.Length; i++) 
          {
            enemiesToDamage[i].GetComponent<EnemyStats>().health -= damage;
          }
          timeBtwAttack = startTimeBtwAttack;
        }
        else 
        {
          timeBtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected() 
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
