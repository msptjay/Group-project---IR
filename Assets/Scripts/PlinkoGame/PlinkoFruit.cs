using UnityEngine;

public class PlinkoFruit : MonoBehaviour
{
    [SerializeField] int FruitType; // 0 = Blueberry 1 = strawberry 2 = cranberry 3 = blackberry
    GameObject plinkoManager;
    PlinkoManager pM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plinkoManager = GameObject.FindWithTag("PlinkoManager");
        pM = plinkoManager.GetComponent<PlinkoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
            {
            case "BluB Box":
                if (FruitType == 0)
                {
                    pM.AddScore(1, true);
                    Destroy(gameObject);
                }
                
                break;
            case "StrB Box":
                if (FruitType == 1)
                {
                    pM.AddScore(1, true);
                    Destroy(gameObject);
                }
                break;
            case "CraB Box":
                if (FruitType == 2)
                {
                    pM.AddScore(1, false);
                    Destroy(gameObject);
                }
                break;
            case "BlaB Box":
                if (FruitType == 3)
                {
                    pM.AddScore(1, false);
                    Destroy(gameObject);
                }
                break;
            case "Ground":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
