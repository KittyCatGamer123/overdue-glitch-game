using System;
using UnityEngine;
using TMPro;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

public class Darkspace_Login : MonoBehaviour
{
    private WebWonder explorerReference;

    [SerializeField] private Website RecaptchaPage;
    [SerializeField] private Button LoginButton; 
    [SerializeField] private TMP_InputField InputEmail;
    [SerializeField] private TMP_InputField InputPwd;
    [SerializeField] private GameObject InputFailText;
    [SerializeField] private Timer loginTime;

    private void Awake()
    {
        explorerReference = OSManager.FindParentWebWonderer(transform);
    }

    private void Start()
    {
        InputFailText.SetActive(false);
    }

    public void LoginButtonPressed()
    {
        InputEmail.interactable = false;
        InputPwd.interactable = false;
        LoginButton.interactable = false;
        InputFailText.SetActive(false);

        loginTime.WaitTime = Random.Range(1, 3);
        loginTime.StartTimer();
    }

    public void LoginLoadingFinished()
    {
        if (InputEmail.text == GameManager.game.StudentEmail && InputPwd.text == GameManager.game.StudentPassword)
        {
            GameManager.game.DarkspaceLoggedIn = true;
            explorerReference.ChangeWebsite(RecaptchaPage);
        }
        else
        {
            InputEmail.interactable = true;
            InputPwd.interactable = true;
            LoginButton.interactable = true;
            InputFailText.SetActive(true);
        }
    }
}
