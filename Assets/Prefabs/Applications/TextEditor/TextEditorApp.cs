using UnityEngine;

public class TextEditorApp : MonoBehaviour
{
    private bool isSaving = false;

    [SerializeField] private OSPopup SavingDocumentPopup;
    [SerializeField] private OSPopup TooManyWindowsError;
    [SerializeField] private Timer SaveCountdown;

    private OSPopup SaveDocPopupInst;
    
    public void OnSaveClicked()
    {
        if (isSaving) return;
        isSaving = true;
        
        SaveDocPopupInst = OSManager.Instance.CreateNewPopup(SavingDocumentPopup);
        SaveCountdown.StartTimer();
    }
    
     public void Update()
     {
        if (SaveCountdown.IsActive)
        {
            if (SaveCountdown.TimePassed > 6)
            {
                if (OSManager.Instance.GetTaskbarCount() > 3)
                {
                    SaveCountdown.IsActive = false;
                    isSaving = false;
                    SaveDocPopupInst.CloseWindowButtonPressed();
                    OSManager.Instance.CreateNewPopup(TooManyWindowsError);
                }
            }            
        }
     }
}
