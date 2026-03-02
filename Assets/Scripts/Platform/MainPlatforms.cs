using System;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;


public class MainPlatforms : MonoBehaviour
{


    [SerializeField] private GameObject Platform;
    [SerializeField] private float disappearDelay = 3f;
    [SerializeField] private bool isTriggered = false;
    [Header("Timers")] [SerializeField] private float startingPlatTime;
    [SerializeField] private float currentTimer;
    private Coroutine countdownRoutine;
    [Header("Texts")] [SerializeField] private TextMeshProUGUI mainPlatforms;


    public void Start()
    {
      
        
        currentTimer = disappearDelay;
    }

    private void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isTriggered)
            {
                isTriggered = true;
                countdownRoutine = StartCoroutine(collisionCountdown());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isTriggered)
            {
                isTriggered = false;
                currentTimer += 1f;
            
                currentTimer = Mathf.Min(currentTimer, disappearDelay);
            }
          
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
                
                if (currentTimer <= 0)
                {
                    Destroy(gameObject);
                    mainPlatforms.gameObject.SetActive(false);
                    yield break;
                
                }
            }
            yield return null;
        }
            
    }
}
