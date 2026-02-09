using UnityEngine;
using UnityEngine.InputSystem;

public class TugPlayer : MonoBehaviour
{
    private GameObject tugManager;
    private TugManager tM;
    public int playerNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tugManager = GameObject.Find("TOW Manager");
        tM = tugManager.GetComponent<TugManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //input slop, probably not optimal at all!! too bad !!!
    public void Up(InputAction.CallbackContext context)
    {
        tM.PlayerInput(playerNumber, 0);
    }
    public void Down(InputAction.CallbackContext context)
    {
        tM.PlayerInput(playerNumber, 1);
    }
    public void Left(InputAction.CallbackContext context)
    {
        tM.PlayerInput(playerNumber, 2);
    }
    public void Right(InputAction.CallbackContext context)
    {
        tM.PlayerInput(playerNumber, 3);
    }
}
