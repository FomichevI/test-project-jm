using UnityEngine;

// Класс, хранящий в себе текущую конфигаруцию ссылок на внутренние данные приложения
public class LocalDataPathes : MonoBehaviour
{
    public static LocalDataPathes Instance;

    [SerializeField] private LocalDataPathesConfig _config;
    private string _rootFolder;

    public string GetPurchasesFolder()
    { return _rootFolder + _config.PurchasesPath; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        _rootFolder = Application.dataPath;
    }
}
