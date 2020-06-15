using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverBulletManager : MonoBehaviour
{

    private static FeverBulletManager _instance;
    public static FeverBulletManager Instance
    {

        get
        {

            if (!_instance) _instance = FindObjectOfType(typeof(FeverBulletManager)) as FeverBulletManager;

            return _instance;

        }

    }

    public Vector3 Destination;

    private void Start()
    {

        CharacterEvent.addOnFeverEnd(() =>
        {

            int ChildCount = transform.childCount;

            for (int i = 0; i < ChildCount; i++)
            {

                Transform _bullet = transform.GetChild(i);

                _bullet.gameObject.SetActive(true);

                Bullet _bulletComp = _bullet.GetComponent<Bullet>();

                _bulletComp.Direction = (Destination - _bullet.localPosition).normalized;

                _bulletComp.Speed = 300f;

            }


        });

    }

}
