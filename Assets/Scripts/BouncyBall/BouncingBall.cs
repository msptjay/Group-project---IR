using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private int ownedBy;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
            
            //rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(Random.Range(-5f, 5f), 1 * 10f), ForceMode2D.Impulse);

            if (collision.gameObject.name == "Player")
            {
                Debug.Log("collided with" + collision.gameObject.name);
                ownedBy = 1;
                sr.material.SetColor("_Color", Color.green);
            }
            if (collision.gameObject.name == "Player2")
            {
                ownedBy = 2;
                sr.material.SetColor("_Color", Color.cornflowerBlue);
            }
        }
    }
}
