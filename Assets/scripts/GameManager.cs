using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    public void Awake()
    {
        game = this;
    }

    public TimeFormat RemainingTime;
    private Timer GameTimer;
    [SerializeField] public Clock gameclock;
    [SerializeField] public OSManager OperatingSystem;

    private void Start()
    {
        GameTimer = GetComponent<Timer>();
        GameTimer.StartTimer();
    }

    public void Update()
    {
        float min = (GameTimer.TimePassed / 60) + 50;
        float sec = GameTimer.TimePassed % 60;
        RemainingTime = new TimeFormat(23f, min, sec);
        
        gameclock.ConfigureHandRotations(RemainingTime);
        OperatingSystem.UpdateClock(RemainingTime);
    }
}
