using TMPro;
using UnityEngine;
using UnityEngine.UI;

// �����, ���������� �� ����������� ������ ������ �� UI (���� ��� ������������ ������ � ���� �������)
public class RosouceItem : MonoBehaviour
{
    [SerializeField] private Image _iconImg;
    [SerializeField] private TextMeshProUGUI _countTmp;

    public void SetVisual(Sprite sprite, int count)
    {
        _iconImg.sprite = sprite;
        _countTmp.text = count.ToString();
    }
}
