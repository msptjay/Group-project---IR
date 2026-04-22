using UnityEngine;

public class UnderWorld : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private Platforms manager;
    private PlayerHealth playerHealth;
    [SerializeField] private GameObject player;
    public Transform respawnPoint;
    public GameObject platformPrefab;

    public Transform platformPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject
                .GetComponent<PlayerHealth>()
                .TakeDamage(damage);
            if (playerHealth.HealthStatus() == 0)
            {
                Destroy(gameObject);
            }
            else if (playerHealth.HealthStatus() <= 0);
            {
            player.transform.position = respawnPoint.position;
            Instantiate(platformPrefab, platformPosition.position, Quaternion.identity);
            }


            
        }
    }
}
