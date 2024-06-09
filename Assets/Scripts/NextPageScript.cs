using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPageScript : MonoBehaviour
{
    [SerializeField] Button nextPageButton;
    [SerializeField] private Image mainImage;
    [SerializeField] private Image[] images;
    private int currentIndex;

    public void OnNextPage()
    {
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
            mainImage.sprite = images[currentIndex].sprite;
        }
    }
}
