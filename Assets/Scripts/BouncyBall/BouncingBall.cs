using System;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private GameObject bouncyBallManager;
    private BallSpawner bS;
    private int ownedBy;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] GameObject p1ScorePopup;
    [SerializeField] GameObject p2ScorePopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bouncyBallManager = GameObject.FindWithTag("BouncyBallManager");
        bS = bouncyBallManager.GetComponent<BallSpawner>();
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
            rb.AddForce(new Vector2(UnityEngine.Random.Range(-5f, 5f), 1 * 10f), ForceMode2D.Impulse);

            if (collision.gameObject.name == "Player")
            {
                ownedBy = 1;
                sr.material.SetColor("_Color", Color.yellow);
            }
            if (collision.gameObject.name == "Player2")
            {
                ownedBy = 2;
                sr.material.SetColor("_Color", Color.mediumBlue);
            }
        }
        if(collision.gameObject.CompareTag("BouncyBall"))
        {
            rb.AddForce(new Vector2(UnityEngine.Random.Range(-10f, 10f), 1 * 4f), ForceMode2D.Impulse);
        }

        if(collision.gameObject.CompareTag("ScoreFloor"))
        {
            if (ownedBy == 1)
            {
                Instantiate(p1ScorePopup, transform.position, Quaternion.identity);
                bS.AddScore(1);
            }
            if (ownedBy == 2)
            {
                bS.AddScore(2);
                Instantiate(p2ScorePopup, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
