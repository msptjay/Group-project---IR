using UnityEngine;

public class BouncingBall : MonoBehaviour
{

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bounce!");
            //rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(Random.Range(-5f, 5f), 1 * 10f), ForceMode2D.Impulse);
        }
    }
}
