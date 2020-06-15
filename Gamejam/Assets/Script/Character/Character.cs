using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BulletColor = BulletManager.BulletColor;

public class Character : MonoBehaviour
{

    public BulletColor color;

    [Range(0, 3)]
    public int Hp;

    [Range(0f, 10f)]
    public float Speed;

    [Range(0, 100)]
    public int FeverGauge;

    //피버게이지 증가량
    private float Timer;
    private int FeverUp_Time = 2;
    private int FeverUp_Guard = 1;
    private int FeverUp_Guard_Laser = 5;
    public bool FeverOn;

    public bool isNoDamage;

    public Image trImage;
    public Image characterImage;

    public Image shieldImage;
    public Sprite RedShield;
    public Sprite BlueShield;

    private void Start()
    {

        SoundManager.BackgroundRun("인게임BGM");

        CharacterEvent.addOnFever(() => 
        {

            isSoundEffect = false;

            if (!FeverOn) return;

            StartCoroutine(FeverTime());

            BossPattern.m_fiber = true;
        });

        CharacterEvent.addOnFeverEnd(() => 
        {

            SoundManager.BackgroundRun("인게임BGM");

        });

        CharacterEvent.addOnDamage(() =>
        {

            SoundManager.EffectRun("유저피격");

            StartCoroutine(Damage());

        });
        CharacterEvent.addOnEvasion(() =>
        {

            SoundManager.EffectRun("블루방어막");

        });

        ChangeColor();
    }

    bool isSoundEffect;

    private void Update()
    {
        FeverOn = GameObject.Find("FiverCharacter").GetComponent<UI_Special>().OnSpecial;
        Timer += Time.deltaTime;
        if (Timer > 1)
        {
            FeverGauge += FeverUp_Time;
            Timer = 0;        

        }

        if (FeverGauge >= 100 && !isSoundEffect)
        {

            isSoundEffect = true;
            SoundManager.EffectRun("특수기조건달성");

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (isNoDamage) return;

        Transform target = other.transform;

        if (target.CompareTag(color.ToString())) {
            if (target.name == "Laser")
                FeverGauge += FeverUp_Guard_Laser;
            else
                FeverGauge += FeverUp_Guard;

            StartCoroutine(Shield(color));

            CharacterEvent.callOnEvasion();

        } 
        else if (target.CompareTag(diffrentColor()) || target.CompareTag("BLACK"))
        {
            Hp -= 1;
            CharacterEvent.callOnDamage();
        }

        if (target.name == "Bullet") Destroy(target.gameObject);

    }

    private void OnDestroy()
    {

        CharacterEvent.OnFever.RemoveAllListeners();

    }

    public string diffrentColor()
    {
        return (color == BulletColor.RED) ? "BLUE" : "RED";
    }

    public void ChangeColor()
    {

        color = (color == BulletColor.RED) ? BulletColor.BLUE : BulletColor.RED;

        // NOTE : 기획자가 원한 컬러값
        trImage.color = (color == BulletColor.RED) ? new Color(0.8745098039215686F, 0, 0) : new Color(0, 0.2941176470588235F, 1.0F);


    }

    public IEnumerator FeverTime()
    {

        BulletManager.Instance.BulletStop();
        GameObject.Find("FiverCharacter").GetComponent<UI_Special>().OnSpecial = false;

        SoundManager.EffectRun("특수기사용");
        SoundManager.BackgroundRun("특수기BGM");

        yield return new WaitForSeconds(10f);

        BulletManager.Instance.BulletMove();

        CharacterEvent.callOnFeverEnd();
        BossPattern.m_fiber = false;
    }

    public IEnumerator Damage()
    {

        isNoDamage = true;

        float oneTime = 0.25f;

        for(int i=0; i < 8; i++)
        {
            trImage.color += (i % 2 == 0) ?
                new Color(0f, 0f, 0f, -1f) : new Color(0f, 0f, 0f, 1f);

            characterImage.color += (i % 2 == 0) ?
                new Color(0f, 0f, 0f, -1f) : new Color(0f, 0f, 0f, 1f);

            yield return new WaitForSeconds(oneTime);

        }

        isNoDamage = false;

    }

    public IEnumerator Shield(BulletColor _color)
    {
        shieldImage.color = new Color(1, 1, 1, 1);

        if(_color == BulletColor.RED)
        {
            shieldImage.sprite = RedShield;
        }
        else
        {
            shieldImage.sprite = BlueShield;
        }

        const int indexMax = 5;
        for (int index = 0; index < indexMax; index++)
        {
            shieldImage.color = new Color(1, 1, 1, 1.0F * ((float)index * 2/ indexMax));
            yield return new WaitForSeconds(0.05F);
        }
        for (int index = indexMax; 0 < index; index--)
        {
            shieldImage.color = new Color(1, 1, 1, 1.0F * ((float)index / indexMax));
            yield return new WaitForSeconds(0.05F);
        }
        
        

        shieldImage.color = new Color(1, 1, 1, 0);
    }

}
