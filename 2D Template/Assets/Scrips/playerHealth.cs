using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    
    public float stam;
    public float maxStam;
    public Image stamBar;

    void Start()
    {
        health = maxHealth;

        stam = maxStam;
    }
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if(health <= 0)
        {
            //PlayerDeathEvent();
            gameObject.SetActive(false);
        }
        stamBar.fillAmount = Mathf.Clamp(stam / maxStam, 0, 1);
    }
}
