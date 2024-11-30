using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PurchasesConfig", menuName = "ScriptableObjects/PurchasesConfig", order = 1)]
public class PurchasesConfig : ScriptableObject
{
    [SerializeField] private VisualUiItemConfig[] _items;

    public Sprite GetSpriteById(string itemId)
    {
        foreach (var item in _items)
            if (item.Id == itemId)
                return item.Sprite;

        Debug.LogError("There is no sprite with id " + itemId);
        return null;
    }
}

[Serializable]
public class VisualUiItemConfig
{
    public string Id { get { return _id; } }
    public Sprite Sprite { get { return _sprite; } }

    [SerializeField] private string _id;
    [SerializeField] private Sprite _sprite;
}