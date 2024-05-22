using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] private Transform OrigCameraPos;
    public string PlayerName = "";

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
}
