using System;
using TMPro;
using UnityEngine;

public class FileConverter : MonoBehaviour
{
    [SerializeField] private TMP_Text DownloadBtnText;
    [SerializeField] private GameObject DropdownBtnOptions;

    private void Start()
    {
        DownloadBtnText.text = "PNG";
        DropdownBtnOptions.SetActive(false);
    }

    public void ToggleDropdown()
    {
        DropdownBtnOptions.SetActive(!DropdownBtnOptions.activeSelf);
    }
    
    public void ChangeFileExportType(TMP_Text stringbox)
    {
        DownloadBtnText.text = stringbox.text;
        DropdownBtnOptions.SetActive(false);
    }
}
