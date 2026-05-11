using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Darkspace_Homepage : MonoBehaviour
{
    [SerializeField] private Website loginPage;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = Object.FindObjectsByType<WebWonder>(FindObjectsSortMode.None)[0];
    }

    private void Start()
    {
        if (!GameManager.game.DarkspaceLoggedIn)
        {
            webWonder.ChangeWebsite(loginPage);
        }
    }
}
