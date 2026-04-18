using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    //references to the game manager object and script
    private GameObject gameManager;
    private GameManager gM;
    [SerializeField] GameObject tutorialHolder;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 50f;
    public float horizontal;


    private void Awake()
    {
        Time.timeScale = 0f;
        //gameManager = GameObject.Find("GameManager");
        //gM = gameManager.GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
       
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
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
