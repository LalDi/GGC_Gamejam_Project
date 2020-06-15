using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_SpecialGauge : MonoBehaviour
{
    private Image Gauge;
    [Range(0, 100)] private int GetGauge;

    private int MaxGauge = 100;

    public bool Full = false;

    void Start()
    {
        Gauge = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        GetGauge = GameObject.Find("Player").GetComponent<Character>().FeverGauge;
        Gauge.fillAmount = Mathf.Lerp(0f, 1f, (float)GetGauge / MaxGauge);

        if (GetGauge >= MaxGauge)
            Full = true;
        else
            Full = false;
    }
}
