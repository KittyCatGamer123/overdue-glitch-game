using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskbarButton : MonoBehaviour
{
    public Window RelativeWindow;

    public string ButtonName;
    public Sprite ButtonIcon;

    [SerializeField] private TMP_Text ButtonNameTxt;
    [SerializeField] private Image ButtonIconObject;
    private CanvasGroup canvasGroup;
    
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void UpdateTitleBar()
    {
        ButtonNameTxt.text = ButtonName;
        ButtonIconObject.sprite = ButtonIcon;
    }

    public void OnButtonPressed()
    {
        if (RelativeWindow == null)
        {
            print("No relative window found!");
            return;
        }
        RelativeWindow.MinimiseWindowButtonPressed();
        RelativeWindow.BringToFront();
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
