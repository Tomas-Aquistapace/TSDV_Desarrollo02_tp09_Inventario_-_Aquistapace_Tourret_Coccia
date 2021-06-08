using UnityEngine.EventSystems;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string _header;
    public string _content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(_content, _header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
}
