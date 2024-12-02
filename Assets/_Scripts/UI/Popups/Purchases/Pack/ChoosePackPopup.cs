using UnityEngine;

// ¬ременный попап, в будущем будет удален или заменен
[RequireComponent(typeof(ChoosePackPopupView))]
public class ChoosePackPopup : MonoBehaviour
{
    private ChoosePackPopupView _view;

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }

    public void ByePack1()
    {
        // ѕроверка на наличие покупки дл€ упрощени€
        if (!PurchasesDataLoader.Instance.HasPurchaseData("TestPack_1"))
            return;

        Hide();
        // ’ардкод id покупки, в будущем будет передоватьс€ извне в зависимости от логики работы магазина
        PopupsController.Instance.ShowPurchasePackPopup("TestPack_1");
    }

    public void ByePack2()
    {
        // ѕроверка на наличие покупки дл€ упрощени€
        if (!PurchasesDataLoader.Instance.HasPurchaseData("TestPack_2"))
            return;

        Hide();
        // ’ардкод id покупки, в будущем будет передоватьс€ извне в зависимости от логики работы магазина
        PopupsController.Instance.ShowPurchasePackPopup("TestPack_2");
    }

    private void Awake()
    {
        _view = GetComponent<ChoosePackPopupView>();
    }

    private void OnEnable()
    {
        _view.OnByePack1Click.AddListener(ByePack1);
        _view.OnByePack2Click.AddListener(ByePack2);
    }

    private void OnDisable()
    {
        _view.OnByePack1Click.RemoveListener(ByePack1);
        _view.OnByePack2Click.RemoveListener(ByePack2);
    }
}
