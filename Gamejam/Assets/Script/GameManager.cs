using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance
    {

        get
        {

            if (!_instance) _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

            return _instance;

        }

    }

    public int FeverScore, Score;

    private void Start()
    {

        CharacterEvent.addOnFeverEnd(() =>
        {

            addScore();
            FeverScore = 0;

        });

    }

    public void addScore() { Score += FeverScore; }

}
