using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = -1;
    //set minigame names through editor
    [SerializeField] string[] minigameNames;

    GameObject TutorialHolder;
    void Start()
    {
        //the game manager won't be destroyed on scene transition
        DontDestroyOnLoad(this.gameObject);
    }
    void Awake()
    {
        TutorialHolder = GameObject.FindWithTag("TutorialHolder");
        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        score++;
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
}
