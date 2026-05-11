using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour // , IDragHandler, IPointerDownHandler
{
    // public RectTransform window;
    // private Vector2 offset;
    // public bool uploaded;
    // private GameObject root;

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     if (FileExplorer.uploading)
    //     {
    //         uploaded = true;
    //         //root = FindParentWindow.parentComp;
    //         Destroy(root);
    //     }
    //     else
    //     {
    //     //RectTransform parent = window.parent as RectTransform;
    //     Instantiate(this, transform.position, transform.rotation, GameObject.Find("OperatingSystem").transform);

    //     Vector2 localPoint;
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(
    //         window,
    //         eventData.position,
    //         eventData.pressEventCamera,
    //         out localPoint
    //     );

    //     offset = window.localPosition - (Vector3)localPoint;            
    //     }

    // }

    // public void OnDrag(PointerEventData eventData)
    // {
    //     //RectTransform parent = window.parent as RectTransform;

    //     Vector2 localPoint;
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(
    //         window,
    //         eventData.position,
    //         eventData.pressEventCamera,
    //         out localPoint
    //     );

    //     window.localPosition = localPoint + offset;
    // }

    // //public static WebWonder FindParentWindow(Transform obj_trans)
    // //{
    // //    Object parentComp = obj_trans.gameObject.GetComponent<Window>();
    // //    if (parentComp == null)
    // //    {
    // //        return FindParentWindow(obj_trans.parent.transform);
    // //    }

    // //    return (Window)parentComp;
    // //}
}