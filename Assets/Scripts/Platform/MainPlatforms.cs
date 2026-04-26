using System;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;


public class MainPlatforms : MonoBehaviour
{
    //[SerializeField] private GameObject Platform;

    [SerializeField] private float disappearDelay = 3f;
    [SerializeField] private bool isTriggered = false;

    [Header("Timers")] 
    [SerializeField] private float startingPlatTime;
    [SerializeField] private float currentTimer;
    private Coroutine countdownRoutine;
    Coroutine restoreRoutine;

    [Header("Texts")] 
    [SerializeField] private TextMeshProUGUI mainPlatforms;
    bool isCollision = false;

    private float maxLifetime = 2f;
    [SerializeField] bool shouldRegenerate = false;
    private float currentHealth = 2f;
    [SerializeField] bool isRespawnPlatform = true;
    private float regenCooldown = 2f;
    public void Start()
    {
        //SETS THE VARIABLES FOR THE RESPAWN PLATFORM (ITS TEXT/LIFE ETC ETC)
        if(isRespawnPlatform)
        {
            mainPlatforms = GameObject.FindGameObjectWithTag("RespawnPlatformTimer").GetComponent<TextMeshProUGUI>();
            maxLifetime = 1.6f;
            currentHealth = maxLifetime;
            mainPlatforms.text = "";
        }

        currentTimer = disappearDelay;
        StartCoroutine(RegeneratePlatform());
    }

    private void Update()
    {
        //RESPAWN PLATFORM SPECIFICS
        if (isRespawnPlatform)
        {
            isCollision = true;
        }
        //SETS THE COLOR OF THE PLATFORM TO BE MORE TRANSPARENT AS IT LOSES HEALTH
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, currentHealth / maxLifetime);
        //TEXT SETTER
        mainPlatforms.text = currentHealth.ToString("F1");
        if (isCollision)
        {
            // Stop regeneration if the platform is being stood on
            shouldRegenerate = false;
            currentHealth -= Time.deltaTime;
            // If the platform's health reaches zero, disable its sprite and collider
            if (currentHealth <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
                mainPlatforms.text = ""; 
            }
        }
        //If the platform isn't dead, restore it's health
        if (currentHealth >= 0.1f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;
            
            //mainPlatforms.text = Mathf.Floor(currentHealth).ToString("F2");
        }
        else
        {
            mainPlatforms.text = "";
        }
        //if(currentHealth >= 1f)
        //{
        //    shouldRegenerate = false;
        //}
        if(currentHealth <= 1f && !isCollision)
        {
            shouldRegenerate = true;
        }

        if (currentHealth >= 2)
        {
            currentHealth = 2;
        }
        if(!isCollision)
        {
            regenCooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
//            if (!isTriggered)
//            {
//                isTriggered = true;
//                if(restoreRoutine != null)
//                {
//                StopCoroutine(restoreRoutine);
//                }
//            if (countdownRoutine == null)
//{
//                 countdownRoutine = StartCoroutine(collisionCountdown());
//}
//            }
            currentHealth -= 0.25f;
            isCollision = true;
            regenCooldown = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            //if (isTriggered)
            //{
            //    isTriggered = false;

            //    if(restoreRoutine != null)
            //    {
            //    StopCoroutine(restoreRoutine);
            //    }

            //restoreRoutine = StartCoroutine(RestoreTimer());
            //}
          isCollision = false;
        }
    }

    IEnumerator RegeneratePlatform()
    {
        while (true)
        {
            while (shouldRegenerate)
            {
                if (regenCooldown <= 0)
                {
                    currentHealth += 0.1f;
                }

                yield return new WaitForSeconds(1f);
                //yield return new WaitForSeconds(0.75f);
                //if (currentHealth >= maxLifetime)
                //{
                //    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                //    gameObject.GetComponent<Collider2D>().enabled = true;

                //    shouldRegenerate = false;
                //}
                //else
                //{
                //    currentHealth += 0.1f;
                //}

            }
            yield return null;

        }
    
    }
    IEnumerator collisionCountdown()
    {
       

        while (currentTimer > 0) 
        {
            if (isTriggered)
            {
                currentTimer -= Time.deltaTime;
                mainPlatforms.text = "" + currentTimer;
            }
            
            if (currentTimer <= 0)
            {
              Destroy(gameObject);
              mainPlatforms.gameObject.SetActive(false);
              countdownRoutine = null;
             yield break;
                
            }
            
            yield return null;
        }
            
    }
    IEnumerator RestoreTimer()
{
    yield return new WaitForSeconds(3f);
    if (!isTriggered)
    {
       currentTimer = Mathf.Min(currentTimer + 1f, disappearDelay);
    }
    
    restoreRoutine = null;
    
}

   
}
