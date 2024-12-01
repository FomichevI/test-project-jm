using UnityEngine;

[RequireComponent(typeof(PurchasePackView))]
public class PurchasePackPopup : MonoBehaviour
{
    private PurchasePackModel _model;
    private PurchasePackView _view;

    public void Show(string packId)
    {
        SetModel(packId);
        _view.Show();
    }

    public void Hide()
    {
        _model = null;
        _view.Hide();
    }

    private void OnEnable()
    {
        _view.OnByeButtonClick.AddListener(OnByeButtonClick);
        _view.OnCountIncreaseButtonClick.AddListener(OnCountIncreaseButtonClick);
        _view.OnCountDecreaseButtonClick.AddListener(OnCountDecreaseButtonClick);
        _view.OnCloseButtonClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _view.OnByeButtonClick.RemoveListener(OnByeButtonClick);
        _view.OnCountIncreaseButtonClick.RemoveListener(OnCountIncreaseButtonClick);
        _view.OnCountDecreaseButtonClick.RemoveListener(OnCountDecreaseButtonClick);
        _view.OnCloseButtonClick.RemoveListener(OnCloseButtonClick);
    }

    private void Awake()
    {
        _view = GetComponent<PurchasePackView>();
    }

    private void SetModel(string packId)
    {
        _model = new PurchasePackModel();
        _model.InitializeModel(packId);
        _view.SetModel(_model);
    }

    private void OnByeButtonClick()
    {
        Debug.Log("Pack " + _model.PackId + "  in the amount of " + _model.PurchaseCount + " was successfully purchased!");
        Hide();
        PopupsController.Instance.ShowChoosePackPopup();
    }

    private void OnCountIncreaseButtonClick()
    {
        _model.IncreaceCount();
        _view.UpdateVisual();
    }

    private void OnCountDecreaseButtonClick()
    {
        _model.DecreaseCount();
        _view.UpdateVisual();
    }

    private void OnCloseButtonClick()
    {
        Hide();
        PopupsController.Instance.ShowChoosePackPopup();
    }
}