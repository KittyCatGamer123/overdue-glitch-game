using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopButton : MonoBehaviour, IPointerClickHandler
{
    [Header("Button Configuration")]
    [SerializeField] private GameObject ProgramPrefab;

    [Header("Object References")] 
    [SerializeField] private GameObject WindowPrefab;
    [SerializeField] private GameObject TaskbarButtonPrefab;
    [SerializeField] private GameObject WindowContainer;
    [SerializeField] private HorizontalLayoutGroup TaskbarRef;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        { 
            CreateNewWindow();
        }
    }

    private void CreateNewWindow()
    {
        GameObject windowInstance = Instantiate(WindowPrefab, WindowContainer.transform);
        GameObject taskbarInstance = Instantiate(TaskbarButtonPrefab, TaskbarRef.transform);
        
        Window windowObject = windowInstance.GetComponent<Window>();
        TaskbarButton taskbarButton = taskbarInstance.GetComponent<TaskbarButton>();

        windowObject.RelatedTaskbarButton = taskbarButton;
        taskbarButton.RelativeWindow = windowObject;
        windowObject.UpdateTitleBar();
        taskbarButton.UpdateTitleBar();
        windowObject.InjectContentToWindow(ProgramPrefab);
    }
}
