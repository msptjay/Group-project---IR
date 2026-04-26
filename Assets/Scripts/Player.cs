using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //references to the game manager object and script
    private GameObject gameManager;
    private GameManager gM;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] GameObject tutorialHolder;
    private float horizontal;
    private bool jump;

    private bool isLadder;
    private bool isClimbing;
    public Animator anim;
    public int facingDirection = 1;

    private void Awake()
    {
        Time.timeScale = 0f;
        jumpForce = 10f;
        moveSpeed = 5f;
        //gameManager = GameObject.Find("GameManager");
        //gM = gameManager.GetComponent<GameManager>();
    }

    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

       
    }
    public void Update()
    {
      //  vertical = Input.GetAxis("Vertical");
      //  if(isLadder && Mathf.Abs(vertical) > 0)
       // {
       //     isClimbing = true;
       // }
        anim.SetBool("Jumping1", rb.linearVelocity.y > .1f);

        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        if(horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        else if(horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    
       // anim.SetBool("Jumping1", rb.linearVelocity.y > .1f);
        
        
    }
     void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            jump = true;
          rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         
        }

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EndFlag"))
        {
            gM.LoadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
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
