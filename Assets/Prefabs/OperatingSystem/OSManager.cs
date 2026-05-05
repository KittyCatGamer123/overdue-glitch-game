using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OSManager : MonoBehaviour
{
    public static OSManager Instance;
    public bool ComputerActive = false;
    
    [SerializeField] private TMP_Text TimeDisplay;
    [SerializeField] public Transform Taskbar;
    
    [Header("Window References")] 
    [SerializeField] private GameObject WindowPrefab;
    [SerializeField] private GameObject TaskbarButtonPrefab;
    [SerializeField] private GameObject WindowContainer;
    [SerializeField] private HorizontalLayoutGroup TaskbarRef;
    
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    
    public void CreateNewWindow(GameObject injectionProgram = null)
    {
        GameObject windowInstance = Instantiate(WindowPrefab, WindowContainer.transform);
        GameObject taskbarInstance = Instantiate(TaskbarButtonPrefab, TaskbarRef.transform);
        
        Window windowObject = windowInstance.GetComponent<Window>();
        TaskbarButton taskbarButton = taskbarInstance.GetComponent<TaskbarButton>();

        windowObject.RelatedTaskbarButton = taskbarButton;
        taskbarButton.RelativeWindow = windowObject;
        windowObject.UpdateTitleBar();
        taskbarButton.UpdateTitleBar();

        if (injectionProgram != null)
        {
            windowObject.InjectContentToWindow(injectionProgram);
        }
    }

    public void CreateNewPopup(OSPopup popupPrefab)
    {
        GameObject popupInstance = Instantiate(popupPrefab.gameObject, WindowContainer.transform);
        GameObject taskbarInstance = Instantiate(TaskbarButtonPrefab, TaskbarRef.transform);
        
        OSPopup popupObject = popupInstance.GetComponent<OSPopup>();
        TaskbarButton taskbarButton = taskbarInstance.GetComponent<TaskbarButton>();
        
        popupObject.RelatedTaskbarButton = taskbarButton;
        taskbarButton.RelativePopup = popupObject;

        taskbarButton.ButtonName = (popupObject.Type == PopupType.Notice) ? "Notification" : "Error";
        taskbarButton.UpdateTitleBar();
    }

    public void BootComputer()
    {
        ComputerActive = true;
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UpdateClock(TimeFormat t)
    {
        TimeDisplay.text = $"{t.hour:00}:{t.minute:00}:{t.second:00}";
    }

    public void ExitComputer()
    {
        ComputerMonitor.Instance.ToggleMonitor();
        ComputerActive = false;
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public int GetTaskbarCount() => Instance.Taskbar.childCount;
}
