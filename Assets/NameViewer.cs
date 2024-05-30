using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameViewer : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text text;
    public void ChangeName()
    {
        text.text = inputField.text;
    }
}
