using UnityEngine;

public class Housecontained : MonoBehaviour
{
    [SerializeField] private Website nextPage;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = Object.FindObjectsByType<WebWonder>(FindObjectsSortMode.None)[0];
    }

    public void OnNextPageClicked()
    {
        webWonder.ChangeWebsite(nextPage);
    }
}
