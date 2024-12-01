using UnityEngine;

// Временный попап, в будущем будет удален или заменен
[RequireComponent(typeof(SimplePopupView))]
public class ChoosePackPopup : MonoBehaviour
{
    private SimplePopupView _view;

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }

    public void OnClickByePack1()
    {
        Hide();
        PopupsController.Instance.ShowPurchasePackPopup("TestPack_1");
    }

    public void OnClickByePack2()
    {
        Hide();
        PopupsController.Instance.ShowPurchasePackPopup("TestPack_2");
    }

    private void Awake()
    {
        _view = GetComponent<SimplePopupView>();
    }
}
