using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    [SerializeField] GameObject pause;
    private bool isPaused;

    private void Start()
    {
        pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !isPaused)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            PauseOff();
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseOn()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
