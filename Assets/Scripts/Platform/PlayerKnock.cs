using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
public class PlayerKnock : MonoBehaviour
{
    
[SerializeField] private float pushForce;
[SerializeField] private float strength = 16, delay = 0.15f;
[SerializeField] private Rigidbody2D rb2d;

public UnityEvent OnBegin, OnDone;
public void Awake()

{
    pushForce = 5f;
}


public void PlayerFeedback(GameObject hitbox)
{
    StopAllCoroutines();
    OnBegin?.Invoke();
    Vector2 direction = (transform.position - hitbox.transform.position).normalized;
    rb2d.AddForce(direction * pushForce, ForceMode2D.Impulse);
    StartCoroutine(Reset());
}

private IEnumerator Reset()
{
    yield return new WaitForSeconds(delay);
    rb2d.velocity = Vector3.zero;
    OnDone?.Invoke();
}



}

