using System;
using UnityEngine;

public class TimeFormat
{
    public float hour = 0;
    public float minute = 0;
    public float second = 0;

    public TimeFormat(float h, float m, float s)
    {
        hour = h;
        minute = m;
        second = s;
    }
}

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject HourHand;
    [SerializeField] private GameObject MinuteHand;
    [SerializeField] private GameObject SecondHand;

    public void ConfigureHandRotations(TimeFormat CurrentTime)
    {
        float hRot = Mathf.Lerp(345, 360, (CurrentTime.minute - 50) / 10);
        float mRot = Mathf.Lerp(0, 360, CurrentTime.minute / 60);
        float sRot = Mathf.Lerp(0, 360, CurrentTime.second / 60);
        
        HourHand.transform.eulerAngles = new Vector3(hRot, 0, 0);
        MinuteHand.transform.eulerAngles = new Vector3(mRot, 0, 0);
        SecondHand.transform.eulerAngles = new Vector3(sRot, 0, 0);
    }
}
