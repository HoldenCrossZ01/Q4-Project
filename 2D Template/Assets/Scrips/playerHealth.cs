using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Image healthBar;

    public float stam;
    public float maxStam;
    public Image stamBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;

        stam = maxStam;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        stamBar.fillAmount = Mathf.Clamp(stam / maxStam, 0, 1);

    }
}
