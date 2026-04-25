using System.Collections;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gM;

    [SerializeField] GameObject player1WinSetup;
    [SerializeField] GameObject player2WinSetup;
    [SerializeField] GameObject p1Icon;
    [SerializeField] GameObject p2Icon;


    void Awake()
    {
        player1WinSetup.SetActive(false);
        player2WinSetup.SetActive(false);
        // Find the GameManager in the scene
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gM = gameManager.GetComponent<GameManager>();

        if(gM.overallP1Score > gM.overallP2Score)
        {
            player1WinSetup.SetActive(true);
            StartCoroutine(FlipCharacter(p1Icon));
        }
        else if(gM.overallP2Score > gM.overallP1Score)
        {
            player2WinSetup.SetActive(true);
            StartCoroutine(FlipCharacter(p2Icon));
        }
    }

    // Update is called once per frame
    IEnumerator FlipCharacter(GameObject winningCharacter)
    {
        while (true)
        {
            winningCharacter.transform.localScale = new Vector3(-winningCharacter.transform.localScale.x, winningCharacter.transform.localScale.y, winningCharacter.transform.localScale.z);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
