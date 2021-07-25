using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button xButton;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        xButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        xButton.interactable = false;
    }

    public void OnXButtonClicked()
    {
        Debug.Log(item.name + " 인벤토리에서 삭제");
        Inventory.instance.Remove(item);
    }

    public void OnItemButtonClicked()
    {
        Debug.Log(item.name + " 사용");

        if (item.audioClip != null)
        {
            AudioManager.instance.source.clip = item.audioClip;
            AudioManager.instance.source.Play();
        }

        if (item != null)
        {
            item.Use();
        }
    }
}
