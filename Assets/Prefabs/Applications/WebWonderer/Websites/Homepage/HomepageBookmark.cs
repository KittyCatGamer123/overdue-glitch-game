using UnityEngine;

public class HomepageBookmark : MonoBehaviour
{
    [SerializeField] private Website Site;

    public void BookmarkClicked()
    {
        transform.parent.GetComponentInParent<WebWonder>().ChangeWebsite(Site);
    }
}
