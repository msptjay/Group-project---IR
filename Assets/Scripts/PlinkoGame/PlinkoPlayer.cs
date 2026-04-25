using UnityEngine;
using UnityEngine.InputSystem;

public class PlinkoPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] plinkoPegs;
    bool shouldSpinLeft;
    bool shouldSpinRight;
    [SerializeField] GameObject tutorialHolder;

    float xInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        //if (shouldSpinRight)
        //{
        //    foreach (GameObject peg in plinkoPegs)
        //    {
        //        peg.transform.Rotate(0, 0, -0.5f);
        //    }
            
        //}
        //if (shouldSpinLeft)
        //{
        //    foreach (GameObject peg in plinkoPegs)
        //    {
        //        peg.transform.Rotate(0, 0, 0.5f);
        //    }
        //}
        if(xInput > 0)
        {
            foreach (GameObject peg in plinkoPegs)
            {
                peg.transform.Rotate(0, 0, -0.4f);
            }
        }
        else if(xInput < 0)
        {
            foreach (GameObject peg in plinkoPegs)
            {
                peg.transform.Rotate(0, 0, 0.4f);
            }
        }

    }

    //public void SpinningLeft(InputAction.CallbackContext Left)
    //{
    //    if (Left.performed)
    //    {
    //        shouldSpinLeft = true;
    //    }
    //    if (Left.canceled)
    //    {
    //        shouldSpinLeft = false;
    //    }
    //}

    //public void SpinningRight(InputAction.CallbackContext Right)
    //{
    //    if (Right.performed)
    //    {
    //        shouldSpinRight = true;
    //    }
    //    if (Right.canceled)
    //    {
    //        shouldSpinRight = false;
    //    }
    //}
    public void FinishTutorial(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 1f;
            tutorialHolder.SetActive(false);
        }
    }

    //public void SpinInput(InputValue inputValue)
    //{
    //    Vector2 input = inputValue.Get<Vector2>();
    //    if (input.x > 0)
    //    {
    //        shouldSpinRight = true;
    //        shouldSpinLeft = false;
    //    }
    //    else if (input.x < 0)
    //    {
    //        shouldSpinLeft = true;
    //        shouldSpinRight = false;
    //    }
    //    else
    //    {
    //        shouldSpinLeft = false;
    //        shouldSpinRight = false;
    //    }
    //}

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        xInput = input.x;

        Debug.Log("X Axis: " + xInput);
    }

}
