using UnityEngine;
using System.Collections;
using TMPro;

public class ColumnManager : MonoBehaviour
{
    public Transform[] columns;
    public GameObject branchPrefab;
    public float timerCountdown = 5f;
    public TextMeshProUGUI countdown;
    /*
    private void Start()
    {
        SpawnBranch();
    } */

    private void Update()
    {
        
            timerCountdown -= Time.deltaTime;
            countdown.text = "Timer : "  + timerCountdown;
            if (timerCountdown <= 0)
            {
                SpawnBranch();
                timerCountdown = 10f;
            }
            
    }
    
    public void SpawnBranch()
    {
        int randomColumn = Random.Range(0, columns.Length);
        Instantiate(branchPrefab,columns[randomColumn].position,Quaternion.identity);
        Debug.Log("Spawned branch");

    }
}
