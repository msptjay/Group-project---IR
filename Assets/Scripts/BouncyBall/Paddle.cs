using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    //references to the game manager object and script
    private GameObject gameManager;
    private GameManager gM;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 50f;
    private float horizontal;

    private void Awake()
    {
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

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.CompareTag("EndFlag"))
    //    {
    //        gM.LoadNextLevel();
    //    }
    //}
}
