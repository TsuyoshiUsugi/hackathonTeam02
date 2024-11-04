using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    private float _tweenTime = 0.2f;
    Vector3 _upScale = Vector3.one * 1.1f;

    public void OnPointerDown(PointerEventData eventData)
    {
        FindAnyObjectByType<SoundManager>().PlayOneShotSound(SoundManager.ONE_SHOT_SOUND.Click);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.DOScale(_upScale, _tweenTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.DOScale(Vector3.one, _tweenTime);
    }
}
