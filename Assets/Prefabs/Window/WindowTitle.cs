using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleBar : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public RectTransform window;

    private Vector2 offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransform parent = window.parent as RectTransform;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        offset = window.localPosition - (Vector3)localPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform parent = window.parent as RectTransform;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        window.localPosition = ClampToWindow(localPoint + offset);
    }
    
    private Vector3 ClampToWindow(Vector3 targetPos)
    {
        RectTransform parentRect = window.parent as RectTransform;
        if (parentRect == null) 
            return targetPos;

        Vector2 parentSize = parentRect.rect.size;
        Vector2 windowSize = window.rect.size;

        Vector3 clamped = targetPos;

        float minX = -parentSize.x / 2 + (windowSize.x * 0.1f);
        float maxX = parentSize.x / 2 - (windowSize.x * 0.1f);

        float minY = -parentSize.y / 2 + (windowSize.x * 0.1f);
        float maxY = parentSize.y / 2 - (windowSize.x * 0.1f);

        clamped.x = Mathf.Clamp(targetPos.x, minX, maxX);
        clamped.y = Mathf.Clamp(targetPos.y, minY, maxY);

        return clamped;
    }
}