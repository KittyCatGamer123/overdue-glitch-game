using UnityEngine;

public class TabCounter : MonoBehaviour
{
    public static int Tabs;

    public void Update()
    {
        Tabs = transform.childCount;
    }
}
