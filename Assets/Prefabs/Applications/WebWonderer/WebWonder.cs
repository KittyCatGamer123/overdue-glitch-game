using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WebWonder : MonoBehaviour
{
    [SerializeField] private GameObject PageContent;
    [SerializeField] private Website HomePage;
    
    [SerializeField] private TMP_Text WebsiteLinkText;
    [SerializeField] private GameObject LoadingBar;
    [SerializeField] private GameObject LoadingBarProgress;
    
    private Website ActiveSite = null;
    private Timer pageLoadTimer;

    private void Awake()
    {
        pageLoadTimer = GetComponent<Timer>();
    }

    private void Start()
    {
        LoadingBar.SetActive(false);
        ChangeWebsite(HomePage);
    }

    private void Update()
    {
        if (pageLoadTimer.IsActive)
        {
            // Silly jumpy progressbar jank
            float progress = pageLoadTimer.TimePassed / pageLoadTimer.WaitTime;
            float visibleProgress = 0.0f;
            
            if (progress < 0.15f || progress > 0.85f) visibleProgress = progress;
            else if (progress < 0.65f) visibleProgress = 0.28f;
            else if (progress > 0.65f) visibleProgress = 0.68f;
            
            LoadingBarProgress.transform.localScale = new Vector3(visibleProgress, 1f, 1f);
        }
    }

    public void ChangeWebsite(Website toChangeTo)
    {
        if (ActiveSite != null)
        {
            // No need to do all this if we're already on the site
            if (toChangeTo.WebsiteUrl == ActiveSite.WebsiteUrl) return;
            
            Destroy(ActiveSite.gameObject);
            ActiveSite = null;
        }

        pageLoadTimer.StopTimer();
        WebsiteLinkText.text = toChangeTo.WebsiteUrl;

        // Don't do the whole loading bar part for the homepage
        if (toChangeTo.WebsiteUrl != HomePage.WebsiteUrl)
        {
            LoadingBarProgress.transform.localScale = new Vector3(0, 1, 1);
            LoadingBar.SetActive(true);
        
            pageLoadTimer.onTimeout.RemoveAllListeners();
            pageLoadTimer.onTimeout.AddListener(() => OnPageLoadFinished(toChangeTo));
            pageLoadTimer.WaitTime = Random.Range(3.5f, 8f);
            pageLoadTimer.StartTimer();   
        }
        else
        {
            OnPageLoadFinished(toChangeTo);
        }
    }

    private void OnPageLoadFinished(Website toChangeTo)
    {
        LoadingBar.SetActive(false);
        ActiveSite = Instantiate(toChangeTo.gameObject, PageContent.transform).GetComponent<Website>();
        pageLoadTimer.StopTimer();
    }

    public void GoToHome()
    {
        ChangeWebsite(HomePage);
    }
}
