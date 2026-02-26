using System.Collections;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] private float timeCountdown;


    public void Start()
    {
        //I JUST HAD TO ADD THIS BECAUSE IT WOULDNT COMPILE
        StartCoroutine(Countdown());

    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timeCountdown);
    }

}
