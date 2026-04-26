using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Window : MonoBehaviour, IPointerDownHandler
{
    private string BaseWindowTitle = "Window";
    private Sprite WindowIcon;
    
    public TaskbarButton RelatedTaskbarButton;
    private bool BusyWithTween = false;
    
    private RectTransform rectTransform;
    private Vector2 offset;

    private bool maximiseActive = false;
    private bool minimiseActive = false;
    
    private Vector2 priorMaximisePosition = new Vector2(0, 0);
    private Vector2 priorMaximiseSize = new Vector2(300, 150);
    private Vector2 maximiseSize = Vector2.one;

    [SerializeField] private PointerEventData.InputButton targetMouseButton;
    private CanvasGroup canvasGroup;

    [Header("Object References")] 
    [SerializeField] private TMP_Text WindowTitleObject;
    [SerializeField] private Image WindowIconObject;
    [SerializeField] private GameObject ContentPanel;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
        maximiseSize = transform.parent.GetComponentInParent<RectTransform>().rect.size;
    }

    void Start()
    {
        float fadeInTime = 0.1f;
        Vector3 endScale = transform.localScale;
        canvasGroup.alpha = 0;
        transform.localScale = endScale * 0.85f;
        
        transform.LeanScale(endScale, fadeInTime).setEaseOutQuad();
        canvasGroup.LeanAlpha(1, fadeInTime);
    }

    public void UpdateTitleBar()
    {
        WindowTitleObject.text = BaseWindowTitle;
        WindowIconObject.sprite = WindowIcon;
    }

    public void OnPointerDown(PointerEventData eventData) => BringToFront();
    public void BringToFront() => rectTransform.SetAsLastSibling();
    
    public void CloseWindowButtonPressed()
    {
        if (RelatedTaskbarButton != null)
        {
            RelatedTaskbarButton.OnWindowDestroy();
        }
        
        float fadeOutTime = 0.1f;
        
        Vector3 closeScale = transform.localScale * 0.85f;
        transform.LeanScale(closeScale, fadeOutTime).setEaseOutQuad();
        canvasGroup.LeanAlpha(0, fadeOutTime)
            .setOnComplete(() => Destroy(gameObject));
    }

    private float maximiseTweenTime = 0.07f;
    public void MaximiseWindowButtonPressed()
    {
        maximiseActive = !maximiseActive;

        RectTransform rt = GetComponent<RectTransform>();
        BusyWithTween = true;

        if (maximiseActive)
        {
            priorMaximiseSize = rt.sizeDelta;
            priorMaximisePosition = rt.position;
            
            rt.LeanMoveLocal(new Vector3(0f, 0f), maximiseTweenTime);
            rt.LeanSize(maximiseSize, maximiseTweenTime)
                .setOnComplete(() => BusyWithTween = false);
        }
        else
        {
            rt.LeanMoveLocal(priorMaximisePosition, maximiseTweenTime);
            rt.LeanSize(priorMaximiseSize, maximiseTweenTime)
                .setOnComplete(() => BusyWithTween = false);
        }
    }

    private float minimiseTweenTime = 0.25f;
    public void MinimiseWindowButtonPressed()
    {
        if (RelatedTaskbarButton == null)
        {
            print("No Taskbar Button to minimise to!");
            return;
        } 
        if (BusyWithTween) 
            return;
        
        maximiseActive = false;
        minimiseActive = !minimiseActive;
        
        RectTransform rt = GetComponent<RectTransform>();
        BusyWithTween = true;
        if (minimiseActive)
        {
            priorMaximiseSize = rt.sizeDelta;
            priorMaximisePosition = rt.position;
            
            rt.LeanMoveLocal(new Vector2(0, -110), minimiseTweenTime);
            rt.LeanScale(new Vector3(0.1f, 0.1f, 0.1f), minimiseTweenTime);

            canvasGroup.LeanAlpha(0, minimiseTweenTime)
                .setOnComplete(() =>
                {
                    gameObject.SetActive(false);
                    BusyWithTween = false;
                });
        }
        else
        {
            gameObject.SetActive(true);
            rt.LeanScale(new Vector3(1f, 1f, 1f), minimiseTweenTime);
            rt.LeanMoveLocal(priorMaximisePosition, minimiseTweenTime);
            rt.LeanSize(priorMaximiseSize, minimiseTweenTime);
            canvasGroup.LeanAlpha(1, minimiseTweenTime)
                .setOnComplete(() => BusyWithTween = false);
        }
    }

    public void InjectContentToWindow(GameObject gmObj)
    {
        Instantiate(gmObj, ContentPanel.transform);
        OSApplication app = gmObj.GetComponent<OSApplication>();
        
        BaseWindowTitle = app.AppName;
        WindowIcon = app.AppIcon;
        UpdateTitleBar();
        
        RelatedTaskbarButton.ButtonName = app.AppName;
        RelatedTaskbarButton.ButtonIcon = app.AppIcon;
        RelatedTaskbarButton.UpdateTitleBar();
    }
}