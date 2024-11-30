using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Ќужно учитывать, что в будущем структура усложнитс€ и данный класс, скорее всего, не нужно будет наследовать от MonoBehaviour
// ѕока что это сделано дл€ упрощени€ 
// “ак же в будущем этот класс будет запрашивать информацию о цене покупки и возвращать ее

public class PurchasesData : MonoBehaviour
{
    public static PurchasesData Instance;
    public PurchasesConfig Config { get { return _config; } }

    [SerializeField] private PurchasesConfig _config;

    private string _path;

    public string GetPurchaseDataString(string purchaseId)
    {
        string fullPath = _path + purchaseId + ".txt";
        if (File.Exists(fullPath))
        {
            using StreamReader reader = new StreamReader(fullPath);
            string jsonString = reader.ReadToEnd();
            return jsonString;
        }
        else
        {
            Debug.LogError("File " + fullPath + " is not found");
            return null;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        _path = Application.dataPath + "/TestPurchases/";
    }
}