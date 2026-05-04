using Unity.Cinemachine;
using UnityEngine;

public class ComputerMonitor : MonoBehaviour
{
    public static ComputerMonitor Instance;
    private bool UsingMonitor = false;
    [SerializeField] private CinemachineCamera MonitorCamera;
    private Interactable InteractableObj;
    private Timer bootupTimer;

    private void Awake()
    {
        Instance = this;
        InteractableObj = GetComponent<Interactable>();
        bootupTimer = GetComponentInChildren<Timer>();
    }

    public void ToggleMonitor()
    {
        UsingMonitor = !UsingMonitor;
        MonitorCamera.gameObject.SetActive(UsingMonitor);
        InteractableObj.SetInteractable(!UsingMonitor);
        HUDController.Instance.crosshairObj.SetActive(!UsingMonitor);
        PlayerMovement.Instance.CanMove = !UsingMonitor;
        
        if (UsingMonitor)
        {
            bootupTimer.StartTimer();
        }
    }

    public void TimerCompleted()
    {
        OSManager.Instance.BootComputer();
    }
}
