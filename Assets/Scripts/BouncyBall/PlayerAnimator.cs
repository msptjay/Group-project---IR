using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    public Animator anim;
    public int facingDirection = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(paddle.horizontal));
        if(paddle.horizontal > 0 && transform.localScale.x < 0 || paddle.horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        else if(paddle.horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
