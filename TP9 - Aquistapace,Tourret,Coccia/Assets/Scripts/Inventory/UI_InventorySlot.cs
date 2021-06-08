using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventorySlot : MonoBehaviour
{
    public Image _icon = null;
    public static Action<Item> removeButton;
    public static Action<int> UnequipButton;
    public Item _currentItem;
    Button _removeButton;

    private void Start()
    {
        _icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        _removeButton = gameObject.transform.GetChild(1).GetComponent<Button>();
    }

    public void AddItem(Item newItem)
    {
        _currentItem = newItem;
        _icon.sprite = newItem._2Dmodel;
        _icon.enabled = true;
        _removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _icon.sprite = null;
        _icon.enabled = false;
        _currentItem = null;
        _removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        removeButton?.Invoke(_currentItem);
    }
    public void OnUnequipButton(int slot)
    {
        UnequipButton?.Invoke(slot);
    }
    public void UseItem()
    {
        if(_currentItem != null)
            _currentItem.Use();
    }
}
