using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Darkspace_SidebarBtn : MonoBehaviour
{
    [SerializeField] private Website CorrespondingSite;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = OSManager.FindParentWebWonderer(transform);
    }

    public void ButtonPressed()
    {
        webWonder.ChangeWebsite(CorrespondingSite);
    }
}
