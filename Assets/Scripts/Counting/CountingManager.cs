using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class CountingManager : MonoBehaviour
{
    [SerializeField] GameObject countingUIManager;
    [SerializeField] CountingUIManager cUIM;
    [SerializeField] GameObject ResultsDisplay;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] CountingPlayer cPP1;
    [SerializeField] CountingPlayer cPP2;
    int secondsLeft = 10;
    float targetTime = 1;

    [SerializeField] GameObject[] p1Objects;
    [SerializeField] GameObject[] p2Objects;
    int p1ObjectIndex;
    int p2ObjectIndex;
    public int p1CorrectCount;
    public int p2CorrectCount;
    public int p1TotalCount;
    public int p2TotalCount;
    bool endFlag = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f && !endFlag)
        {
            secondsLeft--;
            cUIM.UpdateTimer(secondsLeft);
            targetTime = 1.0f;
            if (secondsLeft <= 0 && !endFlag)
            {
                GameFinished();
            }
        }
    }

    IEnumerator SpawnLoop()
    {
        while (!endFlag)
        {
            P1ObjectSpawn();
            P2ObjectSpawn();
            yield return new WaitForSeconds(Random.Range(0.01f, 0.25f));
        }
    }

    void P1ObjectSpawn()
    {
        p1ObjectIndex = Random.Range(0, 3);
        if (p1ObjectIndex == 0)
            p1CorrectCount++;
        Instantiate(p1Objects[p1ObjectIndex], new Vector2(Random.Range(-2f, -8.5f), 6), Quaternion.identity);
            
    }
    void P2ObjectSpawn()
    {
        p2ObjectIndex = Random.Range(0, 3);
        if (p2ObjectIndex == 0)
            p2CorrectCount++;
        Instantiate(p2Objects[p1ObjectIndex], new Vector2(Random.Range(2f, 8.5f), 6), Quaternion.identity);
    }
    public void p1Count()
    {
        p1TotalCount++;
        cUIM.UpdatePlayerCounting(1, p1TotalCount);
    }
    public void p2Count()
    {
        p2TotalCount++;
        cUIM.UpdatePlayerCounting(2, p2TotalCount);
    }
    void GameFinished()
    {
        endFlag = true;
        cPP1.shouldInput = false;
        cPP2.shouldInput = false;
        int p1Difference = FindDifference(p1TotalCount, p1CorrectCount);
        int p2Difference = FindDifference(p2TotalCount, p2CorrectCount);
        if (p1Difference < p2Difference)
        {
            ResultsDisplay.GetComponent<CountingResults>().GetWinner(1);
            Debug.Log("Player 1 Wins!");
            //game manager p1 win
        }
        if(p2Difference < p1Difference)
        {
            ResultsDisplay.GetComponent<CountingResults>().GetWinner(2);
            Debug.Log("Player 2 Wins!");
            //game manager p2 win
        }
        if(p2Difference == p1Difference)
        {
            ResultsDisplay.GetComponent<CountingResults>().GetWinner(0);
            Debug.Log("It's a tie!");
            //game manager tie
        }
        ResultsDisplay.SetActive(true);
    }
     
    int FindDifference(int totalCount, int correctCount)
    {
        return Mathf.Abs(totalCount - correctCount);
    }
}
