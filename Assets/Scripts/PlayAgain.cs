using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void Playing()
    {
        SceneManager.LoadScene(1);
        ItemCollector.countch = 0;
        ItemCollector1.countch = 0;
        ItemCollector2.countch = 0;
    }
}
