using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject seconds, minutes, hours;
    string oldSeconds, oldMinutes, oldHours;

    private void Start()
    {
        seconds.transform.Rotate(new Vector3(0, 0,(360 / 60) * float.Parse(System.DateTime.UtcNow.ToString("ss"))), Space.Self);
        minutes.transform.Rotate(new Vector3(0, 0, (360 / 60) * float.Parse(System.DateTime.UtcNow.ToString("mm"))), Space.Self);
        hours.transform.Rotate(new Vector3(0, 0, (360 / 12) * float.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"))));

    }

    // Update is called once per frame
    void Update()
    {
        string seconds = System.DateTime.UtcNow.ToString("ss");
        string minutes = System.DateTime.UtcNow.ToString("mm");
        string hours = System.DateTime.UtcNow.ToString("hh");

        if (seconds != oldSeconds)
            UpdateSeconds();
        oldSeconds = seconds;

        if (minutes != oldMinutes)
            UpdateMinutes();
        oldMinutes = minutes;

        if (hours != oldHours)
            UpdateHours();
        oldHours = hours;
    }

    void UpdateSeconds()
    {
        float secondsInt = float.Parse(System.DateTime.UtcNow.ToString("ss"));

        seconds.transform.Rotate(new Vector3(0,0, 6), Space.Self);

    }

    void UpdateMinutes()
    {
        float minutesInt = float.Parse(System.DateTime.UtcNow.ToString("mm"));
        minutes.transform.Rotate(new Vector3(0, 0, 6), Space.Self);
    }

    void UpdateHours()
    {
        float hoursInt = float.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        hours.transform.Rotate(new Vector3(0, 0, 360 / 12), Space.Self);

    }
}
