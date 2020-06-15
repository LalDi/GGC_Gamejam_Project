using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverEffect : MonoBehaviour
{

    Animator trAnimator;

    private void Awake()
    {

        trAnimator = GetComponent<Animator>();

    }

    private void Start()
    {

        CharacterEvent.addOnFever(() =>
        {

            trAnimator.speed = 1f;
            trAnimator.Play("in");

        });

        CharacterEvent.addOnFeverEnd(() =>
        {

            trAnimator.speed = 1f;
            trAnimator.Play("out");

        });

    }

    public void AniStop() { trAnimator.speed = 0f; }

}
