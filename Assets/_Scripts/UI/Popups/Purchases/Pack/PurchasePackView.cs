using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PurchasePackView : SimplePopupView
{
    [HideInInspector] public UnityEvent OnByeButtonClick = new UnityEvent();
    [HideInInspector] public UnityEvent OnCountIncreaseButtonClick = new UnityEvent();
    [HideInInspector] public UnityEvent OnCountDecreaseButtonClick = new UnityEvent();
    [HideInInspector] public UnityEvent OnCloseButtonClick = new UnityEvent();

    [SerializeField] private TextMeshProUGUI _headerTmp;
    [SerializeField] private TextMeshProUGUI _descriptionTmp;
    [SerializeField] private Transform _itemsGroupTrans;
    [SerializeField] private Image _mainIconImg;
    [SerializeField] private TextMeshProUGUI _countTmp;

    [Header("Bye button")]
    [SerializeField] private TextMeshProUGUI _priceTmp;
    [SerializeField] private TextMeshProUGUI _fullPriceTmp;
    [SerializeField] private TextMeshProUGUI _discountTmp;
    [SerializeField] private GameObject _discount;

    [Header("Prefabs")]
    [SerializeField] private GameObject _rowPrefab;
    [SerializeField] private RosouceItem _itemPrefab;

    private PurchasePackModel _model;
    private List<GameObject> _currentRows = new List<GameObject>();

    public override void Show()
    {
        SetVisual();
        base.Show();
    }

    public override void Hide()
    {
        DestroyRows();
        base.Hide();
    }

    public void SetModel(PurchasePackModel model)
    { 
        _model = model; 
    }

    public void UpdateVisual()
    {
        _countTmp.text = _model.PurchaseCount.ToString();
        SetPrice();
    }

    #region Buttons
    public void ByeButtonClick()
    { OnByeButtonClick?.Invoke(); }

    public void CountIncreaseButtonClick()
    { OnCountIncreaseButtonClick?.Invoke(); }

    public void CountDecreaseButtonClick()
    { OnCountDecreaseButtonClick?.Invoke(); }

    public void CloseButtonClick()
    { OnCloseButtonClick?.Invoke(); }
    #endregion

    private void SetVisual()
    {
        _headerTmp.text = _model.PackData.HeaderText;
        _descriptionTmp.text = _model.PackData.DescriptionText;
        CreateItems();
        _mainIconImg.sprite = PurchasesData.Instance.Config.GetSpriteById(_model.PackData.IconId);
        _countTmp.text = _model.PurchaseCount.ToString();
        SetPrice();
    }

    private void CreateItems()
    {
        if (_model.PackData.Items.Length < 3)
            return;

        Transform currentRowTrans = Instantiate(_rowPrefab, _itemsGroupTrans).transform;
        _currentRows.Add(currentRowTrans.gameObject);
        for (int i = 0; i < 3; i++)
        {
            RosouceItem item = Instantiate(_itemPrefab, currentRowTrans);
            Sprite icon = PurchasesData.Instance.Config.GetSpriteById(_model.PackData.Items[i].ItemId);
            item.SetVisual(icon, _model.PackData.Items[i].Count);
        }

        if (_model.PackData.Items.Length > 3)
        {
            currentRowTrans = Instantiate(_rowPrefab, _itemsGroupTrans).transform;
            _currentRows.Add(currentRowTrans.gameObject);
            for (int i = 3; i < _model.PackData.Items.Length; i++)
            {
                RosouceItem item = Instantiate(_itemPrefab, currentRowTrans);
                Sprite icon = PurchasesData.Instance.Config.GetSpriteById(_model.PackData.Items[i].ItemId);
                item.SetVisual(icon, _model.PackData.Items[i].Count);
            }
        }
    }

    private void SetPrice()
    {
        float price = _model.PackData.DiscountedPrice;
        float fullPrice = _model.PackData.FullPrice;

        _priceTmp.text = _model.PackData.Currency + (price * _model.PurchaseCount).ToString();
        if (price >= fullPrice)
        {
            _fullPriceTmp.gameObject.SetActive(false);
            _discount.SetActive(false);
        }
        else
        {
            _fullPriceTmp.gameObject.SetActive(true);
            _discount.SetActive(true);
            _fullPriceTmp.text = _model.PackData.Currency + (fullPrice * _model.PurchaseCount).ToString();
            _discountTmp.text ="-" + Mathf.Round((fullPrice - price) / fullPrice * 100).ToString() + "%";
        }
    }

    private void DestroyRows()
    {
        for (int i = _currentRows.Count - 1; i >= 0; i--) 
        {
            Destroy(_currentRows[i]);
            _currentRows.RemoveAt(i);
        }
    }
}
