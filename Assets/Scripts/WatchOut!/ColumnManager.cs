using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class ColumnManager : MonoBehaviour
{
    GameObject gameManager;
    GameManager gM;

    public int p1Score;
    public int p2Score;
    
    [Header("World stuff")] [SerializeField]
    private Transform[] columns;

    [SerializeField] private Collider2D[] playerSlots;
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private TextMeshProUGUI countdown;
    
    [SerializeField] private float timerCountdown;
    [SerializeField] private float timerCooldown;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private PlayerHealth player2;
    [SerializeField] private bool roundActive;
    [SerializeField] private bool inPlace = false;
    [SerializeField] private int ColumnPlace = -1;

    [SerializeField] private  PlayerInput playerInput;
    [SerializeField] private PlayerInput playerInput2;
    
    void Start()
    {
      gameManager = GameObject.FindWithTag("GameManager");
      gM = gameManager.GetComponent<GameManager>();
      Time.timeScale = 0f;
      StartRound();
      timerCountdown = 6f;
      StartCoroutine(Countdown());
      
       
    }

    private void Update()
    {
        if (!roundActive) return;

        if (player.HealthStatus() <= 0 || player2.HealthStatus() <= 0)
        {
            gM.LoadNextLevel();
        }

    }

    

    IEnumerator Countdown()
    {
        while (true)
        {
            float timer = timerCountdown;
            playerInput.ActivateInput();
            playerInput2.ActivateInput();
            while (timer > 0)
            {
                countdown.text = "Timer: " + Mathf.FloorToInt(timer); 
                timer -= Time.deltaTime;
                yield return null;
            }

            countdown.text = "Incoming!";
            playerInput.DeactivateInput();
            playerInput2.DeactivateInput();
            SpawnBranchAndFruit();

            yield return new WaitForSeconds(2.5f);
        }
    }

    public void PlaceChecker()
    {
        inPlace = true;
    }

    public void PlayerLeftSlot()
    {
        inPlace = false;
    }
    
    public bool IsPlayerInPlace()
    {
        return inPlace;
    }

    public void StartRound()
    {
        roundActive = true;
        inPlace = false;
    }

    public void SetPlayerSlot(int slotIndex)
    {
        if (roundActive) 
        {
            ColumnPlace = slotIndex;
            Debug.Log("Player currently in slot: " + ColumnPlace);
        }
    }

public void LockedInSpot(int column)
    {
        if (!roundActive)
        {
            ColumnPlace = column;
        }
    }
    
    private void SpawnBranchAndFruit()
    {
        int randomColumn = Random.Range(0, columns.Length);
        for (int i = 0; i < columns.Length; i++)
        {
            if (i == randomColumn)
            {
                // Spawn branch in the chosen column
                Instantiate(branchPrefab, columns[i].position, Quaternion.identity);
                
            }
            else
            {
                // Spawn fruit in all other columns
                Instantiate(fruitPrefab, columns[i].position, Quaternion.identity);
               
            }
        }

        Debug.Log("Spawned branch and fruits");
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
       // wUIM.UpdateScores(p1Score, p2Score);
    }

    public void GameFinished()
    { 
        gM.LevelEnded(p1Score, p2Score); 
    }
}
