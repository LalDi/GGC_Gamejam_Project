using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSelfDie : MonoBehaviour
{
    public float m_delay;

    private float m_current;

    // Update is called once per frame
    void Update()
    {
        m_current += Time.deltaTime;

        if(m_delay <= m_current)
        {
            Destroy(this.gameObject);
        }
    }
}
