using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePackModel
{
    public PackData PackData { get { return _packData; } }
    public int PurchaseCount { get { return _purchaseCount; } }

    private PackData _packData; 
    private int _purchaseCount = 1;

    public void InitializeModel(string packId)
    {
        _packData = JsonConverter.ConvertToPackData(PurchasesData.Instance.GetPurchaseDataString(packId));

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
