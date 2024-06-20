using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheoryScript : MonoBehaviour
{
    public void OpenTheory()
    {
        SceneManager.LoadScene(2);
    }
}
