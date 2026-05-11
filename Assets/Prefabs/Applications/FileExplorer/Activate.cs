using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject Files;
    public GameObject allFiles;
    public void OnDesktopClicked()
    {
        foreach (Transform t in allFiles.transform) {
        // t.gameObject.SetActive(false); // if you want to disable all
        t.gameObject.SetActive(t.gameObject == Files);
        }
    }
}
