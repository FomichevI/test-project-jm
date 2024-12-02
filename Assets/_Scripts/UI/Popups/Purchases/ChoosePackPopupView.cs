using UnityEngine;
using UnityEngine.Events;

public class ChoosePackPopupView : SimplePopupView
{
    [HideInInspector] public UnityEvent OnByePack1Click = new UnityEvent();
    [HideInInspector] public UnityEvent OnByePack2Click = new UnityEvent();

    public void ByePack1Click()
    { OnByePack1Click?.Invoke(); }

    public void ByePack2Click()
    { OnByePack2Click?.Invoke(); }
}
