using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAnimation : MonoBehaviour
{
    public Image m_target;

    public Sprite[] m_sprites;
    public float m_delay;

    public void On(Image _taget)
    {
        m_target = _taget;
        StartCoroutine(StartRun());
    }
    public void Off(Image _taget)
    {
        m_target = _taget;
        StartCoroutine(EndRun());
    }

    private IEnumerator StartRun()
    {
        WaitForSeconds wait = new WaitForSeconds(m_delay);

        for(int index = m_sprites.Length-1; 0<= index; index--)
        {
            m_target.sprite = m_sprites[index];

            yield return wait;
        }
    }
    private IEnumerator EndRun()
    {
        WaitForSeconds wait = new WaitForSeconds(m_delay);

        for (int index = 0; index < m_sprites.Length; index++)
        {
            m_target.sprite = m_sprites[index];

            yield return wait;
        }
    }
}
