using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BulletColor = BulletManager.BulletColor;

public class BossPattern : MonoBehaviour
{
    public GameObject BlueBullet,RedBullet,BlackBullet,GreenBullet,Laser;
    public GameObject player, Boss;

    public Animator Cover;

    public static bool m_fiber;

    public void Start()
    {
        StartCoroutine(Run());
    }

    public int[] PatternList;

    public IEnumerator Run()
    {

        yield return new WaitForSeconds(7);

        StartCoroutine(PatternCircle());

    }

    public IEnumerator PatternCircle()
    {

        var wait = new WaitForSeconds(7.5f);

        for(int i=0;i < PatternList.Length; i++)
        {

            int ChildCount =  BulletManager.Instance.transform.childCount;

            Vector3 subPos = (Boss.transform.localPosition - BulletManager.Instance.transform.localPosition);

            for (int w = 0; w < ChildCount; w++) BulletManager.Instance.transform.GetChild(w).localPosition -= subPos;

            BulletManager.Instance.transform.localPosition = Boss.transform.localPosition;

            PatternRun(PatternList[i]);

            yield return wait;

        }

    }


    public void RoundBullet(int _divide, BulletColor bc)
    {

        float oneRotate = 360f / _divide;

        for(int i=0; i < _divide; i++)
        {
            if (m_fiber)
            {
                BulletManager.Instance.ShotBullet(
                    GreenBullet, oneRotate * i, 300, BulletColor.GREEN);
            }
            else
            {
                BulletManager.Instance.ShotBullet(
                (bc == BulletColor.BLUE) ? BlueBullet : RedBullet, oneRotate * i, 300, bc);
            }
                

        }

    }
    public void RoundBullet(int _divide, float first, BulletColor bc)
    {

        float oneRotate = 360f / _divide;

        for (int i = 0; i < _divide; i++)
        {
            if (m_fiber)
            {
                BulletManager.Instance.ShotBullet(
                    GreenBullet, oneRotate * i + first, 300, BulletColor.GREEN);
            }
            else
            {
                BulletManager.Instance.ShotBullet(
                    (bc == BulletColor.BLUE) ? BlueBullet : RedBullet, oneRotate * i + first, 300, bc);
            }
               

        }

    }
    public void RoundBullet(int _divide, float first, int reverseCount, BulletColor bc)
    {

        float oneRotate = 360f / _divide;

        for (int i = 0; i < _divide; i++)
        {
            if (m_fiber)
            {
                BulletManager.Instance.ShotBullet(
                    GreenBullet, oneRotate * i + first, 300, BulletColor.GREEN);
            }
            else
            {
                BulletManager.Instance.ShotBullet(
                  (bc == BulletColor.BLUE) ? BlueBullet : RedBullet, oneRotate * i + first, 300, bc);
            }
        }

    }

    public void PatternRun(int _num)
    {

        switch (_num)
        {

            case 1:
                StartCoroutine(Pattern1());
                break;
            case 2:
                StartCoroutine(Pattern2());
                break;
            case 3:
                StartCoroutine(Pattern3());
                break;
            case 4:
                StartCoroutine(Pattern4());
                break;
            case 5:
                StartCoroutine(Pattern5());
                break;
            case 6:
                StartCoroutine(Pattern6());
                break;
            case 7:
                StartCoroutine(Pattern7());
                break;

        }

    }

    public IEnumerator Pattern1()
    {

        for (int i = 0; i < 8; i++)
        {  
            RoundBullet(6, 50 * i, 2, (i % 2 == 0) ? BulletColor.RED : BulletColor.BLUE);
            
            yield return new WaitForSeconds(0.8f);

        }

    }
    public IEnumerator Pattern2()
    {

        BulletColor _color = BulletColor.RED;

        var wait = new WaitForSeconds(0.8f);

        for (int i = 0; i < 8; i++)
        {

            RoundBullet(8, _color);

            _color = ReverseColor(_color);

            yield return wait;

        }

    }
    public IEnumerator Pattern3(int _angle = 180)
    {

        var wait = new WaitForSeconds(0.8f);

        float startAngle = _angle - (_angle * 0.5f),
              oneRotate = _angle / 8f;

        BulletColor bc = BulletColor.RED;

        for(int j=0; j < 4; j++)
        {

            for (int i = 0; i < 8; i++)
            {
                if(m_fiber)
                {
                    BulletManager.Instance.ShotBullet(
                   GreenBullet, startAngle + oneRotate * i, 300, BulletColor.GREEN);
                }
                else
                {
                    BulletManager.Instance.ShotBullet(
                   (bc == BulletColor.BLUE) ? BlueBullet : RedBullet, startAngle + oneRotate * i, 300, bc);
                }
               
            }
                

            bc = ReverseColor(bc);

            yield return wait;

        }

    }
    public IEnumerator Pattern4()
    {

        float rotate = 0f;

        BulletColor bc = BulletColor.RED;

        for (int w = 0; w < 8; w++)
        {

            rotate = 40f;

            for (int i = 0; i < 2; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    if(m_fiber)
                    {
                        BulletManager.Instance.ShotBullet(
                            GreenBullet, rotate, 300, BulletColor.GREEN);
                    }
                    else
                    {
                        BulletManager.Instance.ShotBullet(
                        (bc == BulletColor.BLUE) ? BlueBullet : RedBullet, (bc == BulletColor.BLUE) ? rotate + 90.0F : rotate, 300, bc);
                    }
                    

                    rotate += 30f;

                }

                rotate += 80f;

            }

            bc = ReverseColor(bc);
            yield return new WaitForSeconds(0.65f);

        }

    }
    public IEnumerator Pattern5()
    {

        Cover.Play("Cover");

        yield return new WaitForSeconds(0.25f);

        Transform[] lasers = new Transform[4];

        float time = 3f;

        var wait = new WaitForSeconds(time / (time * 60f));

        for (int i = 0; i < 4; i++)
            lasers[i] = BulletManager.Instance.ShotLaser(Laser, 90f * i, (i % 2 == 0) ? BulletColor.RED : BulletColor.BLUE, 1f, time);

        yield return new WaitForSeconds(0.8f);

        for (int i = 0; i < time * 60f; i++)
        {

            for (int j = 0; j < 4; j++)
            {

                if (lasers[j] == null) continue;
                    lasers[j].localEulerAngles += new Vector3(0f, 0f, 2.5f);

            }

            yield return wait;

        }

    }
    public IEnumerator Pattern6()
    {

        float rotate = 0f, addRotate = 0f;

        for(int w=0; w < 4; w++)
        {

            rotate = 0f;

            BulletColor bc = BulletColor.RED;

            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    if(m_fiber)
                    {
                        BulletManager.Instance.ShotBullet(
                        GreenBullet, rotate + addRotate, 300, BulletColor.GREEN);
                    }
                    else
                    {
                        BulletManager.Instance.ShotBullet(
                        (bc == BulletColor.BLUE) ? BlueBullet : RedBullet, rotate + addRotate, (bc == BulletColor.BLUE) ? 300:500, bc);
                    }
                    

                    rotate += 10f;

                }

                rotate += 50f;

                bc = ReverseColor(bc);

            }

            addRotate += 50f;
            yield return new WaitForSeconds(0.8f);

        }

    }
    public IEnumerator Pattern7()
    {

        Vector3 pos = Camera.main.ScreenToViewportPoint(transform.position) - new Vector3(0f, 0f, 50f);

        BulletColor bc = BulletColor.BLACK;
        for (int w = 0; w < 2; w++)
        {
            if(m_fiber)
            {
                BulletManager.Instance.ShotInduction(
                    GreenBullet, 250, BulletColor.GREEN, player, (w % 2 == 0) ? true : false);
            }
            else
            {
                BulletManager.Instance.ShotInduction(
                       BlackBullet, 250, bc, player, (w % 2 == 0) ? true : false);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public BulletColor ReverseColor(BulletColor _color) { return (_color == BulletColor.RED) ? BulletColor.BLUE : BulletColor.RED; }

}
