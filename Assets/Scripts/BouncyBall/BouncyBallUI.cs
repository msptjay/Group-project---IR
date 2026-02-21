using UnityEngine;
using TMPro;

public class BouncyBallUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1ScoreText;
    [SerializeField] TextMeshProUGUI p2ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private float timerCountdown;
    [SerializeField] GameManager gm;

    void Start()
    {
        timerCountdown = 45f;
       
    }

    // Update is called once per frame
    void Update()
    {
        timerCountdown -= Time.deltaTime;
        timer.text = "Timer : " + timerCountdown;
        if (timerCountdown <= 0f)
        {
            gm.LoadNextLevel();
        }
    }

    public void UpdateScore(int player1Score, int player2Score)
    {
        p1ScoreText.text = "Player 1: " + player1Score;
        p2ScoreText.text = "Player 2: " + player2Score;
    }
}
