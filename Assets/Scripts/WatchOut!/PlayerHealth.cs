using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameManager gm;
 

    private void Awake()
    {
      
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth  <= 0)
        {
            Debug.Log($"{gameObject.name} is dead");
            gm.LoadNextLevel();
        }
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

    public void HealthStatus(bool isDead)
    {
       
    }

}
