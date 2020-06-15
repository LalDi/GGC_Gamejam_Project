using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{

    public BossAnimation bAnimation;

    Image trImage;

    public bool isStart;

    private void Start()
    {

        trImage = GetComponent<Image>();

        Run();

    }

    private void Run()
    {

        bAnimation.On(trImage);

        Move();

    }

    public void Move()
    {

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BossMove"),
            "time", 3f, "loopType", iTween.LoopType.loop, "easeType", iTween.EaseType.linear));

    }

}
