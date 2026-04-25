using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameSelect : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gM;
     void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gM = gameManager.GetComponent<GameManager>();
    }
    [SerializeField] GameObject info1, info2, info3, info4, info5, info6;
    public void Button1Hover()
    {
        info1.SetActive(true);
    }
    public void Button1Press()
    {
        gM.PlayOneLevel("PlinkoSort");
    }
    public void Button1Leave()
    {
        info1.SetActive(false);
    }
    public void Button2Hover()
    {
        info2.SetActive(true);
    }
    public void Button2Press()
    {
        gM.PlayOneLevel("TugOfWar");
    }
    public void Button2Leave()
    {
        info2.SetActive(false);
    }
    public void Button3Hover()
    {
        info3.SetActive(true);
    }
    public void Button3Press()
    {
        gM.PlayOneLevel("BouncyBall");
    }
    public void Button3Leave()
    {
        info3.SetActive(false);
    }
    public void Button4Hover()
    {
        info4.SetActive(true);
    }
    public void Button4Press()
    {
        gM.PlayOneLevel("WatchOut");
    }
    public void Button4Leave()
    {
        info4.SetActive(false);
    }
    public void Button5Hover()
    {
        info5.SetActive(true);
    }
    public void Button5Press()
    {
        gM.PlayOneLevel("Counting");
    }   
    public void Button5Leave()
    {
        info5.SetActive(false);
    }
    public void Button6Hover()
    {
        info6.SetActive(true);
    }
    public void Button6Press()
    {
        gM.PlayOneLevel("Platform drop");
    }
    public void Button6Leave()
    {
        info6.SetActive(false);
    }
    public void BackButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
