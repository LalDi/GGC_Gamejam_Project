using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void Start()
    {
        SoundManager.BackgroundRun("로비BGM");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
