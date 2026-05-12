using System;
using Unity.Cinemachine;
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
    public Timer GameTimer;
    [SerializeField] public Clock gameclock;
    [SerializeField] public OSManager OperatingSystem;

    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private GameObject TitleCamera;
    [SerializeField] private GameObject Player;

    public bool DarkspaceLoggedIn = false;
    public string StudentEmail;
    public string StudentPassword;

    [SerializeField] private Stickynote Stickynote;

    static public bool Saved;
    static public bool Fixed;
    static public bool AntiVirus;
    static public bool Uploaded;

    private void Start()
    {
        GameTimer = GetComponent<Timer>();
        TitleScreen.SetActive(true);
        Crosshair.SetActive(false);
        TitleCamera.SetActive(true);
        Player.SetActive(false);
    }

    public void BeginGame()
    {
        TitleScreen.SetActive(false);
        Crosshair.SetActive(true);
        TitleCamera.SetActive(false);
        Player.SetActive(true);
        
        DarkspaceLoggedIn = false;
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
        
        Stickynote.SetSticky($"\"Darkspace Login:\n{StudentEmail}\nPassword:\n{StudentPassword}\"");
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
