using UnityEngine;
using UnityEngine.InputSystem;

public class PlinkoPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] plinkoPegs;
    bool shouldSpinLeft;
    bool shouldSpinRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (shouldSpinRight)
        {
            foreach (GameObject peg in plinkoPegs)
            {
                peg.transform.Rotate(0, 0, -1);
            }
            
        }
        if (shouldSpinLeft)
        {
            foreach (GameObject peg in plinkoPegs)
            {
                peg.transform.Rotate(0, 0, 1);
            }
        }
    }

    public void SpinningLeft(InputAction.CallbackContext Left)
    {
        if (Left.performed)
        {
            shouldSpinLeft = true;
        }
        if (Left.canceled)
        {
            shouldSpinLeft = false;
        }
    }

    public void SpinningRight(InputAction.CallbackContext Right)
    {
        if (Right.performed)
        {
            shouldSpinRight = true;
        }
        if (Right.canceled)
        {
            shouldSpinRight = false;
        }
    }
}
