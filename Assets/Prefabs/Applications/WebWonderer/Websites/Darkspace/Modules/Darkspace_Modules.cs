using UnityEngine;

public class Darkspace_Modules : MonoBehaviour
{
    [SerializeField] private Website CorrectPage;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = OSManager.FindParentWebWonderer(transform);
    }

    public void GameImplementButtonPressed()
    {
        webWonder.ChangeWebsite(CorrectPage);
    }
}
