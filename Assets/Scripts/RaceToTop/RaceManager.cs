using UnityEngine;
using TMPro;
using System.Collections;
public class RaceManager : MonoBehaviour
{

    public int p1Score;
    public int p2Score;

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

        if(endGameTimer <= 0)
        {
            GameFinished();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You suck!");
        }

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
       // pUIM.UpdateScores(p1Score, p2Score);
    }

    public void GameFinished()
    { 
     //   gM.LevelEnded(p1Score, p2Score); 
    }
}
