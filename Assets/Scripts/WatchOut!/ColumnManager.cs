using UnityEngine;
using System.Collections;
using TMPro;

public class ColumnManager : MonoBehaviour
{
    [Header("World stuff")] [SerializeField]
    private Transform[] columns;

    [SerializeField] private Collider2D[] playerSlots;
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private TextMeshProUGUI countdown;

//    [SerializeField] private TextMeshProUGUI playerHealth1;
    // [SerializeField] private TextMeshProUGUI playerHealth2;
    [SerializeField] private float timerCountdown;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private bool roundActive;
    [SerializeField] private bool inPlace = false;
    [SerializeField] private int ColumnPlace = -1;

    private void Start()
    {
        timerCountdown = 10f;
       StartRound();
    }

    private void Update()
    {
        if (!roundActive) return;
        

        timerCountdown -= Time.deltaTime;
        countdown.text = "Timer : " + timerCountdown;
        if (timerCountdown <= 0)
        {
           // LockPlayer();
            SpawnBranchAndFruit();
            timerCountdown = 10f;
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
        if (roundActive) // Only allow changing while timer running
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
    
    

    private void LockPlayer()
    {
        if (timerCountdown <= 0f && gameObject.CompareTag("Player"))
        {
            inPlace = true;
            Debug.Log("You have cooked!");
        }
        else
        {
            inPlace = false;
            Debug.Log("You haven't made it in time :(");
        }
    }
}
