using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedSettings : MonoBehaviour
{
    [SerializeField] GameObject settings;
    public static bool isSetting;
    private void Start()
    {
        settings.SetActive(false);
    }

    public void SettingsClick()
    {
        isSetting = true;
    }

    private void Update()
    {
        if (isSetting)
        {
            settings.SetActive(true);
            Time.timeScale = 0;
            isSetting = true;
        }
    }

    public void SettingsExit()
    {
        isSetting = false;
        settings.SetActive(false);
    }
}
