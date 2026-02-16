using UnityEngine;
using System.Collections;
using TMPro;

public class ColumnManager : MonoBehaviour
{
    [Header("World stuff")]
    [SerializeField] private Transform[] columns;
    [SerializeField] private Collider2D[] playerSlots;
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private TextMeshProUGUI countdown;
//    [SerializeField] private TextMeshProUGUI playerHealth1;
   // [SerializeField] private TextMeshProUGUI playerHealth2;
   [SerializeField] private float timerCountdown = 5f;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private bool roundActive = false;
    [SerializeField] private bool inPlace = false;
    [SerializeField] private int ColumnPlace = -1;
    
    private void Start()
    {
        //StartRound();
        
    }

    private void Update()
    {
        timerCountdown -= Time.deltaTime;
        countdown.text = "Timer : " + timerCountdown;
        if (timerCountdown <= 0)
        {
            SpawnBranch();
            timerCountdown = 10f;
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

    private void LockedInSpot(int column)
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

    private void LockPlayerCollumn()
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
