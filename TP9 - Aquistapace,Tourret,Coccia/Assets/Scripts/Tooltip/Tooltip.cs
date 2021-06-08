using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI _headerField;
    public TextMeshProUGUI _contentField;
    public LayoutElement _layoutElement;
    public int _characterWrapLimit;
    public RectTransform _rectTransform;

    float pivY;

    public void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        pivY = _rectTransform.pivot.y;
    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            _headerField.gameObject.SetActive(false);
        }
        else
        {
            _headerField.gameObject.SetActive(true);
            _headerField.text = header;
        }

        _contentField.text = content;

        int headerLenght = _headerField.text.Length;
        int contentLenght = _contentField.text.Length;

        _layoutElement.enabled = (headerLenght > _characterWrapLimit || contentLenght > _characterWrapLimit) ? true : false;
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLenght = _headerField.text.Length;
            int contentLenght = _contentField.text.Length;

            _layoutElement.enabled = (headerLenght > _characterWrapLimit || contentLenght > _characterWrapLimit) ? true : false;
        }
        Vector2 mousePos = Input.mousePosition;

        MovePivot(mousePos);

        transform.position = mousePos;
    }

    void MovePivot(Vector2 mousePos)
    {
        float pivotX = 0;
        float pivotY = 0;

        if (mousePos.y <= Screen.height / 2)
            pivotY = 0;
        else
            pivotY = pivY;


        if (mousePos.x <= Screen.width / 2)
            pivotX = 0;
        else 
            pivotX = _rectTransform.rect.width;

        _rectTransform.pivot = new Vector2(pivotX, pivotY);
    }
}
