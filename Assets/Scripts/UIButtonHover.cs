using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image backgroundImage;
    public Image outlineImage;
    public GameObject handIcon;

    public Color hoverColor = new Color(1f, 1f, 0.8f);
    private Color originalColor;
    private Vector3 originalScale;

  
    private Vector2 handOffset = new Vector2(630f, 35f);

    void Start()
    {
        originalColor = backgroundImage.color;
        originalScale = transform.localScale;

        if (outlineImage != null)
            outlineImage.enabled = false;

        if (handIcon != null)
            handIcon.SetActive(false); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        backgroundImage.color = hoverColor;
        transform.localScale = originalScale * 1.05f;

        if (outlineImage != null)
            outlineImage.enabled = true;

        if (handIcon != null)
        {
            handIcon.SetActive(true);
            handIcon.transform.position = transform.position + (Vector3)handOffset;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundImage.color = originalColor;
        transform.localScale = originalScale;

        if (outlineImage != null)
            outlineImage.enabled = false;

        if (handIcon != null)
            handIcon.SetActive(false);
    }
}
