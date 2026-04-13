using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float WaitTime = 10;
    public float TimePassed { get; private set; }
    public bool IsActive = false;

    public UnityEvent onTimeout;

    public void StartTimer()
    {
        TimePassed = 0;
        IsActive = true;
    }
    void Update()
    {
        if (IsActive)
        {
            TimePassed += Time.deltaTime;
            if (TimePassed >= WaitTime)
            {
                IsActive = false;
                TimePassed = 0;
                onTimeout.Invoke();
            }
        }
    }
}