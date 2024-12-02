using UnityEngine;

// ��������� �����, � ������� ����� ������ ��� �������
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
        // �������� �� ������� ������� ��� ���������
        if (!PurchasesDataLoader.Instance.HasPurchaseData("TestPack_1"))
            return;

        Hide();
        // ������� id �������, � ������� ����� ������������ ����� � ����������� �� ������ ������ ��������
        PopupsController.Instance.ShowPurchasePackPopup("TestPack_1");
    }

    public void ByePack2()
    {
        // �������� �� ������� ������� ��� ���������
        if (!PurchasesDataLoader.Instance.HasPurchaseData("TestPack_2"))
            return;

        Hide();
        // ������� id �������, � ������� ����� ������������ ����� � ����������� �� ������ ������ ��������
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
