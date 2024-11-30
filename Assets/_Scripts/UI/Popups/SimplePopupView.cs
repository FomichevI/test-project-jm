using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class SimplePopupView : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    public virtual void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public virtual void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
}
