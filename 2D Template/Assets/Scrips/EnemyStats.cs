using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
