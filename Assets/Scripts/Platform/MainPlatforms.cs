using UnityEngine;
using TMPro;
using System.Collections;
public class MainPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private float disappearDelay = 3f;
    [SerializeField] private bool isTriggered = false;
    [Header("Timers")] [SerializeField] private float startingPlatTime;
    
    [SerializeField] private float mainTimer;

    [Header("Texts")] [SerializeField] private TextMeshProUGUI mainPlatforms;
    
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
        float timer = disappearDelay;

        while (isTriggered)  
        {
            timer -= Time.deltaTime;
            mainPlatforms.text = "" + timer;
            if (timer <= 0)
            {
                Destroy(gameObject);
                yield break;
                
            }

            yield return null;
        }
            
    }
}
