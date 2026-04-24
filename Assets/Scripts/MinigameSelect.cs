using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameSelect : MonoBehaviour
{
    [SerializeField] GameObject info1, info2, info3, info4, info5, info6;
    
    public void Button1Hover()
    {
        info1.SetActive(true);
        
    }
    public void Button1Press()
    {
        Debug.Log("Pressed Button 1");
        SceneManager.LoadScene("PlinkoSort");
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
        Debug.Log("Pressed Button 2");
        SceneManager.LoadScene("TugOfWar");
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
        Debug.Log("Pressed Button 3");
        SceneManager.LoadScene("BouncyBall");
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
        Debug.Log("Pressed Button 4");
        SceneManager.LoadScene("WatchOut");
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
        Debug.Log("Pressed Button 5");
        SceneManager.LoadScene("Counting");
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
        Debug.Log("Pressed Button 6");
        SceneManager.LoadScene("Platform Drop");
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
