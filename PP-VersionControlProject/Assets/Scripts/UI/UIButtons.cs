using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public string twoPlayerVersusName;
    public void PlayTwoPlayerVersus()
    {
        SceneManager.LoadScene(twoPlayerVersusName);
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
}
