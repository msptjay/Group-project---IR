using UnityEngine;
using UnityEngine.U2D;

public class ScorePopup : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    //[SerializeField] Animation anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 3f);
        //anim.Play("ScorePopupAnim");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 3, 0) * Time.deltaTime;
    }
}
