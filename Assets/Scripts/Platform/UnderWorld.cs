using UnityEngine;

public class UnderWorld : MonoBehaviour
{
    [SerializeField] private int damage = 2;
    private Platforms manager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject
                .GetComponent<PlayerHealth>()
                .TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
