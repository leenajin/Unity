using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();

    public int maxSpace = 9;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

   
    void Awake()
    {
        instance = this;
    }

    public bool Add(Item addedItem)
    {
        if(items.Count >= maxSpace)
        {
            return false;
        }
        items.Add(addedItem);
        onItemChanged?.Invoke();
        return true;
    }

    public void Remove(Item removedItem)
    {
        items.Remove(removedItem);
        onItemChanged?.Invoke();
    }
}
