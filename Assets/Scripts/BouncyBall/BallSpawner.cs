using System.Collections;
using UnityEngine;
using TMPro;
public class BallSpawner : MonoBehaviour
{
    GameObject gameManager;
    GameManager gM;

    [SerializeField] Rect rectangleSpawns;
    [SerializeField] GameObject ball;
    [SerializeField] BouncyBallUI bouncyBallUI;

    [SerializeField] int player1Score = 0;
    [SerializeField] int player2Score = 0;


    //Miles Code
    

    bool shouldSpawnBall = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gM = gameManager.GetComponent<GameManager>();

        StartCoroutine(SpawnBallCoroutine());
        for (int i = 0; i < 10; i++)
        {
            SpawnBall();
        }
    }

    // Update is called once per frame
   

    void SpawnBall()
    {
        Instantiate(ball, new Vector3(Random.Range(transform.position.x - 8, transform.position.x + 8), Random.Range(transform.position.y - 5, transform.position.y + 2), 0), transform.rotation);
    }

    IEnumerator SpawnBallCoroutine()
    {
        while (shouldSpawnBall)
        {
            SpawnBall();
            SpawnBall();
            SpawnBall();
            SpawnBall();
            yield return new WaitForSeconds(3f);
        }
    }

    public void AddScore(int whoScored)
    {
        if(whoScored == 1)
        {
            player1Score++;
        }
        if(whoScored == 2)
        {
            player2Score++;
        }

        bouncyBallUI.UpdateScore(player1Score, player2Score);
    }

    public void GameFinished()
    {
        gM.LevelEnded(player1Score, player2Score);
    }
}
