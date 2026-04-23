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
    private Vector2 screenBounds;

    private void Awake()
    {
        Time.timeScale = 0f;
        //gameManager = GameObject.Find("GameManager");
        //gM = gameManager.GetComponent<GameManager>();
    }
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        
    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x, screenBounds.x * 1);
        transform.position = viewPos;
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
