using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameViewer : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text text;
    [SerializeField] private PlayerLife playerLife;
    public void ChangeName()
    {
        
        if (inputField.text == "ZVO")
        {
            text.text = "Zа наших!!!! ГОООООЛ";
            playerLife.Die();
        }
        else
            text.text = "Привет, " + inputField.text;
    }
}
