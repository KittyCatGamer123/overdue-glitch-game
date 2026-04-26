using System;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public static HUDController Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] public GameObject crosshairObj;
    [SerializeField] private TMP_Text interactionText;

    public void EnableInteractionText(string text)
    {
        interactionText.text = $"{text}";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText() => interactionText.gameObject.SetActive(false);
}
