using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BulletColor = BulletManager.BulletColor;

public class Bullet : MonoBehaviour
{
    public BulletColor color;
    public float Speed;
    public Vector3 Direction;

    public void initialized()
    {
        Image colorSet = GetComponent<Image>(); 

        transform.tag = color.ToString();

        transform.name = "Bullet";
    }

    private void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        Transform target = other.transform;

        if (target.CompareTag("EndLine"))
        {
            //if(color != BulletColor.GREEN)
            //{
            //    BulletPooling.Instance.Push(gameObject);
            //}
            //else
            //{
            //    transform.localPosition = Vector3.one * 10000f;
            //}
            Destroy(gameObject);

            Speed = 0;

        }

        if (transform.CompareTag("PLAYER") && (target.CompareTag("RED") || target.CompareTag("BLUE") || target.CompareTag("GREEN")))
        {

            transform.SetParent(FeverBulletManager.Instance.transform);

            Speed = 0;

            gameObject.SetActive(false);

            GameManager.Instance.FeverScore += 10;

            Vector3 pos = Camera.main.ScreenToViewportPoint(transform.position) - new Vector3(0f, 0f, 50f);

            EffectManager.Create(pos, "DamageBullet");

            SoundManager.EffectRun("점수획득");

            Destroy(target.gameObject);

        }

    }

}
