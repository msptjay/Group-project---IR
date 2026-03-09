using System.Collections;
using UnityEngine;

public class CountingManager : MonoBehaviour
{
    [SerializeField] GameObject countingUIManager;
    [SerializeField] CountingUIManager cUIM;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] CountingPlayer cPP1;
    [SerializeField] CountingPlayer cPP2;
    int secondsLeft = 45;
    float targetTime = 1;

    [SerializeField] GameObject[] p1Objects;
    [SerializeField] GameObject[] p2Objects;
    int p1ObjectIndex;
    int p2ObjectIndex;
    int p1CorrectCount;
    int p2CorrectCount;
    int p1TotalCount;
    int p2TotalCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            secondsLeft--;
            cUIM.UpdateTimer(secondsLeft);
            targetTime = 1.0f;
            if (secondsLeft <= 0)
            {
                GameFinished();
            }
        }
    }

    IEnumerator SpawnLoop()
    {
        while (true)
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
        cUIM.UpdatePlayerCounting(1, p1TotalCount);
    }
    void GameFinished()
    {
        cPP1.shouldInput = false;
        cPP2.shouldInput = false;
        StopCoroutine(SpawnLoop());
    }

}
