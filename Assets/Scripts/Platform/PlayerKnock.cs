using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerKnock : MonoBehaviour
{
    
public float pushForce = 10f;

    public Collider2D pushLeft;
    public Collider2D pushRight;

    


    public void OnPush(InputAction.CallbackContext context)
    {
        PushAttack(pushLeft, Vector2.left);
        PushAttack(pushRight, Vector2.right);
    }
    void PushAttack(Collider2D box, Vector2 direction)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(box.bounds.center, box.bounds.size, 0f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player") && hit.gameObject != gameObject)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
                }
            }
        }
    }

}

