using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class KeyBordMove : MonoBehaviour
{
    // NOTE : 기획자들의 기획안 변경을 대비하여 키보드 셋팅 

    private KeyCode m_left = KeyCode.A;
    private KeyCode m_right = KeyCode.D;
    private KeyCode m_top = KeyCode.W;
    private KeyCode m_down = KeyCode.S;

    [Space(40)]
    public Image m_characterImage;
    public Image m_cloakImage;
    public float m_animationDelay;
    public float m_idleDelayMulty = 2.0F;
    [Header("캐릭터 이미지")]
    public Sprite[] m_leftSprites;
    public Sprite[] m_rightSprites;
    public Sprite[] m_upDownSprites;
    [Header("망토 이미지")]
    public Sprite[] m_leftCloakSprites;
    public Sprite[] m_rightCloakSprites;
    public Sprite[] m_upDownCloakSprites;

    private float m_currentTime;
    private int m_aniIndex;
    private KeyCode m_currentKeyCode;
    private KeyCode m_currentArrowCode;
    

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

        m_currentKeyCode = m_top;
    }

    private void Update()
    {
        float delay = m_animationDelay;
        if(m_currentKeyCode == m_top)
        {
            delay *= m_idleDelayMulty;
        }

        m_currentTime += Time.deltaTime;

        if(delay <= m_currentTime)
        {
            m_currentTime -= delay;

            m_aniIndex++;

            if(m_leftSprites.Length <= m_aniIndex)
            {
                m_aniIndex = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(m_left) || Input.GetKey(KeyCode.LeftArrow))
        {
            KeySet(m_left, KeyCode.LeftArrow);
        }
        if(Input.GetKey(m_right) || Input.GetKey(KeyCode.RightArrow))
        {
            KeySet(m_right, KeyCode.RightArrow);
        }
        if(Input.GetKey(m_top) || Input.GetKey(KeyCode.UpArrow))
        {
            KeySet(m_top, KeyCode.UpArrow);
        }
        if(Input.GetKey(m_down) || Input.GetKey(KeyCode.DownArrow))
        {
            // 위 방향과 아래방향 애니메이션이 같으므로 이렇게 처리함.
            KeySet(m_top, KeyCode.UpArrow);
        }

        if(!Input.GetKey(m_currentKeyCode) && !Input.GetKey(m_currentArrowCode))
        {
            KeySet(m_top, KeyCode.UpArrow);
        }

        AnimationUpdate();
    }

    public void KeySet(KeyCode _key,KeyCode _arrow)
    {
        if (m_currentKeyCode != _key)
        {
            m_aniIndex = 0;
            m_currentTime = 0;
        }

        m_currentKeyCode = _key;
        m_currentArrowCode = _arrow;
    }

    public void AnimationUpdate()
    {
        if(m_currentKeyCode == m_left)
        {
            m_characterImage.sprite = m_leftSprites[m_aniIndex];
            m_cloakImage.sprite = m_leftCloakSprites[m_aniIndex];
        }
        if (m_currentKeyCode == m_right)
        {
            m_characterImage.sprite = m_rightSprites[m_aniIndex];
            m_cloakImage.sprite = m_rightCloakSprites[m_aniIndex];
        }
        if (m_currentKeyCode == m_top)
        {
            m_characterImage.sprite = m_upDownSprites[m_aniIndex];
            m_cloakImage.sprite = m_upDownCloakSprites[m_aniIndex];
        }
    }
}
