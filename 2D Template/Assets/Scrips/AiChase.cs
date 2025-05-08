using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float distanceBetween = 4f;
    public float damage = 10f;
    public float damageCooldown = 1f; // Seconds between hits

    private float lastDamageTime;

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween)
        {
            // Move toward the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            // Deal damage if enough time has passed
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    lastDamageTime = Time.time;
                }
            }
        }
    }
}
