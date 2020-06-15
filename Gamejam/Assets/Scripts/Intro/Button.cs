using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public void OnPointerEnter(PointerEventData data)
    {
        SoundManager.EffectRun("로비마우스오버");
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    public void OnPointerDown(PointerEventData data)
    {
        SoundManager.EffectRun("로비마우스클릭");
    }

    public void OnPointerExit(PointerEventData data)
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
