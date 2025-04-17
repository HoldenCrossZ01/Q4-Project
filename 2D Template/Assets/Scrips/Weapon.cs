using UnityEngine;

public class Weapon : MonoBehaviour
{

public int atk;

    void OnCollisionEnter2D(Collision2D other) 
       {
          if (other.gameObject.CompareTag("Enemy"))
         {
             other.gameObject.GetComponent<EnemyStats>().health -= atk;
         }
       }
}
