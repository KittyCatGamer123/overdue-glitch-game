using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject ProgramPrefab;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        { 
            OSManager.Instance.CreateNewWindow(ProgramPrefab);
        }
    }
}
