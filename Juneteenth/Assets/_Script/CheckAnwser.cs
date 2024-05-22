using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckAnwser : MonoBehaviour
{
    public GameObject[] targetArray;
    public GameObject[] dragableArray;
    [SerializeField] private TextMeshProUGUI resultText;
    private string resultStr;
    private float delayTime = 2f;
    [SerializeField] GameObject FinishButton;
    // Start is called before the first frame update
    void Start()
    {
        resultText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool checkMatch()
    {
        for (int i = 0; i < targetArray.Length; i++)
        {
            //check does all blank matchs correctly by get its distance
            float matchDistance = Vector2.Distance(targetArray[i].transform.position,
                dragableArray[i].transform.position);

            if (matchDistance > 0.1f) { return false; }   
        }
        return true;
    }

    public void checkButton()
    {
        resultText.gameObject.SetActive(true);

        bool isMatch = checkMatch();

        //if (isMatch) { Debug.Log("correct"); } else { Debug.Log("incorrect"); }
        Debug.Log(isMatch ? "correct" : "incorrect");

        //finish button on/off
        FinishButton.SetActive(isMatch ? false : true);

        //change text
        resultStr = (isMatch ? "CORRECT!" : "INCORRECT!");

        //change color
        resultText.color = (isMatch ? Color.green : Color.red);

        //update UI text
        resultText.text = resultStr;

        //turn off result text in 2s
        StartCoroutine(deactiveResult(delayTime));


        /*
        if (isMatch)
        {
            resultStr = "CORRECT!"; //change text

            resultText.color = Color.green;//change color

            resultText.text = resultStr;//update UI text

            FinishButton.SetActive(false);//turn off finish button

            StartCoroutine(deactiveResult(delayTime));//turn off result in 2s

        }
        else
        {
            resultStr = "INCORRECT!"; //change text

            resultText.color = Color.red;//change color

            resultText.text = resultStr;//update UI text

            //FinishButton.SetActive(false);//turn off finish button

            StartCoroutine(deactiveResult(delayTime));//turn off result in 2s
        }
        */


    }

    //turn off result in 2s
    private IEnumerator deactiveResult(float delay)
    {
        yield return new WaitForSeconds(delay);

        resultText.gameObject.SetActive(false);
    }


}
