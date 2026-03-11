using System.Collections;
using TMPro;
using UnityEngine;

public class CountingResults : MonoBehaviour
{
    [SerializeField] GameObject CountingManager;
    [SerializeField] CountingManager cM;

    [SerializeField] TextMeshProUGUI p1CorrectNumber;
    [SerializeField] TextMeshProUGUI p2CorrectNumber;
    [SerializeField] TextMeshProUGUI p1Text;
    [SerializeField] TextMeshProUGUI p2Text;
    Animator animator;
    Animation anim;
    int p1IntToDisplay;
    int p2IntToDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        p1CorrectNumber.text = "x " + cM.p1CorrectCount.ToString();
        p2CorrectNumber.text = "x " + cM.p2CorrectCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreDisplay()
    {
        StartCoroutine(ScoreTick());
        //for (int i = 0; i < cM.p1TotalCount; i++)
        //{
        //    p1Text.text = "x " + i.ToString();
        //}
        //for (int i = 0; i < cM.p2TotalCount; i++)
        //{
        //    p2Text.text = "x " + i.ToString();
        //}
    }

    IEnumerator ScoreTick()
    {
        while (true)
        {
            if (p1IntToDisplay < cM.p1TotalCount)
            {
                p1IntToDisplay++;
                p1Text.text = "x " + p1IntToDisplay.ToString();
            }
            else if (p1IntToDisplay >= cM.p1TotalCount)
            {
                p1Text.text = "x " + p1IntToDisplay.ToString();
            }
            if (p2IntToDisplay < cM.p2TotalCount)
            {
                p2IntToDisplay++;
                p2Text.text = "x " + p2IntToDisplay.ToString();
            }
            else if (p2IntToDisplay >= cM.p2TotalCount)
            {
                p2Text.text = "x " + p2IntToDisplay.ToString();
            }

            yield return new WaitForSeconds(0.2f);
        }
    }    
}
