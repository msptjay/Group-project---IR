using UnityEngine;

public class UnderWorld : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private Platforms manager;
    private PlayerHealth playerHealth;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject player2;
    public Transform respawnPoint;
    public Transform respawnPoint2;
    public GameObject platformPrefab;
   // public GameObject platformPrefab2;

    public Transform platformPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject
                .GetComponent<PlayerHealth>()
                .TakeDamage(damage);
            if (collision.gameObject.GetComponent<PlayerHealth>().HealthStatus() <= 0)
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<PlayerHealth>().HealthStatus() >= 0)
            {
            player.transform.position = respawnPoint.position;
            Instantiate(platformPrefab, platformPosition.position, Quaternion.identity);
            }


            
        }

        else if (collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject
                .GetComponent<PlayerHealth>()
                .TakeDamage(damage);
            if (collision.gameObject.GetComponent<PlayerHealth>().HealthStatus() <= 0)
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<PlayerHealth>().HealthStatus() >= 0)
            {
            player2.transform.position = respawnPoint2.position;
            Instantiate(platformPrefab, platformPosition.position, Quaternion.identity);
            }


            
        }
    }
}
