using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletColor = BulletManager.BulletColor;

public class BulletPooling : MonoBehaviour
{

    private static BulletPooling _instance;
    public static BulletPooling Instance
    {

        get
        {

            if (_instance == null)
            {

                GameObject go = new GameObject();
                go.name = "BulletPooling";
                _instance = go.AddComponent<BulletPooling>();

            }

            return _instance;

        }
        
    }

    public Queue<GameObject> Bullets;

    private void Awake()
    {

        Bullets = new Queue<GameObject>();

    }

    public void Push(GameObject _bullet)
    {

        _bullet.transform.parent = transform;

        _bullet.transform.localPosition = Vector3.one * 10000f;

        Bullets.Enqueue(_bullet);

    }

    public GameObject Pop(BulletColor _color)
    {

        if (Bullets.Count < 1) return null;

        GameObject go = null;

        while (true)
        {
            if (Bullets.Count == 0) return null;

            go = Bullets.Dequeue();

            if(go != null)
            {
                Bullet bullet = go.GetComponent<Bullet>();

                if(bullet.color == _color)
                {
                    break;
                }
            }
        }
       
        go.transform.localPosition = Vector3.zero;

        return go;

    }

}
