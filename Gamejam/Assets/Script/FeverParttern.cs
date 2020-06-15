using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverParttern : MonoBehaviour
{

    public bool isPattern;

    public GameObject[] Shapes;

    private void Update()
    {

        if (isPattern)
        {

            StartCoroutine(Pattern1(1));

            isPattern = false;

        }

    }

    public void ShotShapes(int _num)
    {

        GameObject Shape = Instantiate(Shapes[_num]);

        Shape.transform.SetParent(BulletManager.Instance.transform, false);

        int ChildCount = Shapes[_num].transform.childCount;

        for (int i = 0; i < ChildCount; i++)
        {

            Transform peace = Shapes[_num].transform.GetChild(i);

            int BulletCount = peace.childCount;

            peace.gameObject.SetActive(true);

            Bullet _bullet = peace.GetComponent<Bullet>();

            _bullet.Speed = 100;
            _bullet.Direction = new Vector3(0f, -1f, 0f);

        }

    }
    public void ShotShapes(Vector3 pos, int _num)
    {

        GameObject Shape = Instantiate(Shapes[_num]);

        Shape.transform.localPosition = pos;

        Shape.transform.SetParent(BulletManager.Instance.transform, false);

        int ChildCount = Shapes[_num].transform.childCount;

        for (int i = 0; i < ChildCount; i++)
        {

            Transform peace = Shapes[_num].transform.GetChild(i);

            int BulletCount = peace.childCount;

            peace.gameObject.SetActive(true);

            Bullet _bullet = peace.GetComponent<Bullet>();

            _bullet.Speed = 100;
            _bullet.Direction = new Vector3(0f, -1f, 0f);

        }

    }

    public IEnumerator Pattern1(float _time)
    {

        for(int i=0; i < 5; i++)
        {

            ShotShapes(new Vector3(-400f + 200f * i, 0f, 0f), i);

            yield return new WaitForSeconds(_time);

        }

    }
    public IEnumerator Pattern2(float _time)
    {

        for (int i = 0; i < 2; i++)
        {

            ShotShapes(5);

            yield return new WaitForSeconds(_time);

        }

    }
    public void Pattern3() { ShotShapes(6); }

}
