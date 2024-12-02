using UnityEngine;

[CreateAssetMenu(fileName = "LocalDataPathesConfig", menuName = "ScriptableObjects/LocalDataPathesConfig", order = 1)]
public class LocalDataPathesConfig : ScriptableObject
{
    public string PurchasesPath { get { return _purchasesFolder; } }

    [SerializeField] private string _purchasesFolder; 
}
