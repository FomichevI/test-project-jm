using System.IO;
using UnityEngine;

//  ласс, отвечающий за загрузку данных о покупке.
// Ќужно учитывать, что в будущем структура усложнитс€ и данный класс, скорее всего, не нужно будет наследовать от MonoBehaviour
// ѕока что это сделано дл€ упрощени€ 

public class PurchasesDataLoader : MonoBehaviour
{
    public static PurchasesDataLoader Instance;
    public PurchasesConfig Config { get { return _config; } }

    [SerializeField] private PurchasesConfig _config;

    private string _path;

    public bool HasPurchaseData(string purchaseId)
    {
        string fullPath = _path + purchaseId + ".txt";
        if (File.Exists(fullPath))
        {
            return true;
        }
        else
        {
            Debug.LogError("File " + fullPath + " is not found");
            return false;
        }
    }

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
            Debug.LogError("File " + fullPath + " is not found. Call HasPurchaseData(string purchaseId) before GetPurchaseDataString(string purchaseId).");
            return null;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _path = LocalDataPathes.Instance.GetPurchasesFolder();
    }
}