using UnityEngine;
using System.Collections;

public class ColumnManager : MonoBehaviour
{
    public Transform[] columns;
    public GameObject branchPrefab;

    private void Start()
    {
        SpawnBranch();
    }
    
    public void SpawnBranch()
    {
        int randomColumn = Random.Range(0, columns.Length);
        Instantiate(branchPrefab,columns[randomColumn].position,Quaternion.identity);
        Debug.Log("Spawned branch");

    }
}
