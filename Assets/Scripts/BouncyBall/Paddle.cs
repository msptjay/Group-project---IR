using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    //references to the game manager object and script
    private GameObject gameManager;
    private GameManager gM;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int healthMax = 10;
    [SerializeField] private int health;
    private float horizontal;

    private void Awake()
    {
        health = healthMax;
        gameManager = GameObject.Find("GameManager");
        gM = gameManager.GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EndFlag"))
        {
            gM.LoadNextLevel();
        }
    }
}
