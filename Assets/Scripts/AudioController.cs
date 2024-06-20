using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource src;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) src.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        src.volume = PlayerPrefs.GetFloat("volume");
    }
}
