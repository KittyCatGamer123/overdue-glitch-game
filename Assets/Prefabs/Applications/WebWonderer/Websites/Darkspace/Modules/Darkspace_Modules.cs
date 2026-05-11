using UnityEngine;

public class Darkspace_Modules : MonoBehaviour
{
    [SerializeField] private Website CorrectPage;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = Object.FindObjectsByType<WebWonder>(FindObjectsSortMode.None)[0];
    }

    public void GameImplementButtonPressed()
    {
        webWonder.ChangeWebsite(CorrectPage);
    }
}
