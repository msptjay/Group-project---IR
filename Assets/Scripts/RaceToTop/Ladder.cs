using UnityEngine;

public class Ladder : MonoBehaviour
{
        [SerializeField] private Rigidbody2D rb;

         [SerializeField] private float moveSpeed = 2f;
         private float vertical;

        private bool isLadder;
         private bool isClimbing;


 public void update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

      private void FixedUpdate()
    {
        

        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * moveSpeed);
        }
        else
        {
            rb.gravityScale = 1f;
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
}
