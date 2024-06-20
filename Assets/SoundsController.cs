using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    void Start()
    {
        foreach (AudioSource source in audioSources)
            if (!PlayerPrefs.HasKey("soundsVolume")) 
                source.volume = 1.0f;
    }

    void Update()
    {
        foreach (AudioSource source in audioSources)
            source.volume = PlayerPrefs.GetFloat("soundsVolume");
    }
}
