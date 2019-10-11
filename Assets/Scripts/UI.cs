using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlaySpecial()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR  
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    #if UNITY_STANDALONE
        Application.Quit();
    #endif
    }
}
