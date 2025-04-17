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

    void Update()
    {
      attackPos.gameObject.GetComponent<Weapon>().atk = damage;

      if (remainingTime > 0)
      {
        remainingTime -= Time.deltaTime;
      }
      else if (remainingTime < 0)
      {
        remainingTime = 0;
      }
      if (remainingTime <= 0.85) 
      { 
        attackPos.gameObject.SetActive(false);
      }

      int minutes = Mathf.FloorToInt(remainingTime / 60);
      int seconds = Mathf.FloorToInt(remainingTime % 60);
      timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    
    public void HandleAttack(InputAction.CallbackContext ctx) 
    {
      if (remainingTime <= 0)
      {
        remainingTime += 1;
        attackPos.gameObject.SetActive(true);
      }
    }
    
    void OnDrawGizmosSelected() 
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
