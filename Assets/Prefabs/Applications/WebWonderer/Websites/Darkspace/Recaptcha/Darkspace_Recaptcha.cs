using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[Serializable]
public class RecaptchaEntry
{
    public Sprite img;
    public string text;
}

public class Darkspace_Recaptcha : MonoBehaviour
{
    [SerializeField] private RecaptchaEntry[] RecaptchaEntries;
    [SerializeField] private Website Homepage;
    [SerializeField] private Image recaptchaImage;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private GameObject recaptchaError;
    
    private WebWonder webWonder;
    private int recapIdx;
    private string recapAnswer;

    private void Awake()
    {
        webWonder = OSManager.FindParentWebWonderer(transform);
    }

    private void Start()
    {
        ChangeRecaptcha();
    }

    public void ChangeRecaptcha()
    {
        int idx = Random.Range(0, RecaptchaEntries.Length);
        if (idx == recapIdx) ChangeRecaptcha();
        
        recapAnswer = RecaptchaEntries[idx].text;
        recaptchaImage.sprite = RecaptchaEntries[idx].img;
        recapIdx = idx;
    }

    public void VerifyInput()
    {
        if (userInput.text == recapAnswer)
        {
            webWonder.ChangeWebsite(Homepage);
        }
        else
        {
            userInput.text = "";
            recaptchaError.SetActive(true);
            ChangeRecaptcha();
        }
    }
}
