using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Afterimage : MonoBehaviour
{
    public AutoBullet m_autoBullet;
    public float m_delay;
    public Vector2 m_scale;

    private float current;

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;

        if(m_delay <= current)
        {
            current -= m_delay;

            GameObject obj = new GameObject("afterimage");
            Image image = obj.AddComponent<Image>();
            image.sprite = GetComponent<Image>().sprite;
            obj.transform.position = this.transform.position;
            obj.transform.localScale = m_scale;

            m_autoBullet.Insert(obj);
        }
    }
}
