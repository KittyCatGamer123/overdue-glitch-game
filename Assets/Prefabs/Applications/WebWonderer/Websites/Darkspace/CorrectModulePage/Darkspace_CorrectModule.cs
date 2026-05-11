using UnityEngine;

public class Darkspace_CorrectModule : MonoBehaviour
{
    [SerializeField] private Website SubmissionPage;
    private WebWonder webWonder;

    private void Awake()
    {
        webWonder = OSManager.FindParentWebWonderer(transform);
    }

    public void AssignmentButtonPressed()
    {
        webWonder.ChangeWebsite(SubmissionPage);
    }
}
