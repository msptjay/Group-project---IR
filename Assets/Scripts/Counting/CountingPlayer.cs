using UnityEngine;
using UnityEngine.InputSystem;

public class CountingPlayer : MonoBehaviour
{
    [SerializeField] GameObject countingManager;
    [SerializeField] CountingManager cM;
    [SerializeField] int playerNumber;
    [SerializeField] GameObject tutorialHolder;
    public bool shouldInput = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCount(InputAction.CallbackContext context)
    {
        if(context.performed && shouldInput)
        {
            if(playerNumber == 1)
            {
                cM.p1Count();
            }
            else
            {
                cM.p2Count();
            }
        }
    }

    public void FinishTutorial(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 1f;
            tutorialHolder.SetActive(false);
        }
    }
}
