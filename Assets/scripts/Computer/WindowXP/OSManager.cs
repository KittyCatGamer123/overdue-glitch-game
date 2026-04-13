using TMPro;
using UnityEngine;

public class OSManager : MonoBehaviour
{
    public static OSManager Instance;
    public bool ComputerActive = false;
    [SerializeField] private TMP_Text TimeDisplay;
    
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
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
}
