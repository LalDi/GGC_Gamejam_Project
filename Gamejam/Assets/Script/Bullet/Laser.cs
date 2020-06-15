using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BulletColor = BulletManager.BulletColor;

public class Laser : MonoBehaviour
{

    public GameObject _PointLine, _Laser;

    public BulletColor color;

    public float AttackTime = 1f, LifeTime = 1f;

    BoxCollider trBoxCollider;

    public void initialized()
    {

        trBoxCollider = GetComponent<BoxCollider>();

        Color _color = (color == BulletColor.RED) ? Color.red : Color.blue;

        _Laser.GetComponent<Image>().color =
        _color;

        transform.tag = color.ToString();

        transform.localPosition = Vector3.zero;

        transform.name = "Laser";

    }

    public void Shot() { StartCoroutine(ShotLaser()); }

    public IEnumerator ShotLaser()
    {

        trBoxCollider.enabled = false;
        _Laser.SetActive(false);
        _PointLine.SetActive(true);

        yield return new WaitForSeconds(AttackTime);

        _Laser.SetActive(true);
        trBoxCollider.enabled = true;

        yield return new WaitForSeconds(LifeTime);

        Destroy(gameObject);

    }

}
