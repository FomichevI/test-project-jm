using UnityEngine;

public class PurchasePackModel
{
    public PackData PackData { get { return _packData; } }
    public int PurchaseCount { get { return _purchaseCount; } }
    public string PackId { get { return _packId; } }

    private PackData _packData; 
    private int _purchaseCount = 1;
    private string _packId; 

    public void InitializeModel(string packId)
    {
        _packId = packId;
        string jsonPackData = PurchasesDataLoader.Instance.GetPurchaseDataString(packId);
        _packData = JsonConverter.ConvertToPackData(jsonPackData);

        if (_packData.Items.Length > 6)
            Debug.LogWarning("Too much items in the pack " + packId + "!");
        else if (_packData.Items.Length < 3)
            Debug.LogWarning("Too few items in the pack " + packId + "!");
    }

    public void IncreaceCount()
    {
        _purchaseCount++;
    }

    public void DecreaseCount()
    {
        if (_purchaseCount > 1)
            _purchaseCount--;
    }
}
