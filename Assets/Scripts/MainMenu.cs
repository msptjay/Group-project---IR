using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gM = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        gM.LoadNextLevel();
        //gM.TestOneLevel();
    }
}
