using UnityEngine;

// �����, �������������� ������� �������. ��� ���������� ����������� ������� ����� ����� ���������� �� ���������
// � ������� ������ �������� � �������� ������� ��������� - ��������� ����-��� � ��� �� �������� ���������� �������
// �� ������ ����� ��� ������������ ��������� ���� ������� �� ��������������

public class PopupsController : MonoBehaviour
{
    public static PopupsController Instance { get; private set;}
    [SerializeField] private PurchasePackPopup _purchasePackPopup;
    [SerializeField] private ChoosePackPopup _choosePackPopup;

    public void ShowPurchasePackPopup(string packId)
    {
        _purchasePackPopup.Show(packId);
    }

    public void ShowChoosePackPopup()
    {
        _choosePackPopup.Show();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
