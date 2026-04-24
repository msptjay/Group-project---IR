using System.Collections;
using TMPro;
using UnityEngine;

public class CountingResults : MonoBehaviour
{
    [SerializeField] GameObject CountingManager;
    [SerializeField] CountingManager cM;
    GameObject gameManager;
    GameManager gM;

    [SerializeField] TextMeshProUGUI p1CorrectNumber;
    [SerializeField] TextMeshProUGUI p2CorrectNumber;
    [SerializeField] TextMeshProUGUI p1Text;
    [SerializeField] TextMeshProUGUI p2Text;
    [SerializeField] TextMeshProUGUI winnerText;
    Animator animator;
    Animation anim;
    int p1IntToDisplay;
    int p2IntToDisplay;
    int gameWinner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gM = gameManager.GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        p1CorrectNumber.text = "x " + cM.p1CorrectCount.ToString();
        p2CorrectNumber.text = "x " + cM.p2CorrectCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreDisplay()
    {
        StartCoroutine(ScoreTick());
    }

    public void GetWinner(int playerWin)
    {
        gameWinner = playerWin;
    }
    // called from the animation
    public void DisplayWinner()
    {
        switch(gameWinner)
        {
            case 1:
                winnerText.text = "Player 1 Wins!";
                break;
            case 2:
                winnerText.text = "Player 2 Wins!";
                break;
            case 0:
                winnerText.text = "It's a Tie!";
                break;
        }
    }
    public void NextLevel()
    {
        if(gameWinner == 1)
        {
            gM.overallP1Score++;
            gM.LevelEnded(1, 0);
        }
        else if(gameWinner == 2)
        {
            gM.LevelEnded(0, 1);
        }
    }

        IEnumerator ScoreTick()
    {
        while (true)
        {
            if (p1IntToDisplay < cM.p1TotalCount)
            {
                p1IntToDisplay++;
                p1Text.text = "x " + p1IntToDisplay.ToString();
            }
            else if (p1IntToDisplay >= cM.p1TotalCount)
            {
                p1Text.text = "x " + p1IntToDisplay.ToString();
            }
            if (p2IntToDisplay < cM.p2TotalCount)
            {
                p2IntToDisplay++;
                p2Text.text = "x " + p2IntToDisplay.ToString();
            }
            else if (p2IntToDisplay >= cM.p2TotalCount)
            {
                p2Text.text = "x " + p2IntToDisplay.ToString();
            }

            yield return new WaitForSeconds(0.1f);
        }
    }    
}
