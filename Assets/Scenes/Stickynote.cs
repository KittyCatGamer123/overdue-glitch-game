using System;
using TMPro;
using UnityEngine;

public class Stickynote : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    public void SetSticky(string details)
    {
        label.text = details;
        GetComponent<Interactable>().message = details;
    }
}
