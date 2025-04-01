using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class DOT : MonoBehaviour
{
    
    public int damageAmount = 0;   
    public int damageTime = 0; 

    public void DamageOverTime(int damageAmount, int damageTime)
    {
       // StartCoroutine(DamageOverTimeCoroutine(damageAmount, damageTime));
    }

    IEnumerator DamageOverTimeCoroutine(float damageAmount, float duration, playerHealth health)
    {
        float amountDamaged = 0;
        float damagePerLoop = damageAmount / duration;
        while (amountDamaged < damageAmount)
        {
            //currenthealth -= damagePerLoop;
            //Debug.Log(currentHealth.ToString());
            amountDamaged += damagePerLoop;
            health.health -= damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DamageOverTimeCoroutine(damageAmount, damageTime, other.gameObject.GetComponent<playerHealth>()));
        }

    }

}
