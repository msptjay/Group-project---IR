using TMPro;
using UnityEngine;

public class CountingUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTimer(int secondsLeft)
    {
        timer.text = secondsLeft.ToString();
    }
}
