using UnityEngine;

public class ComputerUIManager : MonoBehaviour
{
    public static ComputerUIManager Instance;
    public bool ComputerActive = false;
    
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
}
