using TMPro;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1ScoreText;
    [SerializeField] TextMeshProUGUI p2ScoreText;
    // [SerializeField] TextMeshProUGUI timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScores(int pNumber, int pScore)
    {
        if (pNumber == 1)
        {
            p1ScoreText.text = pScore.ToString();
        }
        else if (pNumber == 2)
        {
            p2ScoreText.text = pScore.ToString();
        }
    }
}
