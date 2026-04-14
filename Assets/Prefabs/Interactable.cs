using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private Outline outline;
    public string message;
    private bool interactEnabled = true;

    public UnityEvent onInteraction;
    
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interaction()
    {
        if (interactEnabled) onInteraction.Invoke();
    }

    public void SetInteractable(bool state)
    {
        interactEnabled = state;
        if (state == false)
        {
            DisableOutline();
            HUDController.Instance.DisableInteractionText();
        }
    }

    public void EnableOutline()
    {
        if (interactEnabled) outline.enabled = true;
    }
    
    public void DisableOutline()
    {
        outline.enabled = false;
    }
}