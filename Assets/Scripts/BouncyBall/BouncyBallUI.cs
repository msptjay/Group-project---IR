using UnityEngine;
using TMPro;

public class BouncyBallUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1ScoreText;
    [SerializeField] TextMeshProUGUI p2ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int player1Score, int player2Score)
    {
        p1ScoreText.text = "Player 1: " + player1Score;
        p2ScoreText.text = "Player 2: " + player2Score;
    }
}
