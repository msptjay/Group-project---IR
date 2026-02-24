using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlinkoManager : MonoBehaviour
{
    GameObject gameManager;
    GameManager gM;

    float spawnTime = 5;
    float difficultyRamp = 0;
    [SerializeField] Transform[] berrySpawns;
    [SerializeField] GameObject[] Berries;
    [SerializeField] GameObject plinkoUIManager;
    [SerializeField] PlinkoUIManager pUIM;
    int secondsLeft = 45;
    float targetTime = 1;

    public int p1Score;
    public int p2Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gM = gameManager.GetComponent<GameManager>();
        Time.timeScale = 0f;
        StartCoroutine(SpawnBerry());
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            secondsLeft--;
            pUIM.UpdateTimer(secondsLeft);
            targetTime = 1.0f;
            if(secondsLeft <= 0)
            {
                GameFinished();
            }
        }

    }

    IEnumerator SpawnBerry()
        {
        while (true)
        {
            Instantiate(Berries[Random.Range(0,2)], (berrySpawns[Random.Range(0,2)].position), Quaternion.identity);
            Instantiate(Berries[Random.Range(2,4)], (berrySpawns[Random.Range(2,4)].position), Quaternion.identity);
            difficultyRamp += 0.5f;
            if (difficultyRamp % 1 == 0 && spawnTime > 2)
                spawnTime -= 0.75f;
            
            yield return new WaitForSeconds(spawnTime);
        }
    }
    public void AddScore(int score, bool P1score)
    {
        if (P1score)
        {
            p1Score += score;
        }
        else
        {
            p2Score += score;
        }
        pUIM.UpdateScores(p1Score, p2Score);
    }

    public void GameFinished()
    { 
        gM.LevelEnded(p1Score, p2Score); 
    }
}
