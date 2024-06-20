using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float oldVolume;
    [SerializeField] private string purpose;
    void Start()
    {
        oldVolume = slider.value;
        if (!PlayerPrefs.HasKey(purpose)) slider.value = 1;
        else slider.value = PlayerPrefs.GetFloat(purpose);
    }

    void Update()
    {
        if (slider.value != oldVolume)
        {
            PlayerPrefs.SetFloat(purpose, slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }
}
