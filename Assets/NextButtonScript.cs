using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButtonScript : MonoBehaviour
{
    [SerializeField] Text dialogText;

    public void CompleteLevel()
    {
        if (dialogText != null)
        {
            var answer = "";
            var textArr = dialogText.text.ToCharArray();
            for(int i = 0; i < 5; i++)
                answer += textArr[i];
            if (answer == "Hello")
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
