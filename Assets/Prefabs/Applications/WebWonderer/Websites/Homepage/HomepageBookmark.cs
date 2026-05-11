using UnityEngine;

public class HomepageBookmark : MonoBehaviour
{
    [SerializeField] private Website Site;

    public void BookmarkClicked()
    { 
        OSManager.FindParentWebWonderer(transform).ChangeWebsite(Site);
    }
}
