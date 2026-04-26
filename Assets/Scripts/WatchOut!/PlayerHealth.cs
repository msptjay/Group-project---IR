using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    public int currentHealth;
    [SerializeField] GameObject UIManager;
    [SerializeField] WatchUIManager wUIM;
    [SerializeField] int playerNumber;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
       
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} health: {currentHealth}");
        wUIM.UpdateScores(playerNumber, currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} is dead");
        }
    }

    public int HealthStatus()
    {
        return currentHealth;
    }

}
