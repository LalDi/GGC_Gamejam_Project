using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    public bool isFever;

    private void Start()
    {

        CharacterEvent.addOnFever(() => { isFever = true; StartCoroutine(AttackLoop()); });
        CharacterEvent.addOnFeverEnd(() => { isFever = false; });

    }

    public void Attack()
    {

        BulletManager.Instance.ShotPlayerBullet(transform.localPosition, 300).localPosition += new Vector3(50, 0f, 0f);
        BulletManager.Instance.ShotPlayerBullet(transform.localPosition, 300).localPosition += new Vector3(-50, 0f, 0f);

    }

    public IEnumerator AttackLoop()
    {

        Attack();

        yield return new WaitForSeconds(0.25f);

        if(isFever) StartCoroutine(AttackLoop());

    }

}
