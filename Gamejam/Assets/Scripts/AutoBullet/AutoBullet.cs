using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoBullet : MonoBehaviour
{
    private GameObject parent;
    public float m_dieDelay;

    // Start is called before the first frame update
    void Start()
    {
        parent = new GameObject("Afterimage Parent");

        var canvas = GameObject.FindObjectOfType<Canvas>();
        parent.transform.SetParent(canvas.transform);
    }

    public void Insert(GameObject _obj)
    {
        _obj.transform.SetParent(parent.transform);
        AutoSelfDie die = _obj.AddComponent<AutoSelfDie>();
        die.m_delay = m_dieDelay;
    }
}
