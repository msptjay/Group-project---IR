using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private int currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} is dead");
        }
    }

}
