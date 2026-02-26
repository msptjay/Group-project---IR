using UnityEngine;
using TMPro;
using System.Collections;

public class Platforms : MonoBehaviour
{
    [SerializeField] private float timeCountdown;
    [SerializeField] private GameObject startingPlatform;
    [SerializeField] private float startingPlatTime;
    [SerializeField] private TextMeshProUGUI platform1;

    public void Start()
    {
        startingPlatTime = 5f;
        StartCoroutine(startingCountdown());

    }

    public void Update()
    {

        platform1.text = "Timer: " + startingPlatTime;
        startingPlatTime -= Time.deltaTime;

        if (startingPlatTime <= 0)
        {
            Destroy(startingPlatform);
            Destroy(platform1);
        }
    }

    IEnumerator startingCountdown()
    {
        while (true)
        {
            float timer = startingPlatTime;
            while (timer > 0)
            {
                platform1.text = "Timer: " + timer;
                timer -= Time.deltaTime;
                yield return null;
            }

        }





    }
}
