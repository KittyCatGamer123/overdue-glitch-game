using UnityEngine;

public class TextEditorApp : MonoBehaviour
{
    private bool isSaving = false;
    public GameObject LoadingBarPrefab;
    private bool TimerOn = false;
    private float Timer = 20;
    int TabNo = TabCounter.Tabs;
    //[SerializeField] private GameObject ProgramPrefab;
    //[SerializeField] private GameObject WindowPrefab;
    public void OnSaveClicked()
    {
        if (isSaving) return;
        isSaving = true;
        
        GameObject Loading = Instantiate(LoadingBarPrefab, transform.position, transform.rotation, this.transform);
        TimerOn = true;
    }

    public void Start()
    {
        
    }
    public void Update()
    {
        if(TimerOn = true)
        {
            Timer -= Time.deltaTime;
        }
        if(Timer < 5)
        {
            if(TabNo > 2)
            {
                TimerOn = false;
                Destroy (GetComponent<Transform> ().GetChild(3).gameObject);
                //Trying to create error window but don't know enough
                //GameObject windowInstance = Instantiate(WindowPrefab, transform.position);
                //Window windowObject = windowInstance.GetComponent<Window>();
                //windowObject.InjectContentToWindow(ProgramPrefab);
            }
        }
    }
}
