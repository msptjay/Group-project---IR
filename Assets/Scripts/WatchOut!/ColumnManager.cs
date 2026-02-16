using UnityEngine;
using System.Collections;
using TMPro;

public class ColumnManager : MonoBehaviour
{
    [Header("World stuff")] [SerializeField]
    private Transform[] columns;

    [SerializeField] private Collider2D[] playerSlots;
    [SerializeField] private GameObject branchPrefab;

    [SerializeField] private TextMeshProUGUI countdown;

//    [SerializeField] private TextMeshProUGUI playerHealth1;
    // [SerializeField] private TextMeshProUGUI playerHealth2;
    [SerializeField] private float timerCountdown = 10f;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private bool roundActive;
    [SerializeField] private bool inPlace = false;
    [SerializeField] private int ColumnPlace = -1;

    private void Start()
    {
        roundActive = true;
    }

    private void Update()
    {
        if (!roundActive) return;

        timerCountdown -= Time.deltaTime;
        countdown.text = "Timer : " + timerCountdown;
        if (timerCountdown <= 0)
        {
           // LockPlayer();
            SpawnBranch();
            roundActive = false;
        }
    }

    public void StartRound()
    {
        roundActive = true;

        if (ColumnPlace == -1)
        {
            Debug.Log("Player did not choose a column!");
            return;
        }

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
    
    private void SpawnBranch()
    {
        int randomColumn = Random.Range(0, columns.Length);
        Instantiate(branchPrefab,columns[randomColumn].position,Quaternion.identity);
        Debug.Log("Spawned branch");
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
