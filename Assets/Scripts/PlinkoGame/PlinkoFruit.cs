using UnityEngine;

public class PlinkoFruit : MonoBehaviour
{
    [SerializeField] int FruitType; // 0 = Blueberry 1 = strawberry 2 = cranberry 3 = blackberry
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BluB Box"))
        {
            if(FruitType == 0)
            {
                Debug.Log("BLUEBERRY CORREC T!!!!!");
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("StrB Box"))
        {
            if (FruitType == 1)
            {
                Debug.Log("STRAWBERRY CORRECT!!!!!");
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("CraB Box"))
        {
            if (FruitType == 2)
            {
                Debug.Log("CRANBERRY CORRECT!!!!!");
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("BlaB Box"))
        {
            if (FruitType == 3)
            {
                Debug.Log("BLACKBERRY CORRECT!!!!!");
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
}
