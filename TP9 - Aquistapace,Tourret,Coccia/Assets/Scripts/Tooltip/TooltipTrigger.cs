﻿using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    string _content;
    string _header;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Item _currentItem = transform.GetComponent<UI_InventorySlot>()._currentItem;
        
        if(_currentItem != null)
        {
            _header = _currentItem._itemName;
            _content = _currentItem.ContentData();

            TooltipSystem.Show(_content, _header);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
}
