using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{

    private static BulletManager _instance;
    public static BulletManager Instance
    {

        get
        {

            if (!_instance) _instance = FindObjectOfType(typeof(BulletManager)) as BulletManager;

            return _instance;

        }

    }

    public enum BulletColor
    {

        RED,
        BLUE,
        BLACK,
        GREEN

    }

    private void Start()
    {

        CharacterEvent.addOnFever(() =>
        {

            int ChildCount = transform.childCount;

            for (int i=0; i < ChildCount; i++) Destroy(transform.GetChild(i).gameObject);

        });

    }

    public GameObject BlueBullet,RedBullet, Laser;

    public float Velocity = 1;

    public Transform ShotBullet(GameObject _bullet, float _angle, float _speed, BulletColor _color)
    {

        var que = Quaternion.Euler(0, _angle, 0);

        Vector3 normalVector = que * transform.forward;

        // GameObject b = BulletPooling.Instance.Pop(_color);

        Bullet bullet = Instantiate(_bullet).AddComponent<Bullet>();

        bullet.gameObject.SetActive(true);
        bullet.transform.parent = transform;

        bullet.transform.localPosition = Vector3.zero;

        bullet.Direction = new Vector3(normalVector.x, normalVector.z, 0f);
        bullet.Speed = _speed * Velocity;
        bullet.color = _color;

        bullet.initialized();

        return bullet.transform;

    }
    public Transform ShotPlayerBullet(Vector3 p_pos, float _speed)
    {

        Bullet bullet = Instantiate(BlueBullet).AddComponent<Bullet>();

        bullet.gameObject.SetActive(true);
        bullet.transform.parent = transform;

        bullet.transform.localPosition = p_pos + new Vector3(0f, 100f, 0f) - BulletManager.Instance.transform.localPosition;

        bullet.Direction = new Vector3(0, 1, 0f);
        bullet.Speed = _speed;

        bullet.initialized();

        bullet.tag = "PLAYER";

        bullet.GetComponent<BoxCollider>().isTrigger = false;
        bullet.gameObject.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        bullet.gameObject.GetComponent<Rigidbody>().useGravity = false;

        return bullet.transform;

    }

    public Transform ShotLaser(GameObject _laser, float _angle, BulletColor _color)
    {

        Transform laser = Instantiate(_laser).transform;

        laser.gameObject.SetActive(true);

        laser.parent = transform;
        laser.localPosition = Vector3.zero;

        laser.localEulerAngles = new Vector3(0f, 0f, _angle);

        Laser laser_script = laser.GetComponent<Laser>();

        laser_script.color = _color;

        laser_script.initialized();

        laser_script.Shot();

        return laser;

    }
    public Transform ShotLaser(GameObject _laser, float _angle, BulletColor _color, float _attackTime, float _lifeTime)
    {

        Transform laser = Instantiate(_laser).transform;

        laser.gameObject.SetActive(true);

        laser.parent = transform;
        laser.localPosition = Vector3.zero;

        laser.localEulerAngles = new Vector3(0f, 0f, _angle);

        Laser laser_script = laser.GetComponent<Laser>();

        laser_script.color = _color;
        laser_script.AttackTime = _attackTime;
        laser_script.LifeTime = _lifeTime;

        laser_script.initialized();

        laser_script.Shot();

        return laser;

    }

    public void ShotInduction(GameObject _bullet, float _speed, BulletColor _color,GameObject _player,bool _right)
    {
        //GameObject b = BulletPooling.Instance.Pop(_color);

        Bullet bullet = Instantiate(_bullet).AddComponent<Bullet>();

        bullet.gameObject.SetActive(true);
        bullet.transform.parent = transform;

        bullet.transform.localPosition = Vector3.zero;

        bullet.Speed = _speed * Velocity;
        bullet.color = _color;
        bullet.Direction = Vector2.up;


        bullet.initialized();

        StartCoroutine(CoroutineShotInduction(bullet, _player, _right));
    }

    public IEnumerator CoroutineShotInduction(Bullet _bullet,GameObject _target,bool _right)
    {
        const int indexMax = 270;

        for(int index = 0; index < indexMax; index++)
        {
            try
            {
                Vector3 normal = (_target.transform.position - _bullet.transform.position).normalized;

                if (_right)
                {
                    normal = Quaternion.Euler(0, 0, 180 - (180.0F / indexMax) * index) * normal;
                }
                else
                {
                    normal = Quaternion.Euler(0, 0, 180 + (180.0F / indexMax) * index) * normal;
                }

                _bullet.Direction = normal;
            }
            catch(MissingReferenceException)
            {
                break;
            }

            yield return null;
        }
        
    }


    public void BulletStop() { Velocity = 0.5f; }
    public void BulletMove() { Velocity = 1; }

}
