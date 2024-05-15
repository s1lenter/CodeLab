using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public GameObject windowDialog;
    public Text textDialog;
    public Button button;

    public string[] message;
    private int numberDialog = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && PlayerLife.CountDie==0)
        {
            if (numberDialog == message.Length - 1)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(NextDialog);
            }

            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
        }
        else
        {
            windowDialog.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        windowDialog.SetActive(false);
        button.onClick.RemoveAllListeners();
        button.gameObject.SetActive(false);
        numberDialog = 0;
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];

        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
        }
    }

}
