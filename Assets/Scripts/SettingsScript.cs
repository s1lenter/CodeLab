using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public void OpenSettings()
    {
        SceneManager.LoadScene(1);
    }
}
