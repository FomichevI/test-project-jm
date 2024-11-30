using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

// В будущем цену и валюту покупки будем брать извне по id покупки
public class PackData
{
    public string HeaderText { get { return _headerText; } }
    public string DescriptionText { get { return _descriptionText; } }
    public PackItem[] Items { get { return _items; } }
    public string Currency { get { return _currency; } }
    public float FullPrice { get { return _fullPrice; } }
    public float DiscountedPrice { get { return _discountedPrice; } }
    public string IconId { get { return _iconId; } }

    private string _headerText;
    private string _descriptionText;
    private PackItem[] _items;
    private string _currency;
    private float _fullPrice;
    private float _discountedPrice;
    private string _iconId;

    public void SetParameters(PackDataAdapter dataAdapter)
    {
        _headerText = dataAdapter.HeaderText;
        _descriptionText = dataAdapter.DescriptionText;
        _items = new PackItem[dataAdapter.Items.Length];
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = new PackItem();
            _items[i].SetParameters(dataAdapter.Items[i]);
        }
        _currency = dataAdapter.Currency;
        _fullPrice = dataAdapter.FullPrice;
        _discountedPrice = dataAdapter.DiscountedPrice;
        _iconId = dataAdapter.IconId;
    }
}

public class PackItem
{
    public string ItemId { get { return _itemId; } }
    public int Count { get { return _count; } }

    private string _itemId;
    private int _count;

    public void SetParameters(PackItemAdapter itemAdapter)
    {
        _itemId = itemAdapter.ItemId;
        _count = itemAdapter.Count;
    }
}

public class PackDataAdapter
{
    public string HeaderText;
    public string DescriptionText;
    public PackItemAdapter[] Items;
    public string Currency;
    public float FullPrice;
    public float DiscountedPrice;
    public string IconId;
}

[Serializable]
public class PackItemAdapter
{
    public string ItemId;
    public int Count;
}
