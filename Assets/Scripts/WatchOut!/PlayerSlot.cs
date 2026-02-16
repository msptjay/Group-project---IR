using UnityEngine;

public class PlayerSlot : MonoBehaviour
{
    public int slotIndex;
    private ColumnManager manager;

    private void Start()
    {
        manager = FindObjectOfType<ColumnManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.SetPlayerSlot(slotIndex);
            manager.PlaceChecker();

        }
    }

    private void ONtriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.PlayerLeftSlot();
        }
    }
}
