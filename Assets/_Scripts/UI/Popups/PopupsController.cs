using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// В будущем логика открытия и закрытия попапов изменится - добавится блюр-бэк и чек на открытие нескольких попапов
// На данном этапе для тестирования прототипа используем прямую ссылку на OpenPackButton для ее отключения и включения

public class PopupsController : MonoBehaviour
{
    [SerializeField] private PurchasePackPopup _purchasePackPopup;

    public void ShowPackPopup(string packId)
    {
        _purchasePackPopup.Show(packId);
    }
}
