using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum PopupType {
    Notice,
    Error
}

public class OSPopup : MonoBehaviour, IPointerDownHandler
{
    [Header("PopUp Configuration")]
    [SerializeField] public PopupType Type = PopupType.Notice;
    [SerializeField] private Vector2 PopupSize = new Vector2(100, 50);
    
    [Header("Object Reference")]
    public TaskbarButton RelatedTaskbarButton;

    private bool BusyWithTween = false;
    private bool minimiseActive = false;
    
    private CanvasGroup canvasGroup;
    private Image popupImage;
    private Sprite popupIcon;
    private RectTransform rectTransform;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        popupImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        //popupIcon = GetComponentInChildren<Sprite>();
    }

    void Start()
    {
        popupImage.color = (Type == PopupType.Notice) ? Color.white : new Color(1, 0.27f, 0.27f);
        
        float fadeInTime = 0.1f;
        Vector3 endScale = transform.localScale;
        canvasGroup.alpha = 0;
        transform.localScale = endScale * 0.85f;
        
        transform.LeanScale(endScale, fadeInTime).setEaseOutQuad();
        canvasGroup.LeanAlpha(1, fadeInTime);
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

        minimiseActive = !minimiseActive;
        BusyWithTween = true;
        
        if (minimiseActive)
        {
            rectTransform.LeanMoveLocal(new Vector2(0, -110), minimiseTweenTime);
            rectTransform.LeanScale(new Vector3(0.1f, 0.1f, 0.1f), minimiseTweenTime);

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
            rectTransform.LeanScale(new Vector3(1f, 1f, 1f), minimiseTweenTime);
            rectTransform.LeanMoveLocal(new Vector2(0, 0), minimiseTweenTime);
            rectTransform.LeanSize(PopupSize, minimiseTweenTime);
            canvasGroup.LeanAlpha(1, minimiseTweenTime)
                .setOnComplete(() => BusyWithTween = false);
        }
    }
    
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

    public void OnPointerDown(PointerEventData eventData) => BringToFront();
    public void BringToFront() => rectTransform.SetAsLastSibling();
}
