using System;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] private int damage = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject
                .GetComponent<PlayerHealth>()
                .TakeDamage(damage);

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Floor"))
            {
            Destroy(gameObject);
            }
    }
}
