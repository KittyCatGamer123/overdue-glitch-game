using UnityEngine;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour, IPointerDownHandler
{
    private RectTransform rectTransform;
    private Vector2 offset;

    [SerializeField] private PointerEventData.InputButton targetMouseButton;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void OnPointerDown(PointerEventData eventData) => rectTransform.SetAsLastSibling();

    public void CloseWindowButtonPressed()
    {
        float fadeOutTime = 0.1f;
        
        Vector3 closeScale = transform.localScale * (float)0.85;
        transform.LeanScale(closeScale, fadeOutTime).setEaseOutQuad();
        canvasGroup.LeanAlpha(0, fadeOutTime)
            .setOnComplete(() => Destroy(gameObject));
    }
}