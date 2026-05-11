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
    
    [Header("Bootup References")]
    [SerializeField] private GameObject webWonObj;
    [SerializeField] private GameObject letterboxObj;
    
    private void Awake()
    {
        Instance = this;   
    }

    private void Start()
    {
        gameObject.SetActive(false);
        MakePresetWindows();
    }

    private void MakePresetWindows()
    {
        Window w1 = CreateNewWindow(webWonObj);
        w1.transform.localPosition = new Vector2(-50, 30);
        
        Window w2 = CreateNewWindow(webWonObj);
        w2.transform.localPosition = new Vector2(65, 11);
        
        Window w3 = CreateNewWindow(webWonObj);
        w3.transform.localPosition = new Vector2(35, -35);
        
        Window letterBox = CreateNewWindow(letterboxObj);
        letterBox.transform.localPosition = new Vector2(5, -10);
    }
    
    public Window CreateNewWindow(GameObject injectionProgram = null)
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

        return windowObject;
    }

    public OSPopup CreateNewPopup(OSPopup popupPrefab)
    {
        GameObject popupInstance = Instantiate(popupPrefab.gameObject, WindowContainer.transform);
        GameObject taskbarInstance = Instantiate(TaskbarButtonPrefab, TaskbarRef.transform);
        
        OSPopup popupObject = popupInstance.GetComponent<OSPopup>();
        TaskbarButton taskbarButton = taskbarInstance.GetComponent<TaskbarButton>();
        
        popupObject.RelatedTaskbarButton = taskbarButton;
        taskbarButton.RelativePopup = popupObject;

        taskbarButton.ButtonName = (popupObject.Type == PopupType.Notice) ? "Notification" : "Error";
        taskbarButton.UpdateTitleBar();

        return popupObject;
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

    public static WebWonder FindParentWebWonderer(Transform obj_trans)
    {
        Object parentComp = obj_trans.gameObject.GetComponent<WebWonder>();
        if (parentComp == null)
        {
            return FindParentWebWonderer(obj_trans.parent.transform);
        }

        return (WebWonder)parentComp;
    }

    public int GetTaskbarCount() => Instance.Taskbar.childCount;
}
