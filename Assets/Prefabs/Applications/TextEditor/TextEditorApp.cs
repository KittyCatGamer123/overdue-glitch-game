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
        
        //GameObject Loading = Instantiate(LoadingBarPrefab, transform.position, transform.rotation, this.transform);
        //SaveCountdown.StartTimer();
        
        OSManager.Instance.CreateNewPopup(TooManyWindowsError);
    }
    
    // public void Update()
    // {
    //     if (SaveCountdown.TimePassed > 15)
    //     {
    //         if (OSManager.Instance.GetTaskbarCount() > 2)
    //         {
    //             // @Senan: Please rewrite this so it doesn't call every frame. Thanks :3
    //             SaveCountdown.IsActive = false;
    //         }
    //     }
    // }
}
