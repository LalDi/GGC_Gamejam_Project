using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Result : MonoBehaviour
{
    private int Score;
    private int HP;

    public GameObject Clear;
    public GameObject Fail;
    public GameObject Button;

    private void Update()
    {
        Score = GameManager.Instance.Score;
        HP = GameObject.Find("Player").GetComponent<Character>().Hp;
        if (Score >= 800)
        {
            Time.timeScale = 0;
            Clear.SetActive(true);
            Button.SetActive(true);
            SoundManager.BackgroundRun("게임승리");
        }
        if (HP == 0)
        {
            Time.timeScale = 0;
            Fail.SetActive(true);
            Button.SetActive(true);
            SoundManager.BackgroundRun("게임패배");
        }
    }
    public void Result()
    {
        Application.Quit();
    }
}
