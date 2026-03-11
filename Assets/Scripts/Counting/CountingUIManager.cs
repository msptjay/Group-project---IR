using TMPro;
using UnityEngine;

public class CountingUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI p1Text;
    [SerializeField] TextMeshProUGUI p2Text;
    [SerializeField] GameObject UIManager;
    [SerializeField] CountingUIManager cUIM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
    }

    public void UpdateTimer(int secondsLeft)
    {
        timer.text = secondsLeft.ToString();
    }

    public void UpdatePlayerCounting(int playerNumber, int count)
    {
        if(playerNumber == 1)
        {
            p1Text.text = count.ToString();
        }
        else
        {
            p2Text.text = count.ToString();
        }
    }

    

}
