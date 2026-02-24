using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int overallP1Score;
    public int overallP2Score;
    //set minigame names through editor
    [SerializeField] string[] minigameNames;
    [SerializeField] TextMeshProUGUI p1ScoreText;
    [SerializeField] TextMeshProUGUI p2ScoreText;

    GameObject TutorialHolder;
    void Start()
    {
        //the game manager won't be destroyed on scene transition
        DontDestroyOnLoad(this.gameObject);
    }
    void Awake()
    {
        p1ScoreText = GameObject.FindWithTag("P1OverallScore").GetComponent<TextMeshProUGUI>();
        p2ScoreText = GameObject.FindWithTag("P2OverallScore").GetComponent<TextMeshProUGUI>();
        p1ScoreText.text = overallP1Score.ToString();
        p2ScoreText.text = overallP2Score.ToString();
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
