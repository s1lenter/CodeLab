using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheoryNavigationScript : MonoBehaviour
{
    [SerializeField] private Image mainImage;
    [SerializeField] private Sprite[] sprites;
    private int counter;

    private void Start()
    {
        counter = 0;
        mainImage.sprite = sprites[counter];
    }
    public void OnNextPage()
    {
        if (counter < sprites.Length - 1)
        {
            counter++;
            mainImage.sprite = sprites[counter];
        }
    }

    public void OnPreviewPage()
    {
        if (counter > 0)
        {
            counter--;
            mainImage.sprite = sprites[counter];
        }
    }

}
