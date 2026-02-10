using System;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] private int Damage = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject
                .GetComponent<PlayerHealth>()
                .TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
