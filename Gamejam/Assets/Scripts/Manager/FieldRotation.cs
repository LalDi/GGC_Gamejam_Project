using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldRotation : MonoBehaviour
{
    public GameObject m_fieldBase;
    public GameObject m_fieldSub;
    public float m_zSize = 10;
    public float m_speed;
    public bool m_baseSubFlag = true;

    [SerializeField] private float m_moveValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float zValue = m_speed * Time.deltaTime;
        Vector3 zMove = new Vector3(zValue, 0, 0);

        m_moveValue += zValue;

        if(m_zSize <= m_moveValue)
        {
            if(m_baseSubFlag)
            {
                m_fieldBase.transform.position = m_fieldSub.transform.position + new Vector3(0, 0, m_zSize);
            }
            else
            {
                m_fieldSub.transform.position = m_fieldBase.transform.position + new Vector3(0, 0, m_zSize);
            }

            m_baseSubFlag = !m_baseSubFlag;

            m_moveValue -= m_zSize;
        }
        
        m_fieldBase.transform.Translate(zMove);
        m_fieldSub.transform.Translate(zMove); 
    }
}
