using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections;

public class Platforms : MonoBehaviour
{
    GameObject gameManager;
    GameManager gM;
    [Header("Objects")] [SerializeField] private GameObject[] platforms;
    
    [SerializeField] private GameObject startingPlatform;
    [SerializeField] private float disappearDelay = 3f;
    [SerializeField] private bool isTriggered = false;
    [Header("Timers")] [SerializeField] private float startingPlatTime;
    
    [SerializeField] private float mainTimer;
    [SerializeField] private PlayerHealth player;
    [Header("Texts")] [SerializeField] private TextMeshProUGUI mainPlatforms;
    
    [SerializeField] private TextMeshProUGUI platform1;

    public void Start()
    {
        //  gameManager = GameObject.FindWithTag("GameManager");
        //  gM = gameManager.GetComponent<GameManager>();
        mainTimer = 46f;
        startingPlatTime = 6f;
        StartCoroutine(startingCountdown());

    }


    public void Update()
    {
        if (player.HealthStatus() <= 0)
        {
            //  gM.LoadNextLevel();
        }
    }
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTriggered && collision.gameObject.tag == "Player")
        {
            isTriggered = true;
            StartCoroutine(collisionCountdown());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isTriggered && collision.gameObject.tag == "Player")
        {
            isTriggered = false;
        }
    }

    IEnumerator collisionCountdown()
        {
            while (true)
            {
                float timer = disappearDelay;
                while (timer > 0)
                {
                    timer -= Time.deltaTime;
                    yield return null;
                }

                if (timer <= 0)
                {
                    Destroy(gameObject);
                    yield return null;
                }
            }
            
     }
*/
    IEnumerator startingCountdown()
    {
        while (true)
        {
            float timer = startingPlatTime;
            float timer1 = mainTimer;
            
            while (timer > 0)
            {
               platform1.text = "Timer: " + Mathf.FloorToInt(timer);
                timer -= Time.deltaTime;
                yield return null;
            }
           
            Destroy(platform1);
            Destroy(startingPlatform);
            while (timer1 > 0)
            {
                mainPlatforms.text = "Timer: " + Mathf.FloorToInt(timer1);
                timer1 -= Time.deltaTime;
                if (timer1 <= 0)
                {
                    
                }
                yield return null;
            }
            


        }
        
    }
}
