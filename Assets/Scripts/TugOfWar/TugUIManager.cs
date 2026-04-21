using TMPro;
using UnityEngine;

public class TugUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1ScoreText;
    [SerializeField] TextMeshProUGUI p2ScoreText;
    [SerializeField] TextMeshProUGUI timerText;
    // [SerializeField] TextMeshProUGUI timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScores(int p1Score, int p2Score)
    {
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();
    }

    public void UpdateTimer(float time)
    {
        if(time < 0)
            time = 0;
        timerText.text = time.ToString("F2");
    }
}
