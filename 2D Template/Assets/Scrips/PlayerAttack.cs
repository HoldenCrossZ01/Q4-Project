using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerAttack : MonoBehaviour
{

   public TextMeshProUGUI timerText;
   public float remainingTime;

    public Transform attackPos;
    public float attackRange;
    public int damage;
    private bool canAttack = true;

   
    void Update()
    {
       int minutes = Mathf.FloorToInt(remainingTime / 60);
      int seconds = Mathf.FloorToInt(remainingTime % 60);
      timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

      attackPos.gameObject.GetComponent<Weapon>().atk = damage;

      if (remainingTime > 0)
      {
        remainingTime -= Time.deltaTime;
      }
      else if (remainingTime < 0)
      {
        remainingTime = 0;
      }



      if (remainingTime <= 0.13) 
      { 
        attackPos.gameObject.SetActive(false);
      }
      if (remainingTime <= 0) 
      { 
        canAttack = true;
      }
    }

    
    public void HandleAttack(InputAction.CallbackContext ctx) 
    {
      if (canAttack == true)
      {
        remainingTime += 0.30f;
        attackPos.gameObject.SetActive(true);
        canAttack = false;
        
      }
    }
    
    void OnDrawGizmosSelected() 
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
