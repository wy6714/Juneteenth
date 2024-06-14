using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reward : MonoBehaviour
{
    [SerializeField] private string rewardName;
    [SerializeField] private GameObject cover;
    private DragableItem interactiveScript;

    private void OnEnable()
    {
        interactiveScript = GetComponent<DragableItem>();
        interactiveScript.enabled = false;

        cover.SetActive(true);

        GameManager.activeReward += enableReward;
        
    }
    private void OnDisable()
    {
        GameManager.activeReward -= enableReward;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void enableReward(string objName)
    {
        if(rewardName == objName)
        {
            cover.SetActive(false);
            interactiveScript.enabled = true;
        }
    }

   
}
