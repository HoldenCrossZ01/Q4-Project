using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class playerHealth : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float sceneTransfer;
    private bool startTransferTimer = false;

    [SerializeField] private ParticleSystem boomParticle;
    private ParticleSystem boomParticleInstance;

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

        sceneTransfer = 60;
    }
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if(health <= 0)
        {
            PlayerDeathEvent();
        }

        stamBar.fillAmount = Mathf.Clamp(stam / maxStam, 0, 1);

      int minutes = Mathf.FloorToInt(sceneTransfer / 60);
      int seconds = Mathf.FloorToInt(sceneTransfer % 60);
      timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

      

      if (sceneTransfer > 0 && startTransferTimer == true)
      {
        sceneTransfer -= Time.deltaTime;
      }
      else if (sceneTransfer < 0)
      {
        sceneTransfer = 0;
        SceneManager.LoadScene("DeathScreen");
      }
    }
    void PlayerDeathEvent()
    {
        Destroy(gameObject);
        //Camera shake, once accomplished
        boomParticle.Play();
        startTransferTimer = true;

    }

    

}
