using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject Files;
    public GameObject allFiles;
    private void Awake()
    {
        Files.SetActive(false);
    }
    public void OnDesktopClicked()
    {
        foreach (Transform t in allFiles.transform) {
        // t.gameObject.SetActive(false); // if you want to disable all
        t.gameObject.SetActive(t.gameObject == Files); // hide all, except required one 
        // t.gameObject.SetActive(t == objectToShow.transform); // this also works
        }
    }
}
