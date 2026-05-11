using UnityEngine;

public class Housecontained : MonoBehaviour
{
    [SerializeField] private Website nextPage;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = OSManager.FindParentWebWonderer(transform);
    }

    public void OnNextPageClicked()
    {
        webWonder.ChangeWebsite(nextPage);
    }
}
