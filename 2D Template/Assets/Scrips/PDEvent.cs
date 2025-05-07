using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PDEvent : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float sceneTransferTime;
    private bool startTransferTimer = false;

    public GameObject player;
    public float speed;
    private float distance;

    [SerializeField] private ParticleSystem boomParticle;
    private ParticleSystem boomParticleInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow player 
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        // Timer
      int minutes = Mathf.FloorToInt(sceneTransferTime / 60);
      int seconds = Mathf.FloorToInt(sceneTransferTime % 60);
      timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
      if (sceneTransferTime > 0 && startTransferTimer == true)
      {
        sceneTransferTime -= Time.deltaTime;
      }
      else if (sceneTransferTime < 0)
      {
        sceneTransferTime = 0;
        SceneManager.LoadScene("DeathScreen");
      }

      //Detect player death
      if (player.gameObject.GetComponent<playerHealth>().health <= 0)
      {
        DeathEvent();
      }
    }

    void DeathEvent()
    {
        startTransferTimer = true;
        //boomParticle.Play();
        Instantiate(boomParticle, transform.position, Quaternion.identity);
    }
    
}
