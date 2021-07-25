using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    InventorySlot[] slot;
    public Transform slotParent;

    public GameObject inventoryHead;

    private void Awake()
    {
        inventory = Inventory.instance;
        slot = slotParent.GetComponentsInChildren<InventorySlot>();
    }

    private void OnEnable()
    {
        inventory.onItemChanged += UpdateUI;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryHead.SetActive(!inventoryHead.activeSelf);
            
        }
    }


    void UpdateUI()
    {
        for(int i=0; i<slot.Length; i++)
        {
            if(i<inventory.items.Count)
            {
                slot[i].AddItem(inventory.items[i]);
            }
            else
            {
                slot[i].ClearSlot();
            }
        }
    }

}
