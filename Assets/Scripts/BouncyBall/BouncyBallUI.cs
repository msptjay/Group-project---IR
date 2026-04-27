using UnityEngine;
using TMPro;

public class BouncyBallUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1ScoreText;
    [SerializeField] TextMeshProUGUI p2ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private TextMeshProUGUI timer;
    private float timerCountdown;
    public bool isEndFuncCalled = false;
    [SerializeField] BallSpawner bS;


    void Start()
    {
        isEndFuncCalled = false;
        timerCountdown = 45f;
       
    }

    // Update is called once per frame
    void Update()
    {
        timerCountdown -= Time.deltaTime;
        int displayTime = Mathf.CeilToInt(timerCountdown);
        timer.text = displayTime.ToString();
        if (timerCountdown <= 0f && isEndFuncCalled == false)
        {
            Debug.Log("Time's up!");
            bS.GameFinished();
            isEndFuncCalled = true;
        }
    }

    public void UpdateScore(int player1Score, int player2Score)
    {
        p1ScoreText.text = player1Score.ToString();
        p2ScoreText.text = player2Score.ToString();
    }
}
