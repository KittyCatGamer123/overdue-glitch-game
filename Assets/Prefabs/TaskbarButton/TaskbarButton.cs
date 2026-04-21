using UnityEngine;

public class TaskbarButton : MonoBehaviour
{
    public Window RelativeWindow;
    
    private CanvasGroup canvasGroup;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnButtonPressed()
    {
        if (RelativeWindow == null)
        {
            print("No relative window found!");
            return;
        }
        RelativeWindow.MinimiseWindowButtonPressed();
    }

    public void OnWindowDestroy()
    {
        float fadeOutTime = 0.1f;
        
        Vector3 closeScale = transform.localScale * 0.85f;
        transform.LeanScale(closeScale, fadeOutTime).setEaseOutQuad();
        canvasGroup.LeanAlpha(0, fadeOutTime)
            .setOnComplete(() => Destroy(gameObject));
    }
}
