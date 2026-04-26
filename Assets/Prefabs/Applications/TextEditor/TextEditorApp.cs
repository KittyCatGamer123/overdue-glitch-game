using UnityEngine;

public class TextEditorApp : MonoBehaviour
{
    private bool isSaving = false;
    public void OnSaveClicked()
    {
        if (isSaving) return;
        isSaving = true;
        
        
    }
}
