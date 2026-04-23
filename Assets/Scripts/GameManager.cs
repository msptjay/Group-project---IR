using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int overallP1Score = 2;
    public int overallP2Score;
    //set minigame names through editor
    [SerializeField] string[] minigameNames;
    

    GameObject TutorialHolder;
    void Start()
    {
        //the game manager won't be destroyed on scene transition
        DontDestroyOnLoad(this.gameObject);
        
    }

    public void LoadNextLevel()
    {
        //picks a random minigame from the array and loads it
        int randomIndex = Random.Range(0, minigameNames.Length);
        if (minigameNames[randomIndex] == SceneManager.GetActiveScene().name)
        {
            //if the random minigame is the same as the current one, pick the next one in the list
            randomIndex = (randomIndex + 1) % minigameNames.Length;
        }
        else
            SceneManager.LoadScene(minigameNames[randomIndex]);
    }

    public void TestOneLevel()
    {
        //put the string of the minigame you want to test here
        SceneManager.LoadScene("BouncyBall");
    }

    public void LevelEnded(int p1Score, int p2Score)
    {
        if(p1Score > p2Score)
        {
            overallP1Score++;
        }
        else if(p2Score > p1Score)
        {
            overallP2Score++;
        }
        LoadNextLevel();
    }
}
