using TMPro;
using UnityEngine;

public class ScoreShow : MonoBehaviour
{
    GameObject gameManager;
    GameManager gM;

    [SerializeField] TextMeshProUGUI p1ScoreText;
    [SerializeField] TextMeshProUGUI p2ScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gM = gameManager.GetComponent<GameManager>();
        p1ScoreText = GameObject.FindWithTag("P1OverallScore").GetComponent<TextMeshProUGUI>();
        p2ScoreText = GameObject.FindWithTag("P2OverallScore").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        p1ScoreText.text = gM.overallP1Score.ToString();
        p2ScoreText.text = gM.overallP2Score.ToString();
    }
}
