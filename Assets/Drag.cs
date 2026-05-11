using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public RectTransform window;

    private Vector2 offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        //RectTransform parent = window.parent as RectTransform;
        Instantiate(this, transform.position, transform.rotation, GameObject.Find("OperatingSystem").transform);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            window,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        offset = window.localPosition - (Vector3)localPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //RectTransform parent = window.parent as RectTransform;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            window,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        window.localPosition = localPoint + offset;
    }
}