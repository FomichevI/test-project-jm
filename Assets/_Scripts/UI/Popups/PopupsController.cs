using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// � ������� ������ �������� � �������� ������� ��������� - ��������� ����-��� � ��� �� �������� ���������� �������
// �� ������ ����� ��� ������������ ��������� ���������� ������ ������ �� OpenPackButton ��� �� ���������� � ���������

public class PopupsController : MonoBehaviour
{
    [SerializeField] private PurchasePackPopup _purchasePackPopup;

    public void ShowPackPopup(string packId)
    {
        _purchasePackPopup.Show(packId);
    }
}
