using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        if(GameManager.Instance.winningPlayer == -1)
        {
            SceneManager.LoadScene(1);
            GameManager.Instance.winningPlayer = -1;
        }
        else
        {
            SceneManager.LoadScene(3);
            GameManager.Instance.winningPlayer = -1;
        }
    }

    public void Titlescreen()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.winningPlayer = -1;
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
