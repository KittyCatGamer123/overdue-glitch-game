using UnityEngine;

public class TextEditorApp : MonoBehaviour
{
    private bool isSaving = false;
    public GameObject LoadingBarPrefab;

    [SerializeField] private OSPopup TooManyWindowsError;
    [SerializeField] private Timer SaveCountdown;
    
    public void OnSaveClicked()
    {
        if (isSaving) return;
        isSaving = true;
        
        GameObject Loading = Instantiate(LoadingBarPrefab, transform.position, transform.rotation, this.transform);
        SaveCountdown.StartTimer();
        
        
    }
    
     public void Update()
     {
        if (SaveCountdown.IsActive)
        {
            if (SaveCountdown.TimePassed > 15)
            {
                if (OSManager.Instance.GetTaskbarCount() > 2)
                {
                    SaveCountdown.IsActive = false;
                    OSManager.Instance.CreateNewPopup(TooManyWindowsError);
                    Destroy (GetComponent<Transform> ().GetChild(4).gameObject);
                }
            }            
        }
     }
}
