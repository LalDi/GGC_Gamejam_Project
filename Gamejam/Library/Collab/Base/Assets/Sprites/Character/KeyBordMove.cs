using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class KeyBordMove : MonoBehaviour
{
    // NOTE : 기획자들의 기획안 변경을 대비하여 키보드 셋팅 

    [Header("좌측 이동")] public KeyCode m_left = KeyCode.LeftArrow;
    [Header("우측 이동")] public KeyCode m_right = KeyCode.RightArrow;
    [Header("상단 이동")] public KeyCode m_top = KeyCode.UpArrow;
    [Header("하단 이동")] public KeyCode m_down = KeyCode.DownArrow;

    [Header("속도 배율")] public float m_speed;

    [HideInInspector] public new Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        // 트랜스폼 캐싱
        transform = GetComponent<Transform>();

        // 중력 제거 / 가속도 삭제
        var rigi = GetComponent<Rigidbody>();
        rigi.useGravity = false;
        rigi.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(m_left))
        {
            transform.Translate(Vector2.left * Time.fixedTime * m_speed);
        }
        if(Input.GetKey(m_right))
        {
            transform.Translate(Vector2.right * Time.fixedTime * m_speed);
        }
        if(Input.GetKey(m_top))
        {
            transform.Translate(Vector2.up * Time.fixedTime * m_speed);
        }
        if(Input.GetKey(m_down))
        {
            transform.Translate(Vector2.down * Time.fixedTime * m_speed);
        }
    }
}
