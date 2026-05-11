using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Darkspace_SidebarBtn : MonoBehaviour
{
    [SerializeField] private Website CorrespondingSite;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = Object.FindObjectsByType<WebWonder>(FindObjectsSortMode.None)[0];
    }

    public void ButtonPressed()
    {
        webWonder.ChangeWebsite(CorrespondingSite);
    }
}
