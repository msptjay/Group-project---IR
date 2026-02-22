using UnityEngine;
using System.Collections.Generic;

public class TugManager : MonoBehaviour
{
    public float targetTime = 6.0f;

    //0= up, 1= down, 2= left, 3= right
    [SerializeField] int buttonInput;
    bool hasPlayerAnsweredCorrect = false;
    bool shouldTimerRun = true;
    [SerializeField] Sprite[] arrowSprites;
    [SerializeField] GameObject arrowSpawnPoint;
    SpriteRenderer arrowSpriteRenderer;
    bool hasPlayer1Answered = false;
    bool hasPlayer2Answered = false;

    [SerializeField] int player1Score;
    [SerializeField] int player2Score;

    private void Start()
    {
        arrowSpriteRenderer = arrowSpawnPoint.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //timer for picking an random button
        if (shouldTimerRun)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                shouldTimerRun = false;
                timerEnded();
            }
        }
    }

    void timerEnded()
    {
        hasPlayerAnsweredCorrect = false;
        //pick a random button input
        buttonInput = Random.Range(0, 4);
        Debug.Log("Button " + buttonInput + " was selected!");
        SpawnIcon();

        //if the players are REALLY terrible, they're too slow and it resets the timer and starts again
        if (targetTime <= -4f)
        {
            Debug.Log("Too Slow !!!");
            targetTime = 6.0f;
            shouldTimerRun = true;
        }
    }

    public void PlayerInput(int playerNumber, int input)
    {
        //BIG switch statement 
        switch (playerNumber)
        {
            //if player 1 answers do this
            case 1:
                if (!hasPlayerAnsweredCorrect)
                {
                    //if correct?
                    if (input == buttonInput)
                    {
                        Debug.Log("Player 1 is correct!");
                        targetTime = 6.0f;
                        hasPlayerAnsweredCorrect = true;
                        hasPlayer1Answered = true;
                        shouldTimerRun = true;
                        player1Score++;
                    }
                    //if wrong?
                    else
                    {
                        hasPlayer1Answered = true;
                        Debug.Log("Player 1 is wrong!");
                    }
                }
                break;
            //if player 2 answers do this
            case 2:
                if (!hasPlayerAnsweredCorrect)
                {
                    //if correct?
                    if (input == buttonInput)
                    {
                        Debug.Log("Player 2 is correct!");
                        targetTime = 6.0f;
                        hasPlayerAnsweredCorrect = true;
                        hasPlayer2Answered = true;
                        shouldTimerRun = true;
                        player2Score++;
                    }
                    //if wrong
                    else
                    {
                        hasPlayer2Answered = true;
                        Debug.Log("Player 2 is wrong!");
                    }
                }
                break;
            default:
                Debug.Log("something went REALLY wrong??");
                break;
        }

        if(hasPlayer1Answered && hasPlayer2Answered)
        {
            hasPlayer1Answered = false;
            hasPlayer2Answered = false;
            targetTime = 6.0f;
            shouldTimerRun = true;
        }
    }

    void SpawnIcon()
    {
        switch(buttonInput)
        {
            case 0:
                arrowSpriteRenderer.sprite = arrowSprites[0];
                break;
            case 1:
                arrowSpriteRenderer.sprite = arrowSprites[1];
                break;
            case 2:
                arrowSpriteRenderer.sprite = arrowSprites[2];
                break;
            case 3:
                arrowSpriteRenderer.sprite = arrowSprites[3];
                break;
            default:
                Debug.Log("something went REALLY wrong??");
                break;
        }
    }
}
