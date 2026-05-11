using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject allFiles;
    void Awake()
    {
        foreach (Transform t in allFiles.transform) {
            t.gameObject.SetActive(false);
        }
    }
}
