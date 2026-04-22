using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class TabMenu : MonoBehaviour
{
    [Header("Current Index")] 
    [SerializeField] private int PageIndex = 0;

    [Header("Components")] 
    [SerializeField] private List<Button> tabs = new List<Button>();
    [SerializeField] private List<CanvasGroup> pages = new List<CanvasGroup>();

    private void Start()
    {
        for (int i = 0; i < tabs.Count; i++)
        {
            Button btn = tabs[i];
            var i1 = i;
            btn.onClick.AddListener(() => ChangeTab(i1));
        }
    }

    public void ChangeTab(int index)
    {
        for (int i = 0; i < pages.Count; i++)
        {
            bool isActive = index == i;
            pages[i].alpha = isActive ? 1 : 0;
            pages[i].interactable = isActive;
            pages[i].blocksRaycasts = isActive;
        }
    }
}
