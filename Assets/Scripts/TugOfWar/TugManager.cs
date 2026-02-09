using UnityEngine;
using System.Collections.Generic;

public class TugManager : MonoBehaviour
{
    public float targetTime = 6.0f;
    //0= up, 1= down, 2= left, 3= right
    [SerializeField] int buttonInput;
    bool hasPlayerAnsweredCorrect = false;
    bool shouldTimerRun = true; 
    //public int player1Input;


    void Update()
    {
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
        buttonInput = Random.Range(0, 4);
        Debug.Log("Button " + buttonInput + " was selected!");

        if(targetTime <= -4f)
        {
            Debug.Log("Too Slow !!!");
            targetTime = 6.0f;
            shouldTimerRun = true;
        }
    }

    public void PlayerInput(int playerNumber, int input)
    {
        switch (playerNumber)
        {
            case 1:
                if (!hasPlayerAnsweredCorrect)
                {
                    if (input == buttonInput)
                    {
                        Debug.Log("Player 1 is correct!");
                        targetTime = 6.0f;
                        hasPlayerAnsweredCorrect = true;
                    }
                    else
                    {
                        Debug.Log("Player 1 is wrong!");
                    }
                }
                break;
            case 2:
                if (!hasPlayerAnsweredCorrect)
                {
                    if (input == buttonInput)
                    {
                        Debug.Log("Player 2 is correct!");
                        targetTime = 6.0f;
                        hasPlayerAnsweredCorrect = true;
                    }
                    else
                    {
                        Debug.Log("Player 2 is wrong!");
                    }
                }
                break;
            default:
                Debug.Log("something went REALLY wrong??");
                break;
        }
    }

}
