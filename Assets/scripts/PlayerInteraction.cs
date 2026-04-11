using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float Reach = 4f;
    private Interactable currentInteractable;
    
    private CinemachineCamera playerCamera;

    private void Start()
    {
        playerCamera = GetComponentInChildren<CinemachineCamera>();
    }

    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interaction();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out hit, Reach))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                
                if (newInteractable.enabled)
                {
                    currentInteractable = newInteractable;
                    currentInteractable.EnableOutline();
                    HUDController.Instance.EnableInteractionText(currentInteractable.message);
                }
                else DisableInteraction();
            }
            else DisableInteraction();
        }
        else DisableInteraction();
    }

    void DisableInteraction()
    {
        HUDController.Instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
