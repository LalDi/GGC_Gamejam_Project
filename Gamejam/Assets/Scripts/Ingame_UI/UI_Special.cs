using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Special : MonoBehaviour
{
    private Vector3 PlayerPos;
    private Vector3 pos;

    public bool OnSpecial = false;
    private bool Full = false;
    private bool MoveOn = true;

    public float ScaleValue;

    public GameObject[] pos_obj = new GameObject[4];

    Vector3[] point = new Vector3[4];
    ///pos : 원래 위치
    ///point0 : 1회 목적지
    ///point1 : 2회 목적지
    ///point2 : 1회 중간
    ///point3 : 2회 중간

    public Image m_Image;
    public Sprite[] m_Sprite = new Sprite[4];

    public float m_animationDelay;

    private float m_currentTime;
    private int m_aniIndex;

    void Start()
    {
        pos = GameObject.Find("FiverGaugeBar").transform.position;
        for (int i = 0; i < 4; i++)
        {
            pos_obj[i] = GameObject.Find($"Pos{i}");
            point[i] = pos_obj[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        Full = GameObject.Find("FiverGaugeBar").GetComponent<UI_SpecialGauge>().Full;
        if (Full && !OnSpecial)
        {
            transform.position = pos;
            transform.localScale = new Vector3(1, 1, 1);
            m_Image.sprite = m_Sprite[0];

            SoundManager.EffectRun("특수기조건달성");
            StartCoroutine(Move());
            GameObject.Find("Player").GetComponent<Character>().FeverGauge = 0;
            OnSpecial = true;
        }
        else if (OnSpecial && !MoveOn)
        {
            transform.position = new Vector3(PlayerPos.x + 100, PlayerPos.y-30, PlayerPos.z);
            DelayUpdate();
        }
        else if (!Full && !OnSpecial)
        {
            transform.position = new Vector3(100000,100000,0);
            transform.localScale = new Vector3(1, 1, 1);
            m_Image.sprite = m_Sprite[0];
        }
    }

    void DelayUpdate()
    {
        float delay = m_animationDelay;
        m_currentTime += Time.deltaTime;

        if (delay <= m_currentTime)
        {
            m_currentTime -= delay;

            m_aniIndex++;

            if (m_Sprite.Length <= m_aniIndex)
            {
                m_aniIndex = 0;
            }
        }

        m_Image.sprite = m_Sprite[m_aniIndex];
    }

    IEnumerator Move()
    {
        float Counter = 0;
        MoveOn = true;

        transform.DOScale(new Vector3(ScaleValue, ScaleValue, 1), 1.5f);
        while (Counter < 1)
        {
            transform.position = GetPointOnBezierCurve(pos, point[2], point[0], Counter);
            Counter += 0.05f;
            yield return new WaitForSeconds(0.005f);
        }
        Counter = 0;
        while (Counter < 1)
        {
            transform.position = GetPointOnBezierCurve(point[0], point[3], point[1], Counter);
            Counter += 0.05f;
                yield return new WaitForSeconds(0.01f);
        }
        transform.DOMove(new Vector3(PlayerPos.x + 100f, PlayerPos.y-30f, PlayerPos.z), 0.5f);
        yield return new WaitForSeconds(0.5f);
        MoveOn = false;
        yield return null;
    }

    Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float u = 1f - t;
        float t2 = t * t;
        float u2 = u * u;

        Vector3 result =
            (u2) * p0 +
            (2 * t * u) * p1 +
            (t2) * p2;

        return result;
    }
}

