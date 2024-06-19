using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NameViewer : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text text;
    [SerializeField] private PlayerLife playerLife;
    private string answer = "Console.WriteLine(\"";
    private char[] answerArr = null;
    private bool confirm = false;

    private void Start()
    {
        answerArr = answer.ToCharArray();
    }
    public void ChangeName()
    {
        string inputText = inputField.text;
        char[] inputArray = inputText.ToCharArray();
        if (inputArray[^1] == ';' && inputArray[^2] == ')' && inputArray[^3] == '\"'
            && inputArray.Length > answer.Length)
        {
            for (int i = 0; i < answer.Length; i++)
            {
                if (inputArray[i] == answer[i])
                    confirm = true;
                else
                    confirm = false;
            }
            if (confirm)
            {
                text.text = inputText.Substring(answer.Length, inputText.Length - answer.Length - 3);
            }
        }
    }
}
