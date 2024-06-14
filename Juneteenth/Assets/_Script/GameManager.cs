using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] private Transform OrigCameraPos;
    public string PlayerName = "";

    [SerializeField] private GameObject q1Reward;
    [SerializeField] private GameObject q2Reward;
    [SerializeField] private GameObject q3Reward;
    [SerializeField] private GameObject q4Reward;

    //event
    public static event Action<string> activeReward;

    //[SerializeField] private bool musicActive = false;
    //[SerializeField] private bool heartActive = false;
    //[SerializeField] private bool smileActive = false;
    //[SerializeField] private bool flagActive = false;


    private void Awake()
    {
        gm = this;
    }

    private void OnEnable()
    {
        ReadInput.enteredName += updatePlayerName;

    }
    private void OnDisable()
    {
        ReadInput.enteredName -= updatePlayerName;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackToDesk()
    {
        Camera mainCamera = Camera.main;
        mainCamera.transform.position = OrigCameraPos.position;
    }

    public void updatePlayerName(string name)
    {
        PlayerName = name;
    }
    public void showQ1Reaward()
    {
        q1Reward.SetActive(true);

        StartCoroutine(closeRewardAfterDelay(2f, q1Reward));
        //musicActive = true;
        activeReward?.Invoke("music");//turn off cover;allow dragable

    }

    public void showQ2Reaward()
    {
        q2Reward.SetActive(true);

        StartCoroutine(closeRewardAfterDelay(2f, q2Reward));
        //heartActive = true;
        activeReward?.Invoke("heart");

    }
    public void showQ3Reaward()
    {
        q3Reward.SetActive(true);

        StartCoroutine(closeRewardAfterDelay(2f, q3Reward));
        //smileActive = true;
        activeReward?.Invoke("smile");

    }
    public void showQ4Reaward()
    {
        q4Reward.SetActive(true);

        StartCoroutine(closeRewardAfterDelay(2f, q4Reward));
        //flagActive = true;
        activeReward?.Invoke("flag");
    }


    IEnumerator closeRewardAfterDelay(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);

        obj.SetActive(false);
    }
}
