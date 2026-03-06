using UnityEngine;
using TMPro;
using System.Collections;
public class RaceManager : MonoBehaviour
{
    [SerializeField] private GameObject finishLineP1;
    [SerializeField] private GameObject finishLineP2;
    [SerializeField] private float endGameTimer;
    [SerializeField] private TextMeshProUGUI timerText;


    private void Awake()
    {
        endGameTimer = 45f;
    }

    private void Update()
    {
        endGameTimer -= Time.deltaTime;
        timerText.text = "Timer: " + endGameTimer;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }

    }    
}
