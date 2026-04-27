using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int overallP1Score;
    public int overallP2Score;
    //set minigame names through editor
    [SerializeField] string[] minigameNames;
    public bool playingOneGame = false;
    bool shouldGameEnd = false;


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

    public void PlayOneLevel(string MinigameName)
    {
        //put the string of the minigame you want to play here
        SceneManager.LoadScene(MinigameName);
        playingOneGame = true;
    }

    public void LevelEnded(int p1Score, int p2Score)
    {
        if (playingOneGame)
        {
            if (p1Score > p2Score)
            {
                overallP1Score++;
            }
            else if (p2Score > p1Score)
            {
                overallP2Score++;
            }
            playingOneGame = false;
            SceneManager.LoadScene("WinScreen");
        }
        else
        {
            if (p1Score > p2Score)
            {
                overallP1Score++;
            }
            else if (p2Score > p1Score)
            {
                overallP2Score++;
            }
            if(overallP1Score >= 4 || overallP2Score >= 4)
            {
                SceneManager.LoadScene("WinScreen");
                shouldGameEnd = true;
            }
            Debug.Log("Trying to load next level,");
            if(!shouldGameEnd)
                LoadNextLevel();
        }
    }
}
