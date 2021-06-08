using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public Tooltip _tooltip;

    private static TooltipSystem _current;

    public void Awake()
    {
        _current = this;
    }

    public static void Show(string content, string header = "")
    {
        _current._tooltip.SetText(content, header);
        _current._tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        _current._tooltip.gameObject.SetActive(false);
    }
}
