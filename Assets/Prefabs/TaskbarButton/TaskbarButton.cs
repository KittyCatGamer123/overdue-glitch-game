using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskbarButton : MonoBehaviour
{
    public Window RelativeWindow;
    public OSPopup RelativePopup;

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
        if (RelativeWindow != null)
        {
            RelativeWindow.MinimiseWindowButtonPressed();
            RelativeWindow.BringToFront();
        }
        else if (RelativePopup != null)
        {
            RelativePopup.MinimiseWindowButtonPressed();
            RelativePopup.BringToFront();
        }
        else
        {
            print("No relative window found!");
        }
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
