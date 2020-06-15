using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Hp : MonoBehaviour
{
    [SerializeField]
    private Image[] HP = new Image[3];
    private int PlayerHp;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            HP[i] = transform.Find($"HP_{i + 1}").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHp = GameObject.Find("Player").GetComponent<Character>().Hp;
        switch (PlayerHp)
        {
            case 3:
                break;
            case 2:
                HP[0].DOFade(0, 1.2f);
                break;
            case 1:
                HP[1].DOFade(0, 1.2f);
                break;
            case 0:
                HP[2].DOFade(0, 1.2f);
                break;
            default:
                break;
        }
    }
}
