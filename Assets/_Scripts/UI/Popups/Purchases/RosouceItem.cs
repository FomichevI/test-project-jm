using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Класс, отвечающий за отображение одного айтема на UI (пока что используется только в окне покупок)
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
