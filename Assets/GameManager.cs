using System;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public bool DarkspaceLoggedIn = false;
    public string StudentEmail;
    public string StudentPassword;

    private void Start()
    {
        GameTimer = GetComponent<Timer>();
        GameTimer.StartTimer();

        // A-D + 00000000 + @darkspace.com
        // e.g. 
        StudentEmail = (char)Random.Range(65, 68) + Random.Range(0, 99999999).ToString().PadLeft(8, '0') + "@darkspace.com";

        // Make a password of 15 characters, A-Z/a-z
        for (int i = 0; i < 7; i++)
        {
            // Capital letters span ascii 65-90, add another 32 to have it lower case.
            bool isCap = Random.Range(0, 2) == 1;
            StudentPassword += (char)(Random.Range(65, 91) + (isCap ? 0 : 32));
        }
        
        print($"{StudentEmail} : {StudentPassword}");
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
