using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip clip1, clip2, clip3;

    [SerializeField] private GameObject gameOverPanel;
    public static GameObject gameoverPanel;
    void Awake()
    {
        if(gameoverPanel == null)
        {
            gameoverPanel = gameOverPanel;
        }
        gameoverPanel.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            aud.clip = clip1;
            aud.Play();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            aud.clip = clip2;
            aud.Play();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            aud.clip = clip3;
            aud.Play();
        }

        if (gameoverPanel.activeSelf == true)
           if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(0);
    }

}
