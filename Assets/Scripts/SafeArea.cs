using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class SafeArea : MonoBehaviour
{
    public RectTransform[] elementsToWrap;  

    RectTransform _panel;

    void Awake()
    {
        GameObject go = new GameObject("SafeAreaPanel", typeof(RectTransform));
        go.transform.SetParent(transform, false);
        _panel = go.GetComponent<RectTransform>();

        _panel.anchorMin = Vector2.zero;
        _panel.anchorMax = Vector2.one;
        _panel.offsetMin = Vector2.zero;
        _panel.offsetMax = Vector2.zero;

        go.AddComponent<Image>().color = new Color(1, 1, 1, 0);

        foreach (RectTransform element in elementsToWrap)
        {
            if (element != null)
                element.SetParent(_panel, true);
        }
    }

    void Start()
    {
        ApplySafeArea();
    }

#if UNITY_EDITOR
    void Update()
    {
        ApplySafeArea();
    }
#endif

    void ApplySafeArea()
    {
        Rect safe = Screen.safeArea;

        Vector2 anchorMin = safe.position;
        Vector2 anchorMax = safe.position + safe.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _panel.anchorMin = anchorMin;
        _panel.anchorMax = anchorMax;
    }
}
