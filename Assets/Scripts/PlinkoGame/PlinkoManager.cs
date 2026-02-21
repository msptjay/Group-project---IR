using System.Collections;
using UnityEngine;

public class PlinkoManager : MonoBehaviour
{
    int spawnTime = 5;
    float difficultyRamp = 0;
    [SerializeField] Transform[] berrySpawns;
    [SerializeField] GameObject[] Berries;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBerry());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBerry()
        {
        while (true)
        {
            Instantiate(Berries[Random.Range(0,2)], (berrySpawns[Random.Range(0,2)].position), Quaternion.identity);
            Instantiate(Berries[Random.Range(2,4)], (berrySpawns[Random.Range(2,4)].position), Quaternion.identity);
            difficultyRamp += 0.25f;
            if (difficultyRamp % 1 == 0)
                spawnTime--;
            yield return new WaitForSeconds(spawnTime);

        }
    }
    
}
