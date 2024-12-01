using UnityEngine;

//  ласс, контролирубщий работут попапов. ѕри усложнении архитектуры проекта можно будет избавитьс€ от синглтона
// ¬ будущем логика открыти€ и закрыти€ попапов изменитс€ - добавитс€ блюр-бэк и чек на открытие нескольких попапов
// Ќа данном этапе дл€ тестировани€ прототипа этих механик не предусмотренно

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
