using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public string input;
    public static event Action<string> enteredName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadStringInput(string s)
    {
        input = s;
        enteredName?.Invoke(input);
        Debug.Log(input);

        GameManager.gm.BackToDesk();
    }
}
