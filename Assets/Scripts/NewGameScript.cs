using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene(3);
    }
}
