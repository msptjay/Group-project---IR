using System;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;


public class MainPlatforms : MonoBehaviour
{


    public int p1Score;
    public int p2Score;

    [SerializeField] private GameObject Platform;

    [SerializeField] private float disappearDelay = 3f;
    [SerializeField] private bool isTriggered = false;
    [Header("Timers")] [SerializeField] private float startingPlatTime;
    [SerializeField] private float currentTimer;
    private Coroutine countdownRoutine;
    Coroutine restoreRoutine;
    [Header("Texts")] [SerializeField] private TextMeshProUGUI mainPlatforms;


    public void Start()
    {
      
        currentTimer = disappearDelay;
    }

    private void Update()
    {
       mainPlatforms.text = Mathf.Floor(currentTimer).ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isTriggered)
            {
                isTriggered = true;
                if(restoreRoutine != null)
                {
                StopCoroutine(restoreRoutine);
                }
            if (countdownRoutine == null)
{
                 countdownRoutine = StartCoroutine(collisionCountdown());
}
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

                if(restoreRoutine != null)
                {
                StopCoroutine(restoreRoutine);
                }

            restoreRoutine = StartCoroutine(RestoreTimer());
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
                //mainPlatforms.text = "" + currentTimer;
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

    public void AddScore(int score, bool P1score)
    {
        if (P1score)
        {
            p1Score += score;
        }
        else
        {
            p2Score += score;
        }
        //pUIM.UpdateScores(p1Score, p2Score);
    }

    public void GameFinished()
    { 
       // gM.LevelEnded(p1Score, p2Score); 
    }
}
