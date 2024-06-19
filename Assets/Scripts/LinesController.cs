using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinesController : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private int pageMaxLines;
    void Update()
    {
        string text = inputField.text;
        string[] lines = text.Split('\n');
        int numberOfLines = lines.Length;

        if (numberOfLines > pageMaxLines)
            inputField.text = text.Substring(0, text.Length - 1);
    }
}
